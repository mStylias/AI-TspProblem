namespace Tsp;

public class City
{
    public Byte ByteValue { get; }

    public City(byte byteByteValue)
    {
        ByteValue = byteByteValue;
    }

    /// <summary>
    /// Displays the town in binary format
    /// </summary>
    public void DisplayValueInBytes()
    {
        Console.WriteLine(Convert.ToString(ByteValue, 2).PadLeft(8, '0'));
    }
}