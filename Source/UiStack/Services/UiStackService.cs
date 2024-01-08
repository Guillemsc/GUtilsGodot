using System.Collections.Generic;
using System.Threading;
using Godot;
using GUtils.Extensions;
using GUtils.Repositories;
using GUtils.Tasks.Sequencing.Sequencer;
using GUtilsGodot.UiFrame.Services;
using GUtilsGodot.UiStack.Builder;
using GUtilsGodot.UiStack.Entries;
using GUtilsGodot.UiStack.UseCases;
using GUtilsGodot.UiFrame.Enums;

namespace GUtilsGodot.UiStack.Services
{
    /// <inheritdoc />
    public sealed class UiStackService : IUiStackService
    {
        readonly IKeyValueRepository<object, UiStackEntry> _entriesRepository = new KeyValueRepository<object, UiStackEntry>();
        readonly ISingleRepository<object> _currentUiRepository = new SingleRepository<object>();
        readonly IListRepository<object> _currentPopupsRepository = new ListRepository<object>();
        readonly List<object> _viewStack = new();
        readonly ITaskSequencer _taskSequencer = new TaskSequencer();

        readonly IUiFrameService _uiFrameService;

        readonly ShowUseCase _showUseCase;
        readonly HideUseCase _hideUseCase;

        public UiStackService(IUiFrameService uiFrameService)
        {
            _uiFrameService = uiFrameService;

            _showUseCase = new ShowUseCase(
                uiFrameService,
                _entriesRepository,
                _currentUiRepository,
                _currentPopupsRepository
            );

            _hideUseCase = new HideUseCase(
                _entriesRepository,
                _currentUiRepository,
                _currentPopupsRepository,
                _viewStack
            );
        }

        public void Register(UiStackEntry entry)
        {
            Register(UiFrameLayer.Default, entry);
        }

        public void Register(UiFrameLayer layer, UiStackEntry entry)
        {
            bool idAlreadyAdded = _entriesRepository.Contains(entry.Id);

            if(idAlreadyAdded)
            {
                //UnityEngine.Debug.LogError($"{nameof(UiStackEntry)} with id {entry.Id} already registered");
                return;
            }

            entry.Visible.SetVisible(visible: true, instantly: true, CancellationToken.None).RunAsync();;
            entry.Visible.SetVisible(visible: false, instantly: true, CancellationToken.None).RunAsync();;

            entry!.Node.MouseFilter = Control.MouseFilterEnum.Ignore;
            
            _entriesRepository.Add(entry.Id, entry);

            _uiFrameService.Register(entry.Node, layer);
        }

        public void Unregister(UiStackEntry entry)
        {
            bool found = _entriesRepository.Remove(entry.Id);

            if (found)
            {
                entry.Visible.SetVisible(visible: false, instantly: true, CancellationToken.None).RunAsync();
            }

            if (!entry.IsPopup)
            {
                bool hasCurrentUi = _currentUiRepository.TryGet(out object viewContext);

                if (hasCurrentUi)
                {
                    bool entryIsOwnerOfCurrentContext = entry.Id == viewContext;

                    if (entryIsOwnerOfCurrentContext)
                    {
                        _currentUiRepository.Clear();
                    }
                }
            }
            else
            {
                _currentPopupsRepository.Remove(entry.Id);
            }

            _viewStack.RemoveAll(entry.Id);

            _uiFrameService.Unregister(entry.Node);
        }

        public void SetNotInteractableNow<T>(T instance)
        {
            bool found = _entriesRepository.TryGet(instance, out UiStackEntry entry);

            if (!found)
            {
                // UnityEngine.Debug.LogError($"Tried to SetNotInteractableNow {nameof(UiStackEntry)} of type {instance.GetType().Name}, " +
                //     $"but it was not registered, at {nameof(SetNotInteractableNow)}");
                return;
            }

            entry!.Node.MouseFilter = Control.MouseFilterEnum.Ignore;
            entry!.Node.ProcessMode = Node.ProcessModeEnum.Disabled;
        }

        public IUiStackSequenceBuilder New()
        {
            return new UiStackSequenceBuilder(
                _uiFrameService,
                _entriesRepository,
                _currentUiRepository,
                _currentPopupsRepository,
                _viewStack,
                _taskSequencer,
                _showUseCase,
                _hideUseCase
            );
        }
    }
}
