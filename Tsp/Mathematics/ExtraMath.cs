namespace Tsp.Mathematics;

public static class ExtraMath
{
    /// <summary>
    /// Inverts the given integer
    /// </summary>
    /// <param name="intToInvert"></param>
    /// <returns> A double value that corresponds to the inverted integer</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static double InvertInt(int intToInvert)
    {
        if (intToInvert == 0)
        {
            throw new InvalidOperationException("Can't divide by 0");
        }
        
        return 1 / (double)intToInvert;
    }
}