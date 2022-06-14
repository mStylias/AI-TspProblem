namespace Tsp;

/// <summary>
/// Represents the area where all the towns exist
/// </summary>
public class Area
{
    private readonly int NUMBER_OF_CITIES;
    private readonly int MIN_DISTANCE;
    private readonly int MAX_DISTANCE;
    public List<City> Cities { get; }
    
    /// <summary>
    /// The distance between 2 towns. The key is a string that represents a combination of 2 cities.
    /// If x is the decimal format of the first city and y of the second, the string looks like this: x-y.
    /// e.g. 4-5
    /// </summary>
    public Dictionary<string, int> CitiesDistances { get; }

    public Area(int numberOfCities, int minDistance, int maxDistance)
    {
        if (numberOfCities > 255)
        {
            throw new InvalidDataException("The maximum number of towns that is " +
                                           "supported by the application is 255");
        }
        NUMBER_OF_CITIES = numberOfCities;

        if (maxDistance < minDistance)
        {
            throw new InvalidDataException("The maximum distance can't be lower than the minimum");
        }
        MIN_DISTANCE = minDistance;
        MAX_DISTANCE = maxDistance;

        Cities = CreateCities();
        CitiesDistances = GenerateRandomDistances();
    }

    /// <summary>
    /// Creates a list of towns equal to the number of towns provided, that are all connected
    /// and the distance between them is randomly selected from a predefined set of values.
    /// Each town is represented by 1 byte
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidDataException"></exception>
    private List<City> CreateCities()
    {
        List<City> cities = new List<City>();
        
        for (int i = 0; i < NUMBER_OF_CITIES; i++)
        {
            cities.Add(new City(Convert.ToByte(i)));
        }

        return cities;
    }
    
    /// <summary>
    /// Creates a random distance between every city
    /// </summary>
    /// <returns> A dictionary with town pairs as keys and int values as distances </returns>
    /// <exception cref="InvalidOperationException"></exception>
    private Dictionary<string, int> GenerateRandomDistances()
    {
        if (Cities == null)
        {
            throw new InvalidOperationException("There are no cities to create distances between!");
        }

        Dictionary<string, int> cityDistances = new Dictionary<string, int>();
        var randomGenerator = new Random((int)DateTime.Now.Ticks);
        
        // Loop through every combination of cities
        for (int outerCityIndex = 0; outerCityIndex < NUMBER_OF_CITIES-1; outerCityIndex++)
        {
            for (int innerCityIndex = outerCityIndex+1; innerCityIndex < NUMBER_OF_CITIES; innerCityIndex++)
            {
                var randomDistance = randomGenerator.Next(MIN_DISTANCE, MAX_DISTANCE);
                // Create a town pair from the bytes of the two cities
                string cityPair = $"{Cities[outerCityIndex].ByteValue}-{Cities[innerCityIndex].ByteValue}";
                cityDistances.Add(cityPair, randomDistance);
                // Console.WriteLine($"{cityPair} - {randomDistance}");
            }
        }

        return cityDistances;
    }
}