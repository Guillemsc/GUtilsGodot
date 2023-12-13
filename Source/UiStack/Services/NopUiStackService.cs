using GUtilsGodot.UiFrame.Enums;
using GUtilsGodot.UiStack.Builder;
using GUtilsGodot.UiStack.Entries;

namespace GUtilsGodot.UiStack.Services
{
    public sealed class NopUiStackService : IUiStackService
    {
        public static readonly NopUiStackService Instance = new();

        NopUiStackService()
        {

        }

        public void Register(UiStackEntry entry) { }
        public void Register(UiFrameLayer layer, UiStackEntry entry) { }
        public void Unregister(UiStackEntry entry) { }
        public void SetNotInteractableNow<T>(T instance) { }
        public IUiStackSequenceBuilder New() => NopUiStackSequenceBuilder.Instance;
    }
}
