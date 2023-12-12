using Godot;

namespace GUtilsGodot.Roots.Services;

public sealed class RootNodeService : IRootNodeService
{
    public Node Root { get; }
    
    public RootNodeService(Node root)
    {
        Root = root;
    }
}