using System;
using Godot;
using GUtils.Di.Builder;
using GUtils.Executables;

namespace GUtilsGodot.Extensions;

public static class ButtonDiExtensions
{
    public static IDiBindingActionBuilder<T> LinkButtonPressed<T>(
        this IDiBindingActionBuilder<T> builder,
        Button button,
        Func<T, Action> func
        )
    {
        Action? action = null;

        builder.WhenInit(o =>
        {
            action = func.Invoke(o);

            button.ConnectButtonPressed(action.Invoke);
        });

        builder.WhenDispose(() =>
        {
            button.DisconnectButtonPressed(action!.Invoke);
        });

        builder.NonLazy();

        return builder;
    }
    
    public static IDiBindingActionBuilder<T> LinkButtonPressed<T>(
        this IDiBindingActionBuilder<T> builder,
        Button button
    ) where T : IExecutable
    {
        builder.WhenInit(o =>
        {
            button.ConnectButtonPressed(o.Execute);
        });

        builder.WhenDispose(o =>
        {
            button.DisconnectButtonPressed(o.Execute);
        });

        builder.NonLazy();

        return builder;
    }
}