namespace Tsp;

public class Path
{
    public static CitiesDistances? CitiesDistances { get; set; }
    public static Path BestPath { get; set; } = new Path(null);
    /// <summary>
    /// Indicates how many costs have been calculated
    /// after the current best path was found
    /// </summary>
    public static int CostCalculationsAfterBestPath = 0;

    public List<City> Cities { get; }
    public double InvertedCost { get; set; }

    public Path(List<City> cities)
    {
        Cities = cities;
    }
}