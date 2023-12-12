using Godot;
using GUtils.Di.Builder;
using GUtils.Di.Installers;

namespace GUtilsGodot.Di.Installers;

public partial class NodeInstaller : Node, IInstaller
{
    public virtual void Install(IDiContainerBuilder builder){}
}