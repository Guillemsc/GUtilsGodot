using System;
using System.Threading;
using System.Threading.Tasks;
using Godot;

namespace GUtilsGodot.Extensions;

public static class AnimatedSprite2DExtensions
{
    public static async Task AwaitCompletition(this AnimatedSprite2D animatedSprite2D, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested && animatedSprite2D.IsPlaying())
        {
            await TaskExtensions.GodotYield();
        }
    }
    
    public static void Play<T>(this AnimatedSprite2D animatedSprite2D, T animationName) where T : Enum
    {
        animatedSprite2D.Play(animationName.ToString());
    }
    
    public static bool IsPlaying<T>(this AnimatedSprite2D animatedSprite2D, T animationName) where T : Enum
    {
        return string.Equals(animatedSprite2D.Animation, animationName.ToString());
    }
}