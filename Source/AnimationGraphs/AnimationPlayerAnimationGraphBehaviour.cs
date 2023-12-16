using Godot;
using GUtils.AnimationGraphs;

namespace GUtilsGodot.AnimationGraphs;

public sealed class AnimationPlayerAnimationGraphBehaviour : AnimationGraphBehaviour
{
    readonly AnimationPlayer _animationPlayer;
    readonly string _animation;
    
    public AnimationPlayerAnimationGraphBehaviour(
        AnimationPlayer animationPlayer, 
        string animation
    )
    {
        _animationPlayer = animationPlayer;
        _animation = animation;
    }
    
    public override void Enter()
    {
        _animationPlayer.Play(_animation);
    }

    public override void Tick()
    {
        Completed = !_animationPlayer.IsPlaying();
    }

    public override void Exit()
    {
        
    }
}