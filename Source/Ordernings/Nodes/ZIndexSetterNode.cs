using Godot;
using GUtilsGodot.Ordernings.Configurations;

namespace GUtilsGodot.Ordernings;

public partial class ZIndexSetterNode : Node2D
{
    [Export] public Node2D? NodeToSet;
    [Export] public ZIndexSetterConfiguration? Configuration;
    [Export] public int Offset;
    
    public override void _Ready()
    {
        NodeToSet!.ZIndex = Configuration!.ZIndex + Offset;
    }
}