namespace Tsp.Mathematics;

public static class ExtraMath
{
    /// <summary>
    /// Inverts the given number
    /// </summary>
    /// <param name="numberToInvert"></param>
    /// <returns> A double value that corresponds to the inverted integer</returns>
    public static double InvertNumber<T>(T numberToInvert)
    {
        if (numberToInvert == null) throw new NullReferenceException("The number to invert was null"); 
        if (numberToInvert.Equals(0)) return 0;

        return 1 / Convert.ToDouble(numberToInvert);
    }
    
    /// <summary>
    /// Generates a random double within the specified range
    /// </summary>
    /// <returns></returns>
    public static double GetRandomDoubleWithinRange(double lowerBound, double upperBound, Random random)
    {
        var rDouble = random.NextDouble();
        var rRangeDouble = rDouble * (upperBound - lowerBound) + lowerBound;
        return rRangeDouble;
    }
}