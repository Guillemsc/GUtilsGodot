using Godot;
using GUtilsGodot.Extensions;

namespace GUtilsGodot.Cameras.Behaviours;

public sealed class FollowZoomCamera2dBehaviour : ICamera2dBehaviour
{
    float _targetZoom = 1f;
    float _velocity = 5f;
    
    public void Tick(float dt, Camera2D camera2D)
    {
        float velocity = _velocity * dt;

        float newZoom = Mathf.Lerp(camera2D.Zoom.X, _targetZoom, velocity);
        
        camera2D.SetZoom(newZoom);
    }

    public void SetTargetZoom(float zoom)
    {
        _targetZoom = zoom;
    }
}