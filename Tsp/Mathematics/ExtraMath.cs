namespace Tsp.Mathematics;

public static class ExtraMath
{
    /// <summary>
    /// Inverts the given number
    /// </summary>
    /// <param name="numberToInvert"></param>
    /// <returns> A double value that corresponds to the inverted integer</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static double InvertNumber<T>(T numberToInvert)
    {
        if (numberToInvert.Equals(0))
        {
            throw new InvalidOperationException("Can't divide by 0");
        }
        
        return 1 / Convert.ToDouble(numberToInvert);
    }
}