using Godot;

namespace GUtilsGodot.Bootstraps;

public partial class Bootstrap : Node
{
    public sealed override void _Ready()
    {
        Run();
    }

    protected virtual void Run(){}
}