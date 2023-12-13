using System.Threading;
using System.Threading.Tasks;
using Godot;
using GUtils.Visibility.Visibles;
using GUtilsGodot.Extensions;

namespace GUtilsGodot.Visibility.Visibles;

public sealed class AnimationPlayerVisible : IVisible
{
    readonly AnimationPlayer _animationPlayer;
    readonly string _showAnimationName;
    readonly string _hideAnimationName;

    bool _currentState;
    
    public AnimationPlayerVisible(
        AnimationPlayer animationPlayer, 
        string showAnimationName, 
        string hideAnimationName, 
        bool initialState = true
        )
    {
        _animationPlayer = animationPlayer;
        _showAnimationName = showAnimationName;
        _hideAnimationName = hideAnimationName;
        _currentState = initialState;
    }
    
    public Task SetVisible(bool visible, bool instantly, CancellationToken cancellationToken)
    {
        bool canChangeState = _currentState != visible;

        if (!canChangeState)
        {
            return Task.CompletedTask;
        }

        _currentState = visible;
        
        string animationToPlay = visible ? _showAnimationName : _hideAnimationName;
        
        _animationPlayer.Play(animationToPlay);

        if (instantly)
        {
            _animationPlayer.Seek(_animationPlayer.CurrentAnimationLength);
        }

        return _animationPlayer.AwaitCompletition(cancellationToken);
    }
}