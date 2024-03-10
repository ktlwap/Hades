using System.Collections.ObjectModel;

namespace Hades.Studio.Models;

public enum FileSystemNodeType
{
    File,
    Folder
}

public class FileSystemNode
{
    public string Name { get; init; }
    public string SmallIconPath { get; set; }
    public string LargeIconPath { get; set; }
    public FileSystemNodeType Type { get; set; }
    public FileSystemNode? Parent { get; set; }
    public ObservableCollection<FileSystemNode> Children { get; }

    public FileSystemNode(string name, FileSystemNodeType type)
    {
        Name = name;
        Type = type;
        SmallIconPath = "";
        LargeIconPath = "";
        Children = new ObservableCollection<FileSystemNode>();
    }
}
