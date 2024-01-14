using Godot;
using GUtilsGodot.Ordernings.Configurations;

namespace GUtilsGodot.Ordernings;

public partial class ZIndexArraySetterNode : Node2D
{
    [Export] public Node2D[]? NodesToSet;
    [Export] public ZIndexSetterConfiguration? Configuration;
    [Export] public int Offset;
    
    public override void _Ready()
    {
        foreach (Node2D node in NodesToSet!)
        {
            node!.ZIndex = Configuration!.ZIndex + Offset;
        }
    }
}