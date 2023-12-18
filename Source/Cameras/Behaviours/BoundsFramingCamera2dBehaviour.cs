using Godot;
using GUtils.Optionals;
using GUtilsGodot.Extensions;
using GUtilsGodot.Rects.Nodes;

namespace GUtilsGodot.Cameras.Behaviours;

public sealed class BoundsFramingCamera2dBehaviour : ICamera2dBehaviour
{
    Optional<Rect2dNode> _boundsRect;
    
    public void Tick(float dt, Camera2D camera2D)
    {
        bool hasBoundsRect = _boundsRect.TryGet(out Rect2dNode rect2dNode);

        if (!hasBoundsRect)
        {
            return;
        }
        
        Vector2 cameraViewport = camera2D.GetViewportRect().Size;
        
        float horizontalAspect = cameraViewport.X / rect2dNode.Size.X;
        float verticalAspect = cameraViewport.Y / rect2dNode.Size.Y;
        
        float zoom = verticalAspect < horizontalAspect ? verticalAspect : horizontalAspect;
        
        camera2D.SetZoom(zoom);
        camera2D.GlobalPosition = rect2dNode.GlobalPosition;
    }

    public void SetBounds(Rect2dNode bounds)
    {
        _boundsRect = bounds;
    }
}