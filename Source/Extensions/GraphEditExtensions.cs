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
    
    public static void ConnectEndNodeMove(
        this GraphEdit graphEdit, 
        Action action
    )
    {
        graphEdit.Connect("end_node_move", Callable.From(action));
    }
}