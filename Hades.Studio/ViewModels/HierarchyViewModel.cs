using System.Collections.ObjectModel;
using Hades.Studio.Models;

namespace Hades.Studio.ViewModels;

public class HierarchyViewModel : ViewModelBase
{
    public ObservableCollection<HierarchyNode> Nodes { get; }
    public ObservableCollection<HierarchyNode> SelectedNodes { get; set; }
    
    public HierarchyViewModel()
    {
        Nodes = new ObservableCollection<HierarchyNode>
        {                
            new HierarchyNode("Animals", new ObservableCollection<HierarchyNode>
            {
                new HierarchyNode("Mammals", new ObservableCollection<HierarchyNode>
                {
                    new HierarchyNode("Lion"), new HierarchyNode("Cat"), new HierarchyNode("Zebra")
                })
            }),
            new HierarchyNode("Stones"),
            new HierarchyNode("Trees")
        };
    }
}
