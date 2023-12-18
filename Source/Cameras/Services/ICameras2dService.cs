using Godot;
using GUtils.Optionals;
using GUtilsGodot.Cameras.Behaviours;
using Rect2dNode = GUtilsGodot.Rects.Nodes.Rect2dNode;

namespace GUtilsGodot.Cameras.Services;

public interface ICameras2dService
{
    Camera2D MainCamera { get; }

    void AddBehaviour(ICamera2dBehaviour behaviour);
    void RemoveBehaviour(ICamera2dBehaviour behaviour);
    Optional<T> GetBehaviour<T>() where T : ICamera2dBehaviour;
    void ClearBehaviours();
}