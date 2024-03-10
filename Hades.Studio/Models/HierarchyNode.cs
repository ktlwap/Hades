using System.Collections.ObjectModel;

namespace Hades.Studio.Models;

public class HierarchyNode
{
    public string Name { get; set; }
    public bool Enabled { get; set; }
    public ObservableCollection<HierarchyNode> Children { get; } = new();

    public HierarchyNode(string name) : this(name, new ObservableCollection<HierarchyNode>()) { }

    public HierarchyNode(string name, ObservableCollection<HierarchyNode> children)
    {
        Name = name;
        Children = children;
        Enabled = true;
    }
}
