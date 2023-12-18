using Godot;

namespace GUtilsGodot.Extensions;

public static class Camera2DExtensions
{
    public static void SetZoom(this Camera2D camera2D, float zoom)
    {
        camera2D.Zoom = new Vector2(zoom, zoom);
    }
}