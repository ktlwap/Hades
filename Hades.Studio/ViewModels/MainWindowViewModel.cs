namespace Hades.Studio.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public HierarchyViewModel HierarchyViewModel { get; } = new();
    public FileSystemViewModel FileSystemViewModel { get; } = new();
    public InspectorViewModel InspectorViewModel { get; } = new();
}
