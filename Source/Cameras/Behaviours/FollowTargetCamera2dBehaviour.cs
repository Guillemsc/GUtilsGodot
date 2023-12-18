using System.Collections.Generic;
using Godot;
using GUtils.Optionals;
using GUtilsGodot.Cameras.PositionProcessors;

namespace GUtilsGodot.Cameras.Behaviours;

public sealed class FollowTargetCamera2dBehaviour : ICamera2dBehaviour
{
    Optional<Node2D> _target;
    float _velocity = 5f;
    readonly List<IPosition2dProcessor> _position2dProcessors = new();
    
    public void Tick(float dt, bool previousStateValid, Camera2D camera2D)
    {
        bool hasTarget = _target.TryGet(out Node2D targetNode);

        if (!hasTarget)
        {
            return;
        }

        Vector2 target = targetNode.GlobalPosition;

        foreach (IPosition2dProcessor position2dProcessor in _position2dProcessors)
        {
            target = position2dProcessor.Process(dt, camera2D, target);
        }

        Vector2 newPosition;

        if (previousStateValid)
        {
            float velocity = _velocity * dt;
        
            newPosition = camera2D.GlobalPosition.Lerp(target, velocity);   
        }
        else
        {
            newPosition = targetNode.GlobalPosition;
        }
        
        camera2D.GlobalPosition = newPosition;
    }

    public void SetTarget(Node2D node2D)
    {
        _target = node2D;
    }

    public void SetVelocity(float velocity)
    {
        _velocity = velocity;
    }

    public void AddPositionProcessors(IPosition2dProcessor position2dProcessor)
    {
        _position2dProcessors.Add(position2dProcessor);
    }
}