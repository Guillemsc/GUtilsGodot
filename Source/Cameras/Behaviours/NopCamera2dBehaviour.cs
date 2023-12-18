using Godot;

namespace GUtilsGodot.Cameras.Behaviours;

public sealed class NopCamera2dBehaviour : ICamera2dBehaviour
{
    public static readonly NopCamera2dBehaviour Instance = new();
    
    public void Tick(float dt, Camera2D camera2D) { }
}