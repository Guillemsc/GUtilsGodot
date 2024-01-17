using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Godot;
using GUtils.DiscriminatedUnions;
using GUtils.Extensions;
using GUtils.Optionals;
using GUtils.Persistence.StorageMethods;
using GUtils.Types;

namespace GUtilsGodot.Persistence.StorageMethods;

public sealed class GodotFilePersistenceStorageMethod : IPersistenceStorageMethod
{
    public static readonly GodotFilePersistenceStorageMethod Instance = new();
    
    GodotFilePersistenceStorageMethod()
    {
        
    }
    
    public Task<Optional<ErrorMessage>> Save(string localPath, string data, CancellationToken cancellationToken)
    {
        string finalPath = GetFilePathFromLocalPath(localPath);

        byte[] dataBytes = Encoding.UTF8.GetBytes(data);

        string globalizedPath = ProjectSettings.GlobalizePath(finalPath);
        
        return FileExtensions.SaveBytesWithErrorAsync(globalizedPath, dataBytes, cancellationToken);
        
        // bool exists = Godot.FileAccess.FileExists(localPath);
        //
        // if (!exists)
        // {
        //     string globalizedPath = ProjectSettings.GlobalizePath(finalPath);
        //     DirAccess dir = DirAccess.Open(globalizedPath);
        //     Error makeDirError = DirAccess.MakeDirRecursiveAbsolute(globalizedPath);
        //
        //     if (makeDirError != Error.Ok)
        //     {
        //         ErrorMessage errorMessage = new($"Error creating directory {globalizedPath}: {makeDirError.ToString()}");
        //         return OptionalExtensions.SomeAsTaskResult(errorMessage);
        //     }
        // }
        //
        // Godot.FileAccess? saveFile = Godot.FileAccess.Open(finalPath, Godot.FileAccess.ModeFlags.Write);
        //
        // if (saveFile == null)
        // {
        //     Error error = Godot.FileAccess.GetOpenError();
        //     ErrorMessage errorMessage = new($"Error opening file: {error.ToString()}");
        //     return OptionalExtensions.SomeAsTaskResult(errorMessage);
        // }
        //
        // saveFile.Store32((uint)dataBytes.Length);
        // saveFile.StoreBuffer(dataBytes);
        //
        // saveFile.Close();

        return OptionalExtensions.NoneAsTaskResult<ErrorMessage>();
    }

    public async Task<OneOf<string, ErrorMessage>> Load(string localPath, CancellationToken cancellationToken)
    {
        string finalPath = GetFilePathFromLocalPath(localPath);

        string globalizedPath = ProjectSettings.GlobalizePath(finalPath);

        OneOf<byte[], ErrorMessage> optionalBytesResult = await FileExtensions.LoadBytesWithErrorAsync(
            globalizedPath,
            cancellationToken
        );

        bool hasResult = optionalBytesResult.TryGetSecond(out ErrorMessage errorMessage);

        if (hasResult)
        {
            return errorMessage;
        }

        byte[] bytes = optionalBytesResult.UnsafeGetFirst();

        string finalString = Encoding.UTF8.GetString(bytes);

        return finalString;

        // bool fileExists = Godot.FileAccess.FileExists(finalPath);
        //
        // if (!fileExists)
        // {
        //     return Task.FromResult<OneOf<string, ErrorMessage>>(string.Empty);
        // }
        //
        // Godot.FileAccess? saveFile = Godot.FileAccess.Open(finalPath, Godot.FileAccess.ModeFlags.Write);
        //
        // if (saveFile == null)
        // {
        //     Error error = Godot.FileAccess.GetOpenError();
        //     ErrorMessage errorMessage = new(error.ToString());
        //     return Task.FromResult<OneOf<string, ErrorMessage>>(errorMessage);
        // }
        //
        // uint size = saveFile.Get32();
        // byte[] bytes = saveFile.GetBuffer(size);
        //
        // string finalString = Encoding.UTF8.GetString(bytes);
        //
        // saveFile.Close();
        //
        // return Task.FromResult<OneOf<string, ErrorMessage>>(finalString);
    }

    public static string GetFilePathFromLocalPath(string fileName)
    {
        return string.Format(
            "{0}{1}",
            GetBaseStorageDirectory(),
            $"{fileName}.save"
        );
    }

    public static string GetBaseStorageDirectory()
    {
        return $"user://Persistence{Path.DirectorySeparatorChar}";
    }
}