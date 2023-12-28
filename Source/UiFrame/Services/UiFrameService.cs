using System.Collections.Generic;
using Godot;
using GUtils.ActiveSources;
using GUtilsGodot.Extensions;
using GUtilsGodot.UiFrame.Enums;

namespace GUtilsGodot.UiFrame.Services
{
    /// <inheritdoc cref="IUiFrameService" />
    public partial class UiFrameService : Node, IUiFrameService
    {
        readonly Dictionary<UiFrameLayer, Node> _layers = new();
        readonly Dictionary<Node, Node> _originalParents = new();

        public ISingleActiveSource InteractableActiveSource { get; } = new SingleActiveSource();

        public override void _Ready()
        {
            InteractableActiveSource.OnActiveChanged += x => { };
            CreateLayers();
        }

        public void CreateLayers()
        {
            if (_layers.Count > 0)
            {
                return;
            }
            
            foreach (UiFrameLayer layer in UiFrameLayerInfo.Values)
            {
                string layerName = layer.ToString();

                Control newLayer = new Control();
                newLayer.Name = layerName;
                newLayer.MouseFilter = Control.MouseFilterEnum.Ignore;
                AddChild(newLayer);

                newLayer.SetAnchorsPreset(Control.LayoutPreset.FullRect, true);

                _layers.Add(layer, newLayer);
            }
        }
        
        public void Register(Node node, UiFrameLayer layer = UiFrameLayer.Default)
        {
            CreateLayers();

            bool layerFound = _layers.TryGetValue(layer, out Node? layerParent);

            if (!layerFound)
            {
                // DebugOnlyUnityLogger.Instance.Log(
                //     Logging.Enums.LogType.Error,
                //     "Could not register {0} at UiFrameService. Layer {1} could not be found.",
                //     targetTransform.name,
                //     layer
                // );
                return;
            }

            _originalParents.Add(node, node.GetParent());
            
            node.SetParent(layerParent!);
            node.SetAsFirstSibling();
        }

        public void Unregister(Node node)
        {
            bool found = _originalParents.TryGetValue(node, out Node? originalParent);

            if(!found)
            {
                return;
            }

            if (originalParent == null)
            {
                // DebugOnlyUnityLogger.Instance.Log(
                //     Logging.Enums.LogType.Error,
                //     "Original parent from {0} was null, while trying to unregister from UiFrameService.",
                //     targetTransform.name
                // );
                return;
            }
            
            node.SetParent(originalParent);
            
            _originalParents.Remove(originalParent);
        }

        public void MoveToBackground(Node node)
        {
            bool registered = _originalParents.ContainsKey(node);

            if (!registered)
            {
                return;
            }
            
            node.SetAsFirstSibling();
        }

        public void MoveToForeground(Node node)
        {
            bool registered = _originalParents.ContainsKey(node);

            if (!registered)
            {
                return;
            }
            
            node.SetAsLastSibling();
        }

        public void MoveBehindForeground(Node node)
        {
            bool registered = _originalParents.ContainsKey(node);

            if (!registered)
            {
                return;
            }

            Node parent = node.GetParent();

            if (parent == null)
            {
                return;
            }
            
            int index = parent.GetChildren().Count - 2;

            parent.SetSiblingIndex(index);
        }
    }
}
