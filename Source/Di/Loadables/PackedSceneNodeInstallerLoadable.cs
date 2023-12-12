using Godot;
using GUtils.Di.Installers;
using GUtils.Disposing.Disposables;
using GUtils.Loadables;
using GUtilsGodot.Di.Installers;

namespace GUtilsGodot.Di.Loadables;

public sealed class PackedSceneNodeInstallerLoadable : ILoadable<IInstaller>
{
    readonly PackedScene _packedScene;
    readonly Node _parent;
    
    public PackedSceneNodeInstallerLoadable(PackedScene packedScene, Node parent)
    {
        _packedScene = packedScene;
        _parent = parent;
    }
    
    public IDisposable<IInstaller> Load()
    {
        NodeInstaller nodeInstaller = _packedScene.Instantiate<NodeInstaller>();
        _parent.AddChild(nodeInstaller);

        IDisposable<IInstaller> disposable = new CallbackDisposable<IInstaller>(nodeInstaller, o =>
        {
            nodeInstaller.QueueFree();
        });

        return disposable;
    }
}