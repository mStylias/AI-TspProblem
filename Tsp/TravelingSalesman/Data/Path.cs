namespace Tsp;

public class Path
{
    /// <summary>
    /// The list of cities that the path consists of
    /// </summary>
    public List<City> Cities { get; }
    public CitiesDistances CitiesDistances { get; }
    public double Cost { get; set; }

    public Path(List<City> cities, CitiesDistances citiesDistances)
    {
        Cities = cities;
        CitiesDistances = citiesDistances;
    }
}