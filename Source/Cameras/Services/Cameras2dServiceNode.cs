using System;
using System.Collections.Generic;
using Godot;
using GUtils.Optionals;
using GUtilsGodot.Cameras.Behaviours;
using GUtilsGodot.Cameras.Enums;

namespace GUtilsGodot.Cameras.Services;

public partial class Cameras2dServiceNode : Node2D, ICameras2dService
{
    [Export] CameraProcessMode ProcessMode;
    [Export] Camera2D? Camera2D;

    readonly List<ICamera2dBehaviour> _camera2dBehaviours = new();

    bool _previousStateValid;
    
    public Camera2D MainCamera => Camera2D!;

    public override void _Process(double delta)
    {
        if (ProcessMode == CameraProcessMode.Default)
        {
            Tick(delta);
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        if (ProcessMode == CameraProcessMode.Physics)
        {
            Tick(delta);
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

    public void InvalidateState()
    {
        _previousStateValid = false;
    }

    void Tick(double delta)
    {
        float dt = (float)delta;
        
        foreach (ICamera2dBehaviour camera2dBehaviour in _camera2dBehaviours)
        {
            camera2dBehaviour.Tick(dt, _previousStateValid, Camera2D!);
        }

        _previousStateValid = true;
    }
}