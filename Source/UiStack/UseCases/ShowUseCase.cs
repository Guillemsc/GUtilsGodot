using System.Threading;
using System.Threading.Tasks;
using Godot;
using GUtils.Repositories;
using GUtilsGodot.UiFrame.Services;
using GUtilsGodot.UiStack.Entries;
using GUtilsGodot.UiStack.Enums;

namespace GUtilsGodot.UiStack.UseCases
{
    public sealed class ShowUseCase
    {
        readonly IUiFrameService _uiFrameService;
        readonly IKeyValueRepository<object, UiStackEntry> _entriesRepository;
        readonly ISingleRepository<object> _currentUiRepository;
        readonly IListRepository<object> _currentPopupsRepository;

        public ShowUseCase(
            IUiFrameService uiFrameService,
            IKeyValueRepository<object, UiStackEntry> entriesRepository,
            ISingleRepository<object> currentUiRepository,
            IListRepository<object> currentPopupsRepository
        )
        {
            _uiFrameService = uiFrameService;
            _entriesRepository = entriesRepository;
            _currentUiRepository = currentUiRepository;
            _currentPopupsRepository = currentPopupsRepository;
        }

        public async Task Execute(
            object entryId,
            bool behindForeground,
            bool instantly,
            CancellationToken cancellationToken
            )
        {
            bool found = _entriesRepository.TryGet(entryId, out UiStackEntry? entry);

            if (!found)
            {
                // UnityEngine.Debug.LogError($"Tried to Show {nameof(UiStackEntry)} of type {entryId.GetType().Name}, " +
                //                            $"but it was not registered, at {nameof(ShowUseCase)}");
                return;
            }

            entry!.Node.MouseFilter = Control.MouseFilterEnum.Pass;

            if(!entry!.IsPopup)
            {
                _currentUiRepository.Set(entry.Id);
            }
            else
            {
                _currentPopupsRepository.Add(entry.Id);
            }

            UiStackEntryUtils.Refresh(entry, RefreshType.BeforeShow);

            if (behindForeground)
            {
                _uiFrameService.MoveBehindForeground(entry.Node);
            }
            else
            {
                _uiFrameService.MoveToForeground(entry.Node);
            }

            await entry.Visible.SetVisible(visible: true, instantly, cancellationToken);

            UiStackEntryUtils.Refresh(entry, RefreshType.AfterShow);

            entry!.Node.MouseFilter = Control.MouseFilterEnum.Ignore;
        }
    }
}
