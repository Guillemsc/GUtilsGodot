using GUtils.Repositories;
using GUtils.Tasks.Sequencing.Instructions;
using GUtilsGodot.UiStack.Entries;

namespace GUtilsGodot.UiStack.Instructions
{
    public sealed class CurrentSetInteractableInstruction : InstantInstruction
    {
        readonly IKeyValueRepository<object, UiStackEntry> _entriesRepository;
        readonly ISingleRepository<object> _currentContextRepository;
        readonly bool _interactable;

        public CurrentSetInteractableInstruction(
            IKeyValueRepository<object, UiStackEntry> entriesRepository,
            ISingleRepository<object> currentContextRepository,
            bool interactable
            )
        {
            _entriesRepository = entriesRepository;
            _currentContextRepository = currentContextRepository;
            _interactable = interactable;
        }

        protected override void OnInstantExecute()
        {
            bool entryFound = _currentContextRepository.TryGet(
                out object viewContext
                );

            if(!entryFound)
            {
                return;
            }

            SetInteractable(viewContext, _interactable);
        }

        void SetInteractable(object typeId, bool interactable)
        {
            bool found = _entriesRepository.TryGet(typeId, out UiStackEntry? entry);

            if (!found)
            {
                // UnityEngine.Debug.LogError($"Tried to SetInteractable {nameof(UiStackEntry)} of type {typeId.GetType().Name}, " +
                //     $"but it was not registered, at {nameof(CurrentSetInteractableInstruction)}");

                return;
            }

            //entry.Node.gameObject.SetInteractable(interactable);
        }
    }
}
