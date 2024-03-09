using Hades.Studio.Models;

namespace Hades.Studio.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public HierarchyViewModel HierarchyViewModel { get; } = new();
}
