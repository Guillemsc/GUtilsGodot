using Godot;

namespace GUtilsGodot.Extensions;

public static class ResourceExtensions
{
    public static void Save(this Resource resource)
    {
        resource.Save(resource.ResourcePath);
    }
    
    public static void Save(this Resource resource, string resourcePath)
    {
        ResourceSaver.Save(resource, resourcePath);
    }
}