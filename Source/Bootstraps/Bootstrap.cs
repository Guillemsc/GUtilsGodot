using System.Threading;
using System.Threading.Tasks;
using Godot;
using GUtils.Extensions;

namespace GUtilsGodot.Bootstraps;

public partial class Bootstrap : Node
{
    public sealed override void _Ready()
    {
        Run(CancellationToken.None).RunAsync();
    }

    protected virtual Task Run(CancellationToken cancellationToken) => Task.CompletedTask;
}