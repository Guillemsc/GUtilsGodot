using Godot;
using GUtils.Optionals;

namespace GUtilsGodot.Extensions;

public static class KinematicCollision2DExtensions
{
    public static Optional<Node2D> GetNode(this KinematicCollision2D kinematicCollision2D)
    {
        GodotObject collider = kinematicCollision2D.GetCollider();
        
        if (collider is not Node2D node2D)
        {
            return Optional<Node2D>.None;
        }

        return node2D;
    }
}