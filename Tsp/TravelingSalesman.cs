namespace Tsp;

public class TravelingSalesman
{
    public Area Area { get; }

    public TravelingSalesman(Area area)
    {
        Area = area;
    }

    /// <summary>
    /// A list of random paths between the cities.
    /// The paths must always start from the first city, pass through 
    /// every other city only once and return to the original one
    /// </summary>
    public List<string> Paths = new List<string>();

    /// <summary>
    /// Generates random legal paths
    /// </summary>
    private void GenerateRandomPaths()
    {
        
    }
}