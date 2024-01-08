using Godot;
using GUtils.Randomization.Generators;
using GUtilsGodot.Randomization.Extensions;

namespace GUtilsGodot.Cameras.Behaviours;

public sealed class ShakeCamera2dBehaviour : ICamera2dBehaviour
{
    readonly IRandomGenerator _randomGenerator;
    
    float _attenuationStrenght = 1f;
    float _currentShake = 0f;

    public ShakeCamera2dBehaviour(
        IRandomGenerator randomGenerator
        )
    {
        _randomGenerator = randomGenerator;
    }
        
    public void Tick(float dt, bool previousStateValid, Camera2D camera2D)
    {
        if (_currentShake <= 0)
        {
            return;
        }

        Vector2 randomDirection = _randomGenerator.NewVector2(-Vector2.One, Vector2.One);
        Vector2 newPosition = randomDirection * _currentShake;
        
        _currentShake = Mathf.Max(0, _currentShake - (dt * _attenuationStrenght));

        camera2D.Position += newPosition;
    }

    public void ApplyImpulse(float strength)
    {
        _currentShake = strength;
    }

    public void SetAttenuationStrenght(float decreaseFactor)
    {
        _attenuationStrenght = decreaseFactor;
    }
}