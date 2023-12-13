using System.Collections.Generic;
using Godot;
using GUtils.Visibility.Visibles;

namespace GUtilsGodot.UiStack.Entries
{
    /// <summary>
    /// Interface representing a view stack entry.
    /// </summary>
    public sealed class UiStackEntry
    {
        public IUiStackElement Id { get; }
        public Node Node { get; }
        public IVisible Visible { get; }
        public bool IsPopup { get; }
        public IReadOnlyList<UiStackEntryRefresh> RefreshList { get; }

        public UiStackEntry(
            IUiStackElement id,
            Node node,
            IVisible visible,
            bool isPopup,
            params UiStackEntryRefresh[] refreshList
            )
        {
            Id = id;
            Node = node;
            Visible = visible;
            IsPopup = isPopup;
            RefreshList = refreshList;
        }
    }
}
