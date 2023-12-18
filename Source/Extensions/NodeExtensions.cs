using Godot;
using GUtils.Optionals;

namespace GUtilsGodot.Extensions;

public static class NodeExtensions
{
    public static Optional<T> GetNodeOnParentHierarchy<T>(
        this Node node,
        bool includeCurrent = true
        ) 
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

    public static void RemoveParent(this Node node)
    {
        Node parent = node.GetParent();

        if (parent == null)
        {
            return;
        }
        
        parent.RemoveChild(node);
    }

    public static void SetParent(this Node node, Node parent)
    {
        node.RemoveParent();
        parent.AddChild(node);
    }
    
    public static void SetSiblingIndex(this Node node, int index)
    {
        Node parent = node.GetParent();

        if (parent == null)
        {
            return;
        }

        int childsCount = parent.GetChildren().Count;
        int finalIndex = GUtils.Extensions.MathExtensions.Clamp(index, 0, childsCount);
        
        parent.MoveChild(node, finalIndex);
    }

    public static void SetAsFirstSibling(this Node node)
    {
        node.SetSiblingIndex(0);
    }
    
    public static void SetAsLastSibling(this Node node)
    {
        node.SetSiblingIndex(int.MaxValue);
    }
}