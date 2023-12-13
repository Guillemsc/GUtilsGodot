using GUtils.Refreshing.Refreshables;
using GUtilsGodot.UiStack.Enums;

namespace GUtilsGodot.UiStack.Entries
{
    public sealed class UiStackEntryRefresh
    {
        public RefreshType RefreshType { get; }
        public IRefreshable Refreshable { get; }

        public UiStackEntryRefresh(
            RefreshType refreshType,
            IRefreshable refreshable
            )
        {
            RefreshType = refreshType;
            Refreshable = refreshable;
        }
    }
}
