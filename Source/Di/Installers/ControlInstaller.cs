using Godot;
using GUtils.Di.Builder;
using GUtils.Di.Installers;

namespace GUtilsGodot.Di.Installers;

public partial class ControlInstaller : Control, IInstaller
{
    public virtual void Install(IDiContainerBuilder builder){}
}