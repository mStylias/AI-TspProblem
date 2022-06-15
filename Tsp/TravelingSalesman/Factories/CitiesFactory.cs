using System.Collections;
using Tsp.Mathematics;

namespace Tsp.Factories;

public class CitiesFactory
{
    /// <summary>
    /// Creates the given number of cities with ascending byte values
    /// and adds the to the given collection
    /// </summary>
    /// <param name="numberOfCities"> The size of the collection </param>
    /// <param name="cities"> The collection to add the cities to </param>
    public List<City> CreateMultipleCities(int numberOfCities)
    {
        var byteFormat = BitsCalculator.CalculateRequiredBits(numberOfCities);
        var cities = new List<City>();
            
        for (int i = 0; i < numberOfCities; i++)
        {
            var byteFromIndex = Convert.ToByte(i);
            cities.Add(CreateCity(byteFromIndex, byteFormat));
        }

        return cities;
    }
    
    /// <summary>
    /// Creates a city with the given byte value and number of bits to display
    /// </summary>
    /// <param name="byteValue"> The byte value of the city </param>
    /// <param name="numberOfBitsToDisplay"> The number of bits to display </param>
    /// <returns></returns>
    public City CreateCity(byte byteValue, int numberOfBitsToDisplay)
    {
        return new City(byteValue, numberOfBitsToDisplay);
    }
}