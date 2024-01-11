using System.Collections.Generic;
using Godot;

namespace GUtilsGodot.Extensions;

public static class RayCast2DExtensions
{
    public static bool IsAnyColliding(this IReadOnlyList<RayCast2D> list)
    {
        foreach (RayCast2D rayCast in list)
        {
            bool collides = rayCast.IsColliding();

            if (collides)
            {
                return true;
            }
        }

        return false;
    }
}