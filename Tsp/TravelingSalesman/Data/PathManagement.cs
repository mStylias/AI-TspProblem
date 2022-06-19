namespace Tsp;

public class PathManagement
{
    public CitiesDistances CitiesDistances { get; }

    public PathManagement(CitiesDistances citiesDistances)
    {
        CitiesDistances = citiesDistances;
    }

    /// <summary>
    /// Generates a list of random paths between the cities.
    /// Each path must always start from the first city, pass through 
    /// every other city only once and return to the original one
    /// </summary>
    public List<Path> GenerateRandomPaths(int numberOfPaths, List<City> cities)
    {
        // Create a copy of the cities list to use as a base for random order generation
        // The first city of the original list is excluded because each path must
        // begin and end with the first city
        List<City> citiesToShuffle = cities.ToList();
        citiesToShuffle.RemoveAt(0);

        // Generate random paths
        var paths = new List<Path>();

        for (int i = 0; i < numberOfPaths; i++)
        {
            paths.Add(GenerateRandomPath(cities[0], citiesToShuffle));
        }
        
        return paths;
    }
    
    /// <summary>
    /// Generates a random path given a list of cities
    /// </summary>
    /// <param name="firstCity"> The original city where the path starts and finishes</param>
    /// <param name="citiesToShuffle"> All the cities of the path excluding the first </param>
    /// <returns></returns>
    private Path GenerateRandomPath(City firstCity, List<City> citiesToShuffle)
    {
        var random = new Random((int)DateTime.Now.Ticks);
        var cities = new List<City>();
        
        cities.Add(firstCity);
        cities.AddRange(citiesToShuffle.OrderBy(item => random.Next()).ToList());
        cities.Add(firstCity);
        return new Path(cities, CitiesDistances);
    }
}