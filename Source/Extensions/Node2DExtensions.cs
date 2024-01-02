using Godot;

namespace GUtilsGodot.Extensions;

public static class Node2DExtensions
{
    public static void SetPositionX(this Node2D node2D, float set)
    {
        Vector2 position = node2D.Position;
        position.X = set;
        node2D.Position = position;
    }
    
    public static void SetPositionY(this Node2D node2D, float set)
    {
        Vector2 position = node2D.Position;
        position.Y = set;
        node2D.Position = position;
    }
    
    public static void SetGlobalPositionX(this Node2D node2D, float set)
    {
        Vector2 position = node2D.GlobalPosition;
        position.X = set;
        node2D.GlobalPosition = position;
    }
    
    public static void SetGlobalPositionY(this Node2D node2D, float set)
    {
        Vector2 position = node2D.GlobalPosition;
        position.Y = set;
        node2D.GlobalPosition = position;
    }
}