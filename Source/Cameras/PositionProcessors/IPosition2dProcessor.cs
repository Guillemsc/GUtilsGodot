using Godot;

namespace GUtilsGodot.Cameras.PositionProcessors;

public interface IPosition2dProcessor
{
    Vector2 Process(float dt, Camera2D camera2D, Vector2 position);
}