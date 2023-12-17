using System;
using Godot;

namespace GUtilsGodot.Extensions;

public static class MathExtensions
{
    /// <summary>
    /// Calculates the direction vector given an angle in degrees.
    /// </summary>
    public static Vector2 GetDirectionFromAngle(float angleDegrees)
    {
        return new Vector2(
            (float)Math.Cos(angleDegrees * GUtils.Extensions.MathExtensions.Deg2Rad),
            (float)Math.Sin(angleDegrees * GUtils.Extensions.MathExtensions.Deg2Rad)
        );
    }

    /// <summary>
    /// Calculates the angle in degrees given a direction vector.
    /// </summary>
    public static float GetAngleFromDirection(Vector2 direction)
    {
        return (float)Math.Atan2(direction.Y, direction.X) * GUtils.Extensions.MathExtensions.Rad2Deg;
    }
}