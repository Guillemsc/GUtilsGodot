using Godot;

namespace GUtilsGodot.NodeExecutables.Nodes;

public partial class CanvasItemSetVisibleNodeExecutable : NodeExecutable
{
    [Export] public CanvasItem? CanvasItem;
    [Export] public bool Visible;
    
    public override void Execute()
    {
        CanvasItem!.Visible = Visible;
    }
}