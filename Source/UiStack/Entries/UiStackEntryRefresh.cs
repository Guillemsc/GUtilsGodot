using GUtils.Executables;
using GUtilsGodot.UiStack.Enums;

namespace GUtilsGodot.UiStack.Entries
{
    public sealed class UiStackEntryRefresh
    {
        public RefreshType RefreshType { get; }
        public IExecutable Refreshable { get; }

        public UiStackEntryRefresh(
            RefreshType refreshType,
            IExecutable refreshable
            )
        {
            RefreshType = refreshType;
            Refreshable = refreshable;
        }
    }
}
