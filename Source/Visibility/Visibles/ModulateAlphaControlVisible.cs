using System.Threading;
using System.Threading.Tasks;
using Godot;
using GUtils.Visibility.Visibles;

namespace GUtilsGodot.Visibility.Visibles;

public sealed class ModulateAlphaControlVisible : IVisible
{
    readonly Control _control;
    
    public ModulateAlphaControlVisible(Control control)
    {
        _control = control;
    }
    
    public Task SetVisible(bool visible, bool instantly, CancellationToken cancellationToken)
    {
        float alpha = visible ? 1f : 0f;
        
        _control.Modulate = new Color(_control.Modulate, alpha);

        return Task.CompletedTask;
    }
}