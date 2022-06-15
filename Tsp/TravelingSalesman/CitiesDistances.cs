namespace Tsp;

public class CitiesDistances
{
    private Dictionary<string, int> _costs;

    /// <summary>
    /// Creates a random distance between every city
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public void GenerateRandomDistanceCosts(List<City> cities, int minDistanceCost, int maxDistanceCost)
    {
        if (cities == null) throw new InvalidOperationException("There are no cities to create distances between!");
        if (maxDistanceCost < minDistanceCost) throw new InvalidDataException("The maximum distance can't be lower than the minimum");
        if (maxDistanceCost < 0) throw new InvalidDataException("The maximum distance can't be negative");
        if (minDistanceCost < 0) throw new InvalidDataException("The minimum distance can't be negative");

        var cityDistancesCosts = new Dictionary<string, int>();
        var randomGenerator = new Random((int)DateTime.Now.Ticks);
        
        // Loop through every combination of cities
        for (int outerCityIndex = 0; outerCityIndex < cities.Count-1; outerCityIndex++)
        {
            for (int innerCityIndex = outerCityIndex+1; innerCityIndex < cities.Count; innerCityIndex++)
            {
                string cityPair = City.CreateCityPair(cities[outerCityIndex], cities[innerCityIndex]);
                
                var randomDistance = randomGenerator.Next(minDistanceCost, maxDistanceCost);
                cityDistancesCosts.Add(cityPair, randomDistance);
                // Console.WriteLine($"{cityPair} -> {randomDistance}");
            }
        }

        _costs = cityDistancesCosts;
    }

    /// <summary>
    /// Get the distance cost of city 1 to city 2
    /// </summary>
    /// <param name="city1"> The first city </param>
    /// <param name="city2"> The second city </param>
    /// <exception cref="NullReferenceException"></exception>
    /// <returns></returns>
    public int GetDistanceOf(City city1, City city2)
    {
        if (_costs == null) throw new NullReferenceException("No distance costs have been generated!");
        
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
        return _costs[key];
    }
    
}