using Godot;

namespace GUtilsGodot.Rects.Nodes;

[Tool]
public partial class Rect2dNode : Node2D
{
    [Export] public Vector2 Size = new(100, 100);
    [Export] public Color DebugColor = new(1, 0, 0);

    public override void _Ready()
    {
        if (Engine.IsEditorHint())
        {
            SetProcess(true);
        }
    }

    public override void _Process(double delta)
    {
        if (Engine.IsEditorHint())
        {
            QueueRedraw();   
        }
    }

    public override void _Draw()
    {
        if (Engine.IsEditorHint())
        {
            Rect2 rect2 = GetLocalRect();
            DrawRect(rect2, DebugColor, false);
        }
    }

    public Rect2 GetLocalRect()
    {
        Vector2 center = - new Vector2(Size.X * 0.5f, Size.Y * 0.5f);
        Rect2 rect2 = new(center, Size);
        return rect2;
    }
    
    public Rect2 GetGlobalRect()
    {
        Vector2 center = GlobalPosition - new Vector2(Size.X * 0.5f, Size.Y * 0.5f);
        Rect2 rect2 = new(center, Size);
        return rect2;
    }
}