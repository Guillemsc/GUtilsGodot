using Godot;
using GUtils.Di.Builder;
using GUtils.Di.Contexts;
using GUtils.Di.Installers;
using GUtils.Disposing.Disposables;
using GUtils.Types;

namespace GUtilsGodot.Di.Contexts;

public partial class AutoInstallControlDiContext : Control
{
    public sealed override void _Ready()
    {
        IDiContext<Nothing> diContext = new DiContext<Nothing>();
        diContext.AddInstaller(Install);
        diContext.AddInstaller(new CallbackInstaller(b => b.Bind<Nothing>().FromInstance(Nothing.Instance)));
        IDisposable<Nothing> disposable = diContext.Install();
    }
    
    public virtual void Install(IDiContainerBuilder builder){}
}