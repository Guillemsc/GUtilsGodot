using System;
using System.Collections.Generic;
using Godot;
using GUtils.Optionals;
using GUtilsGodot.Cameras.Behaviours;

namespace GUtilsGodot.Cameras.Services;

public partial class Cameras2dServiceNode : Node2D, ICameras2dService
{
    [Export] Camera2D? Camera2D;

    readonly List<ICamera2dBehaviour> _camera2dBehaviours = new();
    
    public Camera2D MainCamera => Camera2D!;

    public override void _Process(double delta)
    {
        float dt = (float)delta;
        
        foreach (ICamera2dBehaviour camera2dBehaviour in _camera2dBehaviours)
        {
            camera2dBehaviour.Tick(dt, Camera2D!);
        }
    }
    
    public void AddBehaviour(ICamera2dBehaviour behaviour)
    {
        _camera2dBehaviours.Add(behaviour);
    }

    public void RemoveBehaviour(ICamera2dBehaviour behaviour)
    {
        _camera2dBehaviours.Remove(behaviour);
    }

    public Optional<T> GetBehaviour<T>() where T : ICamera2dBehaviour
    {
        foreach (ICamera2dBehaviour camera2dBehaviour in _camera2dBehaviours)
        {
            Type type = typeof(T);

            bool isType = type == camera2dBehaviour.GetType();

            if (isType)
            {
                return (T)camera2dBehaviour;
            }
        }
        
        return Optional<T>.None;
    }

    public void ClearBehaviours()
    {
        _camera2dBehaviours.Clear();
    }
}