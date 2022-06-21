namespace Tsp;

public class Path
{
    public static CitiesDistances? CitiesDistances { get; set; }
    public static Path BestPath { get; set; } = new(null);

    public List<City> Cities { get; }
    public double InvertedCost { get; set; }

    public Path(List<City> cities)
    {
        Cities = cities;
    }
}