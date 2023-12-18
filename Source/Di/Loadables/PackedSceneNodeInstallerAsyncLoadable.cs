using System;
using System.Threading;
using System.Threading.Tasks;
using Godot;
using GUtils.Di.Installers;
using GUtils.DiscriminatedUnions;
using GUtils.Disposing.Disposables;
using GUtils.Loadables;
using GUtils.Types;
using GUtilsGodot.Di.Installers;
using GUtilsGodot.Extensions;

namespace GUtilsGodot.Di.Loadables;

public sealed class PackedSceneNodeInstallerAsyncLoadable : IAsyncLoadable<IInstaller>
{
    readonly PackedScene _packedScene;
    readonly Node _parent;

    public PackedSceneNodeInstallerAsyncLoadable(
        PackedScene packedScene,
        Node parent
    )
    {
        _packedScene = packedScene;
        _parent = parent;
    }

    public async Task<IAsyncDisposable<IInstaller>> Load(CancellationToken ct)
    {
        OneOf<PackedScene, ErrorMessage> result = await ResourceLoaderExtensions.LoadAsync<PackedScene>(
            _packedScene.ResourcePath
        );

        if (result.HasSecond)
        {
            throw new Exception(result.UnsafeGetSecond().Message);
        }

        PackedScene packedScene = result.UnsafeGetFirst();

        NodeInstaller nodeInstaller = packedScene.Instantiate<NodeInstaller>();
        _parent.AddChild(nodeInstaller);

        IAsyncDisposable<IInstaller> disposable = new CallbackAsyncDisposable<IInstaller>(
            nodeInstaller,
            _ =>
            {
                nodeInstaller.QueueFree();
                return ValueTask.CompletedTask;
            });

        return disposable;
    }
}