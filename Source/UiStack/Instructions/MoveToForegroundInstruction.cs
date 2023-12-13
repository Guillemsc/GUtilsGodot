using GUtils.Repositories;
using GUtils.Tasks.Sequencing.Instructions;
using GUtilsGodot.UiFrame.Services;
using GUtilsGodot.UiStack.Entries;

namespace GUtilsGodot.UiStack.Instructions
{
    public sealed class MoveToForegroundInstruction : InstantInstruction
    {
        readonly IUiFrameService _uiFrameService;
        readonly IKeyValueRepository<object, UiStackEntry> _entriesRepository;
        readonly object _entryId;

        public MoveToForegroundInstruction(
            IUiFrameService uiFrameService,
            IKeyValueRepository<object, UiStackEntry> entriesRepository,
            object entryId
        )
        {
            _uiFrameService = uiFrameService;
            _entriesRepository = entriesRepository;
            _entryId = entryId;
        }

        protected override void OnInstantExecute()
        {
            bool found = _entriesRepository.TryGet(_entryId, out UiStackEntry? entry);

            if (!found)
            {
                // UnityEngine.Debug.LogError($"Tried to MoveToForeground {nameof(UiStackEntry)} of type {_entryId.GetType().Name}, " +
                //                            $"but it was not registered, at {nameof(MoveToBackgroundInstruction)}");

                return;
            }

            _uiFrameService.MoveToForeground(entry!.Node);
        }
    }
}
