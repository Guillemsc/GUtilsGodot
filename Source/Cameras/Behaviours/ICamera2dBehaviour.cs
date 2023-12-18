using Godot;

namespace GUtilsGodot.Cameras.Behaviours;

public interface ICamera2dBehaviour
{
    void Tick(float dt, bool previousStateValid, Camera2D camera2D);
}