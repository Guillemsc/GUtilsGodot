using System;
using Godot;

namespace GUtilsGodot.Extensions;

public static class ButtonExtensions
{
    public static void ConnectButtonPressed(this Button button, Action action)
    {
        button.Connect("pressed", Callable.From(action));
    }
    
    public static void DisconnectButtonPressed(this Button button, Action action)
    {
        button.Disconnect("pressed", Callable.From(action));
    }
}