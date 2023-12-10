using System;
using System.Threading;
using System.Threading.Tasks;
using GUtils.Time.Timers;
using GUtilsGodot.Tasks.Yielding;

namespace GUtilsGodot.Time.Extensions;

public static class TimerExtensions
{
    /// <summary>
    /// Asynchronously waits until the total time of the timer reaches a certain value.
    /// </summary>
    /// <param name="time">The time span to wait for.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task GodotAwaitReach(
        this ITimer timer,
        TimeSpan time,
        CancellationToken cancellationToken
    )
    {
        while (!timer.HasReached(time) && !cancellationToken.IsCancellationRequested)
        {
            await GodotTask.Yield();
        }
    }
}