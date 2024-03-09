using System.Collections.ObjectModel;

namespace Hades.Studio.Models;

public enum FileSystemNodeType
{
    File,
    Folder
}

public class FileSystemNode
{
    public string Name { get; set; }
    public string IconPath { get; set; }
    public FileSystemNodeType Type { get; set; }
    public ObservableCollection<FileSystemNode> Children { get; }

    public FileSystemNode(string name, string iconPath)
    {
        Name = name;
        IconPath = iconPath;
        Children = new ObservableCollection<FileSystemNode>();
    }
    
    public FileSystemNode(string name, string iconPath, ObservableCollection<FileSystemNode> children)
    {
        Name = name;
        IconPath = iconPath;
        Children = children;
    }
}
