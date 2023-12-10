using Godot;
using GUtils.Randomization.Generators;

namespace GUtilsGodot.Randomization.Extensions;

public static class RandomGeneratorExtensions
{
    /// <summary>
    /// Creates a new <see cref="Vector2"/> using the provided <see cref="IRandomGenerator"/> in
    /// the range [float.MinValue, float.MaxValue]
    /// </summary>
    /// <param name="randomGenerator">The random number generator to use.</param>
    /// <returns>A new instance of <see cref="Vector2"/> with randomly generated x and y values
    /// in the range [float.MinValue, float.MaxValue]</returns>
    public static Vector2 NewVector2(this IRandomGenerator randomGenerator)
    {
        return new Vector2(randomGenerator.NewFloat(), randomGenerator.NewFloat());
    }
    
    /// <summary>
    /// Creates a new <see cref="Vector2"/> using the provided <see cref="IRandomGenerator"/> and
    /// specified range for x and y values.
    /// </summary>
    /// <param name="randomGenerator">The random number generator to use.</param>
    /// <param name="minInclusive">The minimum inclusive values for x and y.</param>
    /// <param name="maxInclusive">The maximum inclusive values for x and y.</param>
    /// <returns>A new instance of <see cref="Vector2"/> with randomly generated x and y values
    /// within the specified range.</returns>
    public static Vector2 NewVector2(this IRandomGenerator randomGenerator, Vector2 minInclusive, Vector2 maxInclusive)
    {
        return new Vector2(
            randomGenerator.NewFloat(minInclusive.X, maxInclusive.X),
            randomGenerator.NewFloat(minInclusive.Y, maxInclusive.Y)
        );
    }
}