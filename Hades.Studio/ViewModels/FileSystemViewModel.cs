using System.Collections.ObjectModel;
using Hades.Studio.Models;

namespace Hades.Studio.ViewModels;

public class FileSystemViewModel : ViewModelBase
{
    private const string FOLDER_ICON_PATH = "/Assets/folder.svg";
    private const string FILE_ICON_PATH = "/Assets/file.svg";
    
    public ObservableCollection<FileSystemNode> Nodes { get; }
    public ObservableCollection<FileSystemNode> SelectedNodes { get; set; }

    public FileSystemViewModel()
    {
        Nodes = new ObservableCollection<FileSystemNode>
        {                
            new FileSystemNode("Animals", FOLDER_ICON_PATH, new ObservableCollection<FileSystemNode>
            {
                new FileSystemNode("Mammals", FOLDER_ICON_PATH, new ObservableCollection<FileSystemNode>
                {
                    new FileSystemNode("Lion", FILE_ICON_PATH),
                    new FileSystemNode("Cat", FILE_ICON_PATH),
                    new FileSystemNode("Zebra", FILE_ICON_PATH)
                })
            }),
            new FileSystemNode("Stones", FILE_ICON_PATH),
            new FileSystemNode("Trees", FILE_ICON_PATH)
        };
    }
}
