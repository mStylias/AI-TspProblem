namespace Tsp;

public class PathManagement
{
    /// <summary>
    /// Generates a list of random paths between the cities.
    /// Each path must always start from the first city, pass through 
    /// every other city only once and return to the original one
    /// </summary>
    public List<List<City>> GenerateRandomPaths(int numberOfPaths, List<City> cities)
    {
        // Create a copy of the cities list to use as a base for random order generation
        // The first city of the original list is excluded because each path must
        // begin and end with the first city
        List<City> citiesToShuffle = cities.ToList();
        citiesToShuffle.RemoveAt(0);

        // Generate random paths
        var paths = new List<List<City>>();

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
    private List<City> GenerateRandomPath(City firstCity, List<City> citiesToShuffle)
    {
        var random = new Random((int)DateTime.Now.Ticks);
        var path = new List<City>();
        
        path.Add(firstCity);
        path.AddRange(citiesToShuffle.OrderBy(item => random.Next()).ToList());
        path.Add(firstCity);
        return path;
    }
}