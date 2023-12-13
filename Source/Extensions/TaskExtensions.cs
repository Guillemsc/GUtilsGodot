using System.Threading.Tasks;

namespace GUtilsGodot.Extensions;

public static class TaskExtensions
{
    public static Task GodotYield()
    {
        return Task.Delay(1);
    }
}