using System.Collections.ObjectModel;
using Hades.Studio.Models;
using Hades.Studio.Views;

namespace Hades.Studio.ViewModels;

public class InspectorViewModel : ViewModelBase
{
    public InspectorDetails? Details { get; set; }

    public InspectorViewModel()
    {
        Details = new InspectorDetails(
            new HierarchyNode("Tier"),
            new ObservableCollection<ComponentDetails> {
                new ComponentDetails("PlayerController"),
                new ComponentDetails("OtherController")
            }
        );
    }
}
