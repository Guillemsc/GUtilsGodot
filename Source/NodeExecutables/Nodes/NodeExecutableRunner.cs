using Godot;

namespace GUtilsGodot.NodeExecutables.Nodes;

public partial class NodeExecutableRunner : Node
{
    [Export] public NodeExecutable[]? NodeExecutables;

    public override void _Ready()
    {
        foreach (NodeExecutable nodeExecutable in NodeExecutables!)
        {
            nodeExecutable.Execute();
        }
    }
}