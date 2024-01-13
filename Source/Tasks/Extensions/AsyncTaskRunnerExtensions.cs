using System;
using Godot;

namespace GUtilsGodot.Tasks.Extensions;

public static class AsyncTaskRunnerExtensions
{
    public static readonly Action<Exception> PrintException = (e) =>
    {
        GD.PrintErr($"Exception: {e.Message}\nStackTrace: {e.StackTrace}");
    };
}