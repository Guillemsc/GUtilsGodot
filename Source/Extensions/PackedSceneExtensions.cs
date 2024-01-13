using Godot;
using GUtils.Optionals;

namespace GUtilsGodot.Extensions;

public static class PackedSceneExtensions
{
    public static Optional<T> SafeInstantiate<T>(
        this PackedScene packedScene, 
        PackedScene.GenEditState editState = PackedScene.GenEditState.Disabled
        ) where T : class
    {
        T? result = packedScene.InstantiateOrNull<T>(editState);
        
        return Optional<T>.Some(result);
    }
}