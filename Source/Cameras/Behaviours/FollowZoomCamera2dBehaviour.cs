using Godot;
using GUtilsGodot.Extensions;

namespace GUtilsGodot.Cameras.Behaviours;

public sealed class FollowZoomCamera2dBehaviour : ICamera2dBehaviour
{
    float _targetZoom = 1f;
    float _velocity = 5f;
    
    public void Tick(float dt, bool previousStateValid, Camera2D camera2D)
    {
        float velocity = _velocity * dt;

        float newZoom;
        
        if (previousStateValid)
        {
            newZoom = Mathf.Lerp(camera2D.Zoom.X, _targetZoom, velocity);
        }
        else
        {
            newZoom = _targetZoom;
        }
        
        camera2D.SetZoom(newZoom);
    }

    public void SetTargetZoom(float zoom)
    {
        _targetZoom = zoom;
    }
    
    public void SetVelocity(float velocity)
    {
        _velocity = velocity;
    }
}