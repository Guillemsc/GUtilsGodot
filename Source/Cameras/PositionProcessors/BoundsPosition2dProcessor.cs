using Godot;
using GUtils.Optionals;
using GUtilsGodot.Extensions;
using GUtilsGodot.Rects.Nodes;

namespace GUtilsGodot.Cameras.PositionProcessors;

public sealed class BoundsPosition2dProcessor : IPosition2dProcessor
{
    Optional<Rect2dNode> _boundsRect;
    
    public Vector2 Process(float dt, Camera2D camera2D, Vector2 vector2)
    {
        bool hasBoundsRect = _boundsRect.TryGet(out Rect2dNode rect2dNode);

        if (!hasBoundsRect)
        {
            return vector2;
        }

        Vector2 cameraSize = camera2D.GetViewportRect().Size;
        Vector2 cameraHalfSize = cameraSize * 0.5f;
        
        Rect2 rect = rect2dNode.GetGlobalRect();
        
        Vector2 min = rect.GetMinPoint();
        Vector2 max = rect.GetMaxPoint();
        Vector2 center = rect.GetCenter();

        if (rect.Size.X < cameraSize.X)
        {
            min.X = center.X;
            max.X = center.X;
        }
        else
        {
            min.X += cameraHalfSize.X;
            max.X -= cameraHalfSize.X;
        }
        
        if (rect.Size.Y < cameraSize.Y)
        {
            min.Y = center.Y;
            max.Y = center.Y;
        }
        else
        {
            min.Y += cameraHalfSize.Y;
            max.Y -= cameraHalfSize.Y;
        }

        vector2.X = Mathf.Clamp(vector2.X, min.X, max.X);
        vector2.Y = Mathf.Clamp(vector2.Y, min.Y, max.Y);

        return vector2;
    }
    
    public void SetBounds(Rect2dNode bounds)
    {
        _boundsRect = bounds;
    }
}