using System.Threading;
using System.Threading.Tasks;

namespace GUtilsGodot.Tasks.Yielding;

public static class GodotTask
{
    public static Task Yield()
    {
        return Task.Delay(1);
    }
}