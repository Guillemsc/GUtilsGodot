using Godot;
using GUtils.Optionals;
using GUtilsGodot.Extensions;

namespace GUtilsGodot.Cameras.Behaviours;

public sealed class BoundsConfinementCamera2dBehaviour : ICamera2dBehaviour
{
    Optional<Rect2> _boundsRect;
    
    public void Tick(float dt, bool previousStateValid, Camera2D camera2D)
    {
        bool hasBoundsRect = _boundsRect.TryGet(out Rect2 rect);

        if (!hasBoundsRect)
        {
            return;
        }

        Vector2 position = camera2D.GlobalPosition;
        Vector2 viewportSize = camera2D.GetGameViewportRect().Size;

        bool insideBounds = Camera2DExtensions.IsCameraInsideBounds(position, viewportSize, rect);

        if (insideBounds)
        {
            return;
        }

        camera2D.GlobalPosition = Camera2DExtensions.GetCameraPositionInsideBounds(position, viewportSize, rect);
    }
    
    public void SetBounds(Rect2 bounds)
    {
        _boundsRect = bounds;
    }
}