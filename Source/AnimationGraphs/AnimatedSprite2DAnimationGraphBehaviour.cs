using Godot;
using GUtils.AnimationGraphs;

namespace GUtilsGodot.AnimationGraphs;

public sealed class AnimatedSprite2DAnimationGraphBehaviour : AnimationGraphBehaviour
{
    readonly AnimatedSprite2D _animatedSprite2D;
    readonly string _animation;
    
    public AnimatedSprite2DAnimationGraphBehaviour(
        AnimatedSprite2D animatedSprite2D, 
        string animation
        )
    {
        _animatedSprite2D = animatedSprite2D;
        _animation = animation;
    }
    
    public override void Enter()
    {
        _animatedSprite2D.Play(_animation);
    }

    public override void Tick()
    {
        Completed = !_animatedSprite2D.IsPlaying();
    }

    public override void Exit()
    {
        
    }
}