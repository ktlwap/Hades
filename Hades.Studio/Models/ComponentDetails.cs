namespace Hades.Studio.Models;

public class ComponentDetails
{
    public string Name { get; set; }
    public bool Enabled { get; set; }

    public ComponentDetails(string name)
    {
        Name = name;
        Enabled = true;
    }
}
