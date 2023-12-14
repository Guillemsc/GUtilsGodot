using Godot;
using GUtils.Tick.Enums;
using GUtils.Tick.Services;
using GUtils.Tick.Tickables;

namespace GUtilsGodot.Tick.Services;

public partial class TickablesServiceNode : Node, ITickablesService
{
    readonly TickablesService _tickablesService = new();

    public override void _Process(double delta)
        => _tickablesService.Tick();

    public override void _PhysicsProcess(double delta)
        => _tickablesService.PhysicsTick();

    public void Add(ITickable tickable, TickType tickType)
        => _tickablesService.Add(tickable, tickType);

    public void Remove(ITickable tickable, TickType tickType)
        => _tickablesService.Remove(tickable, tickType);

    public void RemoveNow(ITickable tickable, TickType tickType)
        => _tickablesService.RemoveNow(tickable, tickType);
}