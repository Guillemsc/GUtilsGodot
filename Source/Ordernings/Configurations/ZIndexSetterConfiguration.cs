using Godot;

namespace GUtilsGodot.Ordernings.Configurations;

[GlobalClass]
public partial class ZIndexSetterConfiguration : Resource
{
    [Export] public int ZIndex;
}