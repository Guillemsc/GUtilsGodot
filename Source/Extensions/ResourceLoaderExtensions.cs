using System;
using System.Threading.Tasks;
using Godot;
using GUtils.DiscriminatedUnions;
using GUtils.Types;

namespace GUtilsGodot.Extensions;

public static class ResourceLoaderExtensions
{
    public static async Task<OneOf<T, ErrorMessage>> LoadAsync<T>(string resourcePath) where T : Resource
    {
        Error error = ResourceLoader.LoadThreadedRequest(resourcePath);

        if (error != Error.Ok)
        {
            return new ErrorMessage($"Error loading {resourcePath} async. {error}");
        }
        
        while (!ResourceLoader.HasCached(resourcePath))
        {
            await TaskExtensions.GodotYield();
        }

        Resource resource = ResourceLoader.LoadThreadedGet(resourcePath);

        if (resource is not T castedResource)
        {
            return new ErrorMessage($"Error loading {resourcePath} async. Tried to load {typeof(T)} but it was {resource.GetType()}");
        }

        return castedResource;
    }
}