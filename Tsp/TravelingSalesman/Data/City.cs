using Tsp.Mathematics;

namespace Tsp;

public class City
{
    public Byte ByteValue { get; }
    public string FormattedByte { get; }

    /// <summary>
    /// Creates a city with the given byte value
    /// </summary>
    /// <param name="byteValue"> The byte value of the city </param>
    /// <param name="numberOfBits"> The number of bits to use for displaying the city </param>
    public City(byte byteValue, int numberOfBits)
    {
        ByteValue = byteValue;
        FormattedByte = CreateFormattedByte(numberOfBits);
    }

    /// <summary>
    /// Creates a string of the city byte value with the given number of bits
    /// </summary>
    /// <param name="numberOfBits"> The number of bits that should be used for displaying the city </param>
    private string CreateFormattedByte(int numberOfBits)
    {
        if (numberOfBits < 1) throw new InvalidDataException("At least 1 bit is required");
        if (numberOfBits > 8) throw new InvalidDataException("Can't display a byte with more than 8 bits!");
        
        return BitsCalculator.FormatByte(ByteValue, numberOfBits);
    }

    /// <summary>
    /// Creates a string that combines the formatted bytes of 2 cities
    /// with a dash in between.
    /// <para> E.g. 1001-0010 </para>
    /// </summary>
    public static string CreateCityPair(City city1, City city2)
    {
        return $"{city1.FormattedByte}-{city2.FormattedByte}";
    }
}