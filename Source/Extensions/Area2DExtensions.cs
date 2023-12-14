using System;
using Godot;

namespace GUtilsGodot.Extensions;

public static class Area2DExtensions
{
    public static void ConnectAreaEntered(
        this Area2D area2D,
        Action<Area2D> action
    )
    {
        area2D.Monitoring = true;
        area2D.Connect("area_entered", Callable.From(action));
    }
    
    public static void ConnectAreaExited(
        this Area2D area2D,
        Action<Area2D> action
    )
    {
        area2D.Monitoring = true;
        area2D.Connect("area_exited", Callable.From(action));
    }
    
    public static void ConnectBodyEntered(
        this Area2D area2D,
        Action<Node2D> action
    )
    {
        area2D.Monitoring = true;
        area2D.Connect("body_entered", Callable.From(action));
    }
    
    public static void ConnectBodyExited(
        this Area2D area2D,
        Action<Node2D> action
    )
    {
        area2D.Monitoring = true;
        area2D.Connect("body_exited", Callable.From(action));
    }
}