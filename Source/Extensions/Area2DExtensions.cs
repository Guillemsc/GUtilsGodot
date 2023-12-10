using System;
using Godot;

namespace GUtilsGodot.Extensions;

public static class Area2DExtensions
{
    public static void RegisterAreaEntered(
        this Area2D area2D,
        Action<Area2D> onAreaEntered
    )
    {
        area2D.Monitoring = true;
        area2D.Connect("area_entered", Callable.From(onAreaEntered));
    }
}