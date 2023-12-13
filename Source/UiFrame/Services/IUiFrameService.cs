using Godot;
using GUtils.ActiveSources;
using GUtilsGodot.UiFrame.Enums;

namespace GUtilsGodot.UiFrame.Services
{
    /// <summary>
    /// Represents a service for managing UI layers.
    /// Useful for controlling which UI is on top, and which is behind.
    /// </summary>
    public interface IUiFrameService
    {
        ISingleActiveSource InteractableActiveSource { get; }

        /// <summary>
        /// Creates the layers for UI frames. This means creating a GameObject for each layer, that
        /// will be then used to parent registered UIs.
        /// </summary>
        void CreateLayers();
        
        /// <summary>
        /// Registers a transform to the service, to the requested layer.
        /// First it registers which was the previous parent of the passed Transform.
        /// Then attaches this Node as a child to the passed <see cref="UiFrameLayer"/> layer GameObject.
        /// </summary>
        /// <param name="layer">The UI frame layer to register the transform with.</param>
        /// <param name="node">The node to register.</param>
        void Register(Node node, UiFrameLayer layer = UiFrameLayer.Default);

        /// <summary>
        /// Unregisters a transform from the service, if it had been previously registered.
        /// It takes the saved previous parent of the passed Node, and re-attaches to it.
        /// </summary>
        /// <param name="node">The node to unregister.</param>
        void Unregister(Node node);

        /// <summary>
        /// If it had been previously registered, it sets the node as first child of the
        /// layer it is on.
        /// </summary>
        /// <param name="node">The node to unregister.</param>
        void MoveToBackground(Node node);

        /// <summary>
        /// If it had been previously registered, it sets the transform as last child of the
        /// layer it is on.
        /// </summary>
        /// <param name="node">The transform to unregister.</param>
        void MoveToForeground(Node node);

        /// <summary>
        /// If it had been previously registered, it sets the transform as previous to the last child of the
        /// layer it is on.
        /// </summary>
        /// <param name="node">The transform to unregister.</param>
        void MoveBehindForeground(Node node);
    }
}
