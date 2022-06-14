namespace Tsp;

public class City
{
    public Byte ByteValue { get; }

    public City(byte byteValue)
    {
        ByteValue = byteValue;
    }

    /// <summary>
    /// Displays the city in binary format
    /// </summary>
    /// <param name="numberOfBits"> The number of bits that should be displayed </param>
    public void DisplayInBinary(int numberOfBits)
    {
        Console.WriteLine(BitsCalculator.FormatByte(ByteValue, numberOfBits));
    }
}