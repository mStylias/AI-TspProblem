namespace Tsp;

/// <summary>
/// Configuration for the traveling salesman problem
/// </summary>
public class TspOptions
{
    public int NumberOfCities { get; }
    public int NumberOfRandomPaths { get; }
    public int MinimumDistanceCost { get; }
    public int MaximumDistanceCost { get; }
    
    public TspOptions(int numberOfCities, int numberOfRandomPaths, int minimumDistanceCost, int maximumDistanceCost)
    {
        NumberOfCities = numberOfCities;
        NumberOfRandomPaths = numberOfRandomPaths;
        MinimumDistanceCost = minimumDistanceCost;
        MaximumDistanceCost = maximumDistanceCost;
    }
}