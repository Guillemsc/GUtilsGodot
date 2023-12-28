using Godot;
using GUtils.Di.Builder;
using GUtils.Di.Delegates;
using GUtils.Visibility.Visibles;
using GUtilsGodot.UiStack.Entries;
using GUtilsGodot.UiStack.Services;
using GUtilsGodot.UiFrame.Enums;

namespace GUtilsGodot.UiStack.Extensions
{
    public static class UiStackServiceDiExtensions
    {
        static IDiBindingActionBuilder<T> LinkToUiStackService<T>(
            this IDiBindingActionBuilder<T> actionBuilder,
            Control node,
            bool isPopup,
            UiFrameLayer layer
        )
            where T : IVisible, IUiStackElement
        {
            UiStackEntry? uiStackEntry = null;

            actionBuilder.WhenInit((c, o) =>
            {
                IUiStackService uiStack = c.Resolve<IUiStackService>();

                uiStackEntry = new UiStackEntry(
                    o,
                    node,
                    o,
                    isPopup
                );

                uiStack.Register(layer, uiStackEntry);
            });

            actionBuilder.WhenDispose((c, o) =>
            {
                IUiStackService uiStack = c.Resolve<IUiStackService>();

                uiStack.Unregister(uiStackEntry!);
            });

            actionBuilder.NonLazy();

            return actionBuilder;
        }

        static IDiBindingActionBuilder<T> LinkToUiStackService<T>(
            this IDiBindingActionBuilder<T> actionBuilder,
            BindingResolverDelegate<IVisible> bindingResolverDelegate,
            Control node,
            bool isPopup,
            UiFrameLayer layer
            )
            where T : IUiStackElement
        {
            UiStackEntry? uiStackEntry = null;

            actionBuilder.WhenInit((c, o) =>
            {
                IUiStackService uiStack = c.Resolve<IUiStackService>();

                var visible = bindingResolverDelegate.Invoke(c);

                uiStackEntry = new UiStackEntry(
                    o,
                    node,
                    visible,
                    isPopup
                );

                uiStack.Register(layer, uiStackEntry);
            });

            actionBuilder.WhenDispose((c, o) =>
            {
                IUiStackService uiStack = c.Resolve<IUiStackService>();

                uiStack.Unregister(uiStackEntry!);
            });

            actionBuilder.NonLazy();

            return actionBuilder;
        }
        
        static IDiBindingActionBuilder<T> LinkToUiStackService<T>(
            this IDiBindingActionBuilder<T> actionBuilder,
            IVisible visible,
            Control node,
            bool isPopup,
            UiFrameLayer layer
        )
            where T : IUiStackElement
        {
            UiStackEntry? uiStackEntry = null;

            actionBuilder.WhenInit((c, o) =>
            {
                IUiStackService uiStack = c.Resolve<IUiStackService>();
                
                uiStackEntry = new UiStackEntry(
                    o,
                    node,
                    visible,
                    isPopup
                );

                uiStack.Register(layer, uiStackEntry);
            });

            actionBuilder.WhenDispose((c, o) =>
            {
                IUiStackService uiStack = c.Resolve<IUiStackService>();

                uiStack.Unregister(uiStackEntry!);
            });

            actionBuilder.NonLazy();

            return actionBuilder;
        }

        public static IDiBindingActionBuilder<T> LinkUiToUiStackService<T>(
            this IDiBindingActionBuilder<T> actionBuilder,
            BindingResolverDelegate<IVisible> bindingResolverDelegate,
            Control node
        )
            where T : IUiStackElement
        {
            return actionBuilder.LinkToUiStackService(
                bindingResolverDelegate,
                node,
                false,
                UiFrameLayer.Default
            );
        }
        
        public static IDiBindingActionBuilder<T> LinkUiToUiStackService<T>(
            this IDiBindingActionBuilder<T> actionBuilder,
            IVisible visible,
            Control node
        )
            where T : IUiStackElement
        {
            return actionBuilder.LinkToUiStackService(
                visible,
                node,
                false,
                UiFrameLayer.Default
            );
        }

        public static IDiBindingActionBuilder<T> LinkUiToUiStackService<T>(
            this IDiBindingActionBuilder<T> actionBuilder,
            Control node
        )
            where T : IVisible, IUiStackElement
        {
            return actionBuilder.LinkToUiStackService(
                node,
                false,
                UiFrameLayer.Default
            );
        }

        public static IDiBindingActionBuilder<T> LinkPopupToUiStackService<T>(
            this IDiBindingActionBuilder<T> actionBuilder,
            Control node
        )
            where T : IVisible, IUiStackElement
        {
            return actionBuilder.LinkToUiStackService(
                node,
                true,
                UiFrameLayer.Popup
            );
        }

        public static IDiBindingActionBuilder<T> LinkPopupToUiStackService<T>(
            this IDiBindingActionBuilder<T> actionBuilder,
            BindingResolverDelegate<IVisible> bindingResolverDelegate,
            Control node
        )
            where T : IUiStackElement
        {
            return actionBuilder.LinkToUiStackService(
                bindingResolverDelegate,
                node,
                true,
                UiFrameLayer.Popup
            );
        }

        public static IDiBindingActionBuilder<T> LinkLoadingScreenToUiStackService<T>(
            this IDiBindingActionBuilder<T> actionBuilder,
            Control node
        )
            where T : IVisible, IUiStackElement
        {
            return actionBuilder.LinkToUiStackService(
                node,
                false,
                UiFrameLayer.LoadingScreen
            );
        }

        public static IDiBindingActionBuilder<T> LinkLoadingScreenToUiStackService<T>(
            this IDiBindingActionBuilder<T> actionBuilder,
            BindingResolverDelegate<IVisible> bindingResolverDelegate,
            Control node
        )
            where T : IUiStackElement
        {
            return actionBuilder.LinkToUiStackService(
                bindingResolverDelegate,
                node,
                false,
                UiFrameLayer.LoadingScreen
            );
        }
        
        public static IDiBindingActionBuilder<T> LinkLoadingScreenToUiStackService<T>(
            this IDiBindingActionBuilder<T> actionBuilder,
            IVisible visible,
            Control node
        )
            where T : IUiStackElement
        {
            return actionBuilder.LinkToUiStackService(
                visible,
                node,
                false,
                UiFrameLayer.LoadingScreen
            );
        }
    }
}
