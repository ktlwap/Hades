using System.Collections.ObjectModel;
using DynamicData;
using Hades.Studio.Models;

namespace Hades.Studio.ViewModels;

public class FileSystemViewModel : ViewModelBase
{
    private const string FILE_LG_ICON_PATH = "/Assets/file-lg.svg";
    private const string FILE_SM_ICON_PATH = "/Assets/file-sm.svg";
    private const string FOLDER_LG_ICON_PATH = "/Assets/folder-lg.svg";
    private const string FOLDER_SM_ICON_PATH = "/Assets/folder-sm.svg";
    
    public ObservableCollection<FileSystemNode> Nodes { get; }
    public ObservableCollection<FileSystemNode> SelectedNodes { get; }
    public ObservableCollection<FileSystemNode> DetailedViewNodes { get; }

    public FileSystemViewModel()
    {
        Nodes = new ObservableCollection<FileSystemNode>();
        SelectedNodes = new ObservableCollection<FileSystemNode>();
        DetailedViewNodes = new ObservableCollection<FileSystemNode>();

        FileSystemNode parentNode = new FileSystemNode("Assets", FileSystemNodeType.Folder)
        {
            LargeIconPath = FOLDER_LG_ICON_PATH,
            SmallIconPath = FOLDER_SM_ICON_PATH,
        };
        Nodes.Add(parentNode);
        
        FileSystemNode folderA = new FileSystemNode("Folder A", FileSystemNodeType.Folder)
        {
            LargeIconPath = FOLDER_LG_ICON_PATH,
            SmallIconPath = FOLDER_SM_ICON_PATH,
            Parent = parentNode
        };
        FileSystemNode folderB = new FileSystemNode("Folder B", FileSystemNodeType.Folder)
        {
            LargeIconPath = FOLDER_LG_ICON_PATH,
            SmallIconPath = FOLDER_SM_ICON_PATH,
            Parent = parentNode
        };
        parentNode.Children.Add(folderA);
        parentNode.Children.Add(folderB);
        
        FileSystemNode fileA = new FileSystemNode("File A", FileSystemNodeType.File)
        {
            LargeIconPath = FILE_LG_ICON_PATH,
            SmallIconPath = FILE_SM_ICON_PATH,
            Parent = folderA
        };
        FileSystemNode fileB = new FileSystemNode("File A", FileSystemNodeType.File)
        {
            LargeIconPath = FILE_LG_ICON_PATH,
            SmallIconPath = FILE_SM_ICON_PATH,
            Parent = folderA
        };
        folderA.Children.Add(fileA);
        folderA.Children.Add(fileB);
        
        FileSystemNode fileC = new FileSystemNode("File C", FileSystemNodeType.File)
        {
            LargeIconPath = FILE_LG_ICON_PATH,
            SmallIconPath = FILE_SM_ICON_PATH,
            Parent = folderB
        };
        FileSystemNode fileD = new FileSystemNode("File D", FileSystemNodeType.File)
        {
            LargeIconPath = FILE_LG_ICON_PATH,
            SmallIconPath = FILE_SM_ICON_PATH,
            Parent = folderB
        };
        folderB.Children.Add(fileC);
        folderB.Children.Add(fileD);
        
        DetailedViewNodes.AddRange(parentNode.Children);
        
        SelectedNodes.CollectionChanged += (a, e) =>
        {
            if (a is ObservableCollection<FileSystemNode> newlySelectedNodes)
            {
                if (newlySelectedNodes.Count == 0)
                    return;
                
                // TODO: Decide whether files should be visible in overview structure.
                DetailedViewNodes.Clear();
                if (newlySelectedNodes[0].Type == FileSystemNodeType.Folder)
                {
                    // Selected children of first selected node
                    DetailedViewNodes.AddRange(newlySelectedNodes[0].Children);
                }
                else
                {
                    // Select children of parent or in case root node its children.
                    DetailedViewNodes.AddRange(newlySelectedNodes[0].Parent?.Children ?? newlySelectedNodes[0].Children);
                }
            }
        };
    }
}
