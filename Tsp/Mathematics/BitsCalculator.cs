namespace Tsp.Mathematics;

public static class BitsCalculator
{
    /// <summary>
    /// <para> Calculates how many bits are required to represent a specific number of entities. </para>
    /// E.g for 9 entities we need 3 bits
    /// </summary>
    /// <param name="numberOfEntities"> The number of entities that need to be represented in bit format </param>
    /// <returns></returns>
    public static int CalculateRequiredBits(int numberOfEntities)
    {
        int requiredBits = 1;
        
        while (numberOfEntities > Math.Pow(2, requiredBits))
        {
            requiredBits++;
        }

        return requiredBits;
    }

    /// <summary>
    /// <para> Gets the bit that is at the specified position of the given byte. </para>
    /// <para> E.g. If the target byte is 0100 and the position is 0 the returned
    /// value is 0. If the position is 2 the returned value is 1 </para>
    /// </summary>
    /// <param name="targetByte"> The whole byte </param>
    /// <param name="position"> The position to get the bit from </param>
    /// <returns></returns>
    public static int GetBitFromByte(Byte targetByte, int position)
    {
        var bit = (targetByte >> position) & 1;
        //Console.WriteLine(Convert.ToString(targetByte, 2).PadLeft(8, '0'));
        return bit;
    }

    /// <summary>
    /// Formats the given byte to contain the given number of bits.
    /// <para> E.g. If 1 is the given byte and the number of bits is 4 the result
    /// would be the following string: 0001 </para>
    /// </summary>
    /// <param name="targetByte"> The target byte </param>
    /// <param name="numberOfBits"> The number of bytes that the bit should contain </param>
    /// <returns></returns>
    public static string FormatByte(byte targetByte, int numberOfBits)
    {
        return Convert.ToString(targetByte, 2).PadLeft(numberOfBits, '0');
    }
}