using Tsp.Mathematics;

namespace Tsp;

public static class Cost
{
    /// <summary>
    /// Creates a list of ascending values that represent the various cost grades
    /// </summary>
    /// <returns></returns>
    public static List<double> CalculateCostAreas(List<List<City>> paths, CitiesDistances citiesDistances)
    {
        var costAreas = new List<Double>();
        double totalCost = 0;
        
        for (int i = 0; i < paths.Count; i++)
        {
            var pathCost = CalculatePathCost(paths[i], citiesDistances);
            totalCost += pathCost;
            costAreas.Add(totalCost);
        }

        foreach (double cost in costAreas)
        {
            Console.WriteLine(cost);
        }

        return costAreas;
    }

    /// <summary>
    /// Calculates the cost of the given path and inverts it in order to comply with the genetics algorithm
    /// </summary>
    /// <param name="path"> The given path </param>
    /// <param name="citiesDistances"> The distances between cities </param>
    /// <returns> The cost as an integer </returns>
    public static double CalculatePathCost(List<City> path, CitiesDistances citiesDistances)
    {
        int cost = 0;
        for (int i = 0; i < path.Count - 1; i++)
        {
            cost += citiesDistances.GetDistanceOf(path[i], path[i + 1]);
        }

        return ExtraMath.InvertNumber(cost);
    }
}