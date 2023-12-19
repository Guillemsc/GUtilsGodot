using Godot;
using GUtils.Optionals;
using GUtilsGodot.Extensions;
using GUtilsGodot.Rects.Nodes;

namespace GUtilsGodot.Cameras.Behaviours;

public sealed class BoundsConfinementCamera2dBehaviour : ICamera2dBehaviour
{
    Optional<Rect2dNode> _boundsRect;
    
    public void Tick(float dt, bool previousStateValid, Camera2D camera2D)
    {
        bool hasBoundsRect = _boundsRect.TryGet(out Rect2dNode rect2dNode);

        if (!hasBoundsRect)
        {
            return;
        }

        Vector2 position = camera2D.GlobalPosition;
        Rect2 rect = rect2dNode.GetGlobalRect();
        Vector2 viewportSize = camera2D.GetGameViewportRect().Size;

        bool insideBounds = Camera2DExtensions.IsCameraInsideBounds(position, viewportSize, rect);

        if (insideBounds)
        {
            return;
        }

        camera2D.GlobalPosition = Camera2DExtensions.GetCameraPositionInsideBounds(position, viewportSize, rect);
    }
    
    public void SetBounds(Rect2dNode bounds)
    {
        _boundsRect = bounds;
    }
}