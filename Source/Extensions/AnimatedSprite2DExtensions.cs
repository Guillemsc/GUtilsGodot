using System;
using Godot;

namespace GUtilsGodot.Extensions;

public static class AnimatedSprite2DExtensions
{
    public static void Play<T>(this AnimatedSprite2D animatedSprite2D, T animationName) where T : Enum
    {
        animatedSprite2D.Play(animationName.ToString());
    }
}