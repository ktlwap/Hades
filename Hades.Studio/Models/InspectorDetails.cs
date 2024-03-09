using System.Collections.ObjectModel;

namespace Hades.Studio.Models;

public class InspectorDetails
{
    public HierarchyNode Node { get; set; }
    public ObservableCollection<ComponentDetails> ComponentDetails { get; }

    public InspectorDetails(HierarchyNode node, ObservableCollection<ComponentDetails> componentDetails)
    {
        Node = node;
        ComponentDetails = componentDetails;
    }
}
