using System;
using Godot;
using GUtils.Extensions;
using GUtils.Time.TimeContexts;

namespace GUtilsGodot.Time.TimeContexts;

public partial class GodotTimeContext : Node, ITimeContext
{
    float _timeScale = 1f;
    
    public TimeSpan Time { get; private set; }

    public float TimeScale
    {
        get => _timeScale;
        set
        {
            _timeScale = value;
            OnTimeScaleChanged?.Invoke();
        }
        
    }
    
    public float DeltaTime { get; private set; }
    
    public event Action? OnTimeScaleChanged;
    
    public override void _Process(double delta)
    {
        DeltaTime = (float)delta * TimeScale;
        Time += DeltaTime.ToSeconds();
    }
}