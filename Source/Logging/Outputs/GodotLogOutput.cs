using Godot;
using GUtils.Logging.Enums;
using GUtils.Logging.Outputs;

namespace GUtilsGodot.Logging.Outputs;

public sealed class GodotLogOutput : ILogOutput
{
    public static readonly GodotLogOutput Instance = new();
    
    GodotLogOutput()
    {
        
    }
    
    public void Output(LogType logType, string log)
    {
        switch (logType)
        {
            case LogType.Info:
            {
                GD.Print(log);
                break;
            }
            
            case LogType.Warning:
            {
                GD.Print($"Warning: {log}");
                break;
            }
            
            case LogType.Error:
            {
                GD.PrintErr(log);
                break;
            }
        }
    }
}