using System.Numerics;

namespace GUtilsGodot.Extensions;

public static class SystemVector2Extensions
{
    public static Godot.Vector2 ToGodotVector(this Vector2 vector2)
    {
        return new Godot.Vector2(vector2.X, vector2.Y);
    }
}