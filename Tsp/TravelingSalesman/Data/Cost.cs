using Tsp.Mathematics;

namespace Tsp;

public static class Cost
{
    /// <summary>
    /// Creates a list with size equal to the number of path costs. 
    /// Every element of the list corresponds to the respective path cost and represents the
    /// sum of all previous path costs plus the current one.
    /// <para> Hence the last element of the list represents the sum of all costs </para>
    /// </summary>
    /// <returns> A list of double </returns>
    public static List<double> CalculatePathsCostSums(List<Path> paths)
    {
        var costAreas = new List<double>();
        double totalCost = 0;
        
        foreach (var path in paths)
        {
            totalCost += path.Cost;
            costAreas.Add(totalCost);
        }

        return costAreas;
    }

    /// <summary>
    /// Calculates the cost of the given path and inverts it in order to comply with the genetics algorithm
    /// </summary>
    /// <param name="path"> The given path </param>
    /// <returns> The cost as an integer </returns>
    public static void CalculatePathCost(Path path)
    {
        int cost = 0;
        for (int i = 0; i < path.Cities.Count - 1; i++)
        {
            cost += path.CitiesDistances.GetDistanceOf(path.Cities[i], path.Cities[i + 1]);
        }

        path.Cost = ExtraMath.InvertNumber(cost);
    }
}