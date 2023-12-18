using Godot;

namespace GUtilsGodot.Extensions;

public static class Rect2Extensions
{
    public static Vector2 GetMinPoint(this Rect2 rect2)
    {
        Vector2 center = rect2.GetCenter();
        Vector2 min = center - rect2.Size * 0.5f;
        return min;
    }
    
    public static Vector2 GetMaxPoint(this Rect2 rect2)
    {
        Vector2 center = rect2.GetCenter();
        Vector2 max = center + rect2.Size * 0.5f;
        return max;
    }
}