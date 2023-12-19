using Godot;
using GUtils.Optionals;
using GUtilsGodot.Extensions;
using GUtilsGodot.Rects.Nodes;

namespace GUtilsGodot.Cameras.PositionProcessors;

public sealed class BoundsPosition2dProcessor : IPosition2dProcessor
{
    Optional<Rect2dNode> _boundsRect;
    
    public Vector2 Process(float dt, Camera2D camera2D, Vector2 position)
    {
        bool hasBoundsRect = _boundsRect.TryGet(out Rect2dNode rect2dNode);

        if (!hasBoundsRect)
        {
            return position;
        }

        Rect2 rect = rect2dNode.GetGlobalRect();
        Vector2 viewportSize = camera2D.GetGameViewportRect().Size;

        return Camera2DExtensions.GetCameraPositionInsideBounds(position, viewportSize, rect);
    }
    
    public void SetBounds(Rect2dNode bounds)
    {
        _boundsRect = bounds;
    }
}