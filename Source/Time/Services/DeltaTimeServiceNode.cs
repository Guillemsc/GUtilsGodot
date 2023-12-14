using Godot;
using GUtils.Time.Services;

namespace GUtilsGodot.Time.Services;

public partial class DeltaTimeServiceNode : Node, IDeltaTimeService
{
    public float DeltaTime { get; private set; }
    public float PhysicsDeltaTime { get; private set; }

    public override void _Process(double delta)
        => DeltaTime = (float)delta;

    public override void _PhysicsProcess(double delta)
        => PhysicsDeltaTime = (float)delta;
}