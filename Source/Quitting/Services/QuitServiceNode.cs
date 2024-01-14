using Godot;

namespace GUtilsGodot.Quitting.Services;

public partial class QuitServiceNode : Node, IQuitService
{
    public void Quit()
    {
        GetTree().Quit();
    }
}