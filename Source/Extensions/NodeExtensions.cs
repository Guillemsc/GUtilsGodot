using Godot;
using GUtils.Optionals;

namespace GUtilsGodot.Extensions;

public static class NodeExtensions
{
    public static Optional<T> GetNodeOnParentHierarchy<T>(
        this Node node,
        bool includeCurrent = true
        ) where T : Node
    {
        Node? checkingNode = includeCurrent ? node : node.GetParent();

        while(checkingNode != null)
        {
            if (checkingNode is T castedNode)
            {
                return castedNode;
            }
            
            checkingNode = checkingNode.GetParent();
        }
        
        return Optional<T>.None;
    }
}