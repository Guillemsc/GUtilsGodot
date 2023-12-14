using Godot;

namespace GUtilsGodot.NineSliceSprites;

[Tool]
public partial class NineSliceSprite2D : Sprite2D
{
    public override void _Ready()
    {
        SetNotifyTransform(true);
    }

    public override void _Notification(int what)
    {
        if (what != NotificationTransformChanged)
        {
            return;
        }
        
        if(Material is not ShaderMaterial shaderMaterial)
        {
            return;
        }
        
        shaderMaterial.SetShaderParameter("scale", GlobalScale);
    }
}