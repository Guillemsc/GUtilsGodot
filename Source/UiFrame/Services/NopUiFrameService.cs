using Godot;
using GUtils.ActiveSources;
using GUtilsGodot.UiFrame.Enums;

namespace GUtilsGodot.UiFrame.Services
{
    public sealed class NopUiFrameService : IUiFrameService
    {
        public static readonly NopUiFrameService Instance = new();

        NopUiFrameService() { }

        public ISingleActiveSource InteractableActiveSource => NopSingleActiveSource.Instance;
        public void CreateLayers() { }
        
        public void Register(Node node, UiFrameLayer layer = UiFrameLayer.Default) { }
        public void Unregister(Node node) { }
        public void MoveToBackground(Node node) { }
        public void MoveToForeground(Node node) { }
        public void MoveBehindForeground(Node node) { }
    }
}
