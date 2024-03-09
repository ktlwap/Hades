using System.Collections.ObjectModel;

namespace Hades.Studio.Models;

public class HierarchyNode
{
    public string Name { get; set; }
    public ObservableCollection<HierarchyNode> Children { get; } = new();

    public HierarchyNode(string name)
    {
        Name = name;
    }

    public HierarchyNode(string name, ObservableCollection<HierarchyNode> children)
    {
        Name = name;
        Children = children;
    }
}
