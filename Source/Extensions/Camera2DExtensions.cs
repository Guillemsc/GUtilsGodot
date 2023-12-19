using Godot;

namespace GUtilsGodot.Extensions;

public static class Camera2DExtensions
{
    public static void SetZoom(this Camera2D camera2D, float zoom)
    {
        camera2D.Zoom = new Vector2(zoom, zoom);
    }
    
    public static Rect2 GetGameViewportRect(this Camera2D camera2D)
    {
        Rect2 viewportRect = camera2D.GetViewportRect();
        Vector2 cameraSize = viewportRect.Size / camera2D.Zoom;
        viewportRect.Size = cameraSize;
        return viewportRect;
    }

    public static Vector2 GetCameraPositionInsideBounds(this Camera2D camera2D, Rect2 bounds)
    {
        return GetCameraPositionInsideBounds(camera2D.GlobalPosition, camera2D.GetGameViewportRect().Size, bounds);
    }
    
    public static Vector2 GetCameraPositionInsideBounds(Vector2 cameraPosition, Vector2 viewportSize, Rect2 bounds)
    {
        Vector2 ret = cameraPosition;
        
        Vector2 cameraSize = viewportSize;
        Vector2 cameraHalfSize = cameraSize * 0.5f;
        
        Vector2 min = bounds.GetMinPoint();
        Vector2 max = bounds.GetMaxPoint();
        Vector2 center = bounds.GetCenter();

        if (bounds.Size.X < cameraSize.X)
        {
            min.X = center.X;
            max.X = center.X;
        }
        else
        {
            min.X += cameraHalfSize.X;
            max.X -= cameraHalfSize.X;
        }
        
        if (bounds.Size.Y < cameraSize.Y)
        {
            min.Y = center.Y;
            max.Y = center.Y;
        }
        else
        {
            min.Y += cameraHalfSize.Y;
            max.Y -= cameraHalfSize.Y;
        }
        
        ret.X = Mathf.Clamp(ret.X, min.X, max.X);
        ret.Y = Mathf.Clamp(ret.Y, min.Y, max.Y);

        return ret;
    }
    
    public static bool IsCameraInsideBounds(Vector2 cameraPosition, Vector2 viewportSize, Rect2 bounds)
    {
        Vector2 cameraSize = viewportSize;
        Vector2 cameraHalfSize = cameraSize * 0.5f;
        
        Vector2 min = bounds.GetMinPoint();
        Vector2 max = bounds.GetMaxPoint();

        Vector2 viewportMin = cameraPosition - cameraHalfSize;
        Vector2 viewportMax = cameraPosition + cameraHalfSize;

        if (min.X > viewportMin.X)
        {
            return false;
        }
        
        if (min.Y > viewportMin.Y)
        {
            return false;
        }
        
        if (max.X < viewportMax.X)
        {
            return false;
        }
        
        if (max.Y < viewportMax.Y)
        {
            return false;
        }

        return true;
    }
}