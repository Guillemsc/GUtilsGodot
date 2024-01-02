using System;
using System.Threading;
using System.Threading.Tasks;
using Godot;

namespace GUtilsGodot.Extensions;

public static class AnimationPlayerExtensions
{
    public static void ConnectAnimationFinished(
        this AnimationPlayer animationPlayer, 
        Action<StringName> action
        )
    {
        animationPlayer.Connect("animation_finished", Callable.From(action));
    }
    
    public static void DisconnectAnimationFinished(
        this AnimationPlayer animationPlayer, 
        Action<StringName> action
    )
    {
        animationPlayer.Disconnect("animation_finished", Callable.From(action));
    }
    
    public static async Task AwaitCompletition(this AnimationPlayer animationPlayer, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested && 
               animationPlayer.IsInstanceValid() &&
               animationPlayer.IsPlaying()
               )
        {
            await TaskExtensions.GodotYield();
        }
    }

    public static void Reset(this AnimationPlayer animationPlayer)
    {
        animationPlayer.Seek(0);
    }
    
    public static Task PlayAndAwaitCompletition(
        this AnimationPlayer animationPlayer, 
        string animationName, 
        bool instantly, 
        CancellationToken cancellationToken
        )
    {
        animationPlayer.Play(animationName);

        if (instantly)
        {
            animationPlayer.Seek(animationPlayer.CurrentAnimationLength);
            return Task.CompletedTask;
        }

        return animationPlayer.AwaitCompletition(cancellationToken);
    }
    
    public static Task PlayAndAwaitCompletition(
        this AnimationPlayer animationPlayer, 
        string animationName, 
        CancellationToken completeToken,
        CancellationToken cancellationToken
    )
    {
        animationPlayer.Play(animationName);
        
        completeToken.Register(() => animationPlayer.Seek(animationPlayer.CurrentAnimationLength));

        return animationPlayer.AwaitCompletition(cancellationToken);
    }
    
    public static void Play<T>(this AnimationPlayer animationPlayer, T animationName) where T : Enum
    {
        animationPlayer.Play(animationName.ToString());
    }
}