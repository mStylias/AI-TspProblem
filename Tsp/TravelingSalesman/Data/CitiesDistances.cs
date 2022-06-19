namespace Tsp;

public class CitiesDistances
{
    private Dictionary<string, int> _distances;

    /// <summary>
    /// Creates a random distance between every city
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public void GenerateRandomDistances(List<City> cities, int minDistance, int maxDistance)
    {
        if (cities == null) throw new InvalidOperationException("There are no cities to create distances between!");
        if (maxDistance < minDistance) throw new InvalidDataException("The maximum distance can't be lower than the minimum");
        if (maxDistance < 0) throw new InvalidDataException("The maximum distance can't be negative");
        if (minDistance < 0) throw new InvalidDataException("The minimum distance can't be negative");

        var cityDistances = new Dictionary<string, int>();
        var randomGenerator = new Random((int)DateTime.Now.Ticks);
        
        // Loop through every combination of cities
        for (var outerCityIndex = 0; outerCityIndex < cities.Count-1; outerCityIndex++)
        {
            for (var innerCityIndex = outerCityIndex+1; innerCityIndex < cities.Count; innerCityIndex++)
            {
                var cityPair = City.CreateCityPair(cities[outerCityIndex], cities[innerCityIndex]);
                var randomDistance = randomGenerator.Next(minDistance, maxDistance);
                
                cityDistances.Add(cityPair, randomDistance);
            }
        }

        _distances = cityDistances;
    }

    /// <summary>
    /// Get the distance of city 1 to city 2
    /// </summary>
    /// <param name="city1"> The first city </param>
    /// <param name="city2"> The second city </param>
    /// <exception cref="NullReferenceException"></exception>
    /// <returns></returns>
    public int GetDistanceOf(City city1, City city2)
    {
        if (_distances == null) throw new NullReferenceException("No distances have been generated!");
        
        // Make it so the first city is always the one that is first on the city list
        // because that is how they are formatted in the distance dictionary
        var firstCity = city1;
        var secondCity = city2;
        
        if (city2.ByteValue < city1.ByteValue)
        {
            firstCity = city2;
            secondCity = city1;
        }

        var key = $"{firstCity.FormattedByte}-{secondCity.FormattedByte}";
        return _distances[key];
    }
    
}