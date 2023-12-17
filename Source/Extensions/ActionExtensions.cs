using System;
using Godot;

namespace GUtilsGodot.Extensions;

public static class ActionExtensions
{
    public static void CallDeferred(Action action)
    {
        Callable.From(action).CallDeferred();
    }
}