using System.Threading.Tasks;

namespace GUtilsGodot.Extensions;

public class TaskExtensions
{
    public static Task GodotYield()
    {
        return Task.Delay(1);
    }
}