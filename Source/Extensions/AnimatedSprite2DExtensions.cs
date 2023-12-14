using System;
using System.Threading;
using System.Threading.Tasks;
using Godot;

namespace GUtilsGodot.Extensions;

public static class AnimatedSprite2DExtensions
{
    public static async Task AwaitCompletition(this AnimatedSprite2D animatedSprite2D, CancellationToken cancellationToken)
    {
        while (animatedSprite2D.IsPlaying())
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await TaskExtensions.GodotYield();
        }
    }
    
    public static void Play<T>(this AnimatedSprite2D animatedSprite2D, T animationName) where T : Enum
    {
        animatedSprite2D.Play(animationName.ToString());
    }
}