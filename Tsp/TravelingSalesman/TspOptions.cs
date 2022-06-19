namespace Tsp;

/// <summary>
/// Configuration for the traveling salesman problem
/// </summary>
public class TspOptions
{
    public int NumberOfCities { get; }
    public int NumberOfRandomPaths { get; }
    public int MinDistanceCost { get; }
    public int MaxDistanceCost { get; }
    
    public TspOptions(int numberOfCities, int numberOfRandomPaths, int minDistanceCost, int maxDistanceCost)
    {
        NumberOfCities = numberOfCities;
        NumberOfRandomPaths = numberOfRandomPaths;
        MinDistanceCost = minDistanceCost;
        MaxDistanceCost = maxDistanceCost;
    }
}