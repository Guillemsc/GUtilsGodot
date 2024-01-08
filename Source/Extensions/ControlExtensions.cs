using System;
using Godot;

namespace GUtilsGodot.Extensions;

public static class ControlExtensions
{
    public static void ConnectControlFocusEntered(this Control control, Action action)
    {
        control.Connect("focus_entered", Callable.From(action));
    }
    
    public static void DisconnectControlFocusEntered(this Control control, Action action)
    {
        control.Disconnect("focus_entered", Callable.From(action));
    }
}