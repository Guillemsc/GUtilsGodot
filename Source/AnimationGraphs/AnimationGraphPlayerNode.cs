using Godot;
using GUtils.AnimationGraphs;

namespace GUtilsGodot.AnimationGraphs;

public partial class AnimationGraphPlayerNode : Node
{
    IAnimationGraphPlayer _animationGraphPlayer = NopAnimationGraphPlayer.Instance;
    bool _firstTick = true;
    
    public sealed override void _Process(double delta)
    {
        if (_firstTick)
        {
            _firstTick = false;
            
            _animationGraphPlayer = BuildPlayer();
        }
        
        _animationGraphPlayer.Tick();
    }

    protected virtual IAnimationGraphPlayer BuildPlayer()
        => NopAnimationGraphPlayer.Instance;

}