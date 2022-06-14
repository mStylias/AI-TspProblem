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
    public void DisplayInBinary()
    {
        Console.WriteLine(Convert.ToString(ByteValue, 2).PadLeft(8, '0'));
    }
}