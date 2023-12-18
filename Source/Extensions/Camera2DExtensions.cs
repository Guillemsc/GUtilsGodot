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
}