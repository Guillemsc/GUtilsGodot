using System.Collections.Generic;
using System.IO;
using Godot;

namespace GUtilsGodot.Extensions;

public static class GodotFileSystemExtensions
{
    public const string BasePath = "res://";
    
    public static IEnumerable<FileInfo> GetAllAssetsAtPath(string godotDirectory, bool recursive = true)
    {
        string basePath = ProjectSettings.GlobalizePath(godotDirectory);

        DirectoryInfo basePathInfo = new DirectoryInfo(basePath);
        
        List<DirectoryInfo> directoriesToCheck = new List<DirectoryInfo> { basePathInfo };

        while (directoriesToCheck.Count > 0)
        {
            DirectoryInfo currentDirectory = directoriesToCheck[0];
            directoriesToCheck.RemoveAt(0);
            
            if (!currentDirectory.Exists)
            {
                continue;
            }

            if (recursive)
            {
                DirectoryInfo[] subdirectories = currentDirectory.GetDirectories();
                directoriesToCheck.AddRange(subdirectories);   
            }
            
            FileInfo[] files = currentDirectory.GetFiles();
            
            foreach (FileInfo file in files)
            {
                if (!file.Exists)
                {
                    continue;
                }

                yield return file;
            }
        }
    }
    
    public static IEnumerable<FileInfo> GetAllAssets(bool recursive = true)
    {
        string basePath = ProjectSettings.GlobalizePath(BasePath);

        return GetAllAssetsAtPath(basePath, recursive);
    }
    
    public static IEnumerable<FileInfo> GetAllAssetsAtPathWithExtension(string godotDirectory, string extension)
    {
        IEnumerable<FileInfo> files = GetAllAssetsAtPath(godotDirectory);

        foreach (FileInfo file in files)
        {
            bool extensionEquals = file.Extension.Equals(extension);
            
            if (extensionEquals)
            {
                yield return file;
            }
        }
    }
}