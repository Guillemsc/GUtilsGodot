using System;
using Godot;

namespace GUtilsGodot.Extensions;

public static class GraphEditExtensions
{
    public static void ConnectConnectionRequest(
        this GraphEdit graphEdit, 
        Action<string, int, string, int> action
        )
    {
        graphEdit.Connect("connection_request", Callable.From(action));
    }
    
    public static void ConnectDisconnectionRequest(
        this GraphEdit graphEdit, 
        Action<string, int, string, int> action
    )
    {
        graphEdit.Connect("disconnection_request", Callable.From(action));
    }
}