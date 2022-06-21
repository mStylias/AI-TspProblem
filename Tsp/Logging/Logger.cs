using Tsp.Mathematics;

namespace Tsp.Logging;

public static class Logger
{
    public static void DisplayCities(DisplayFormat format, List<City> cities)
    {
        Console.WriteLine("Cities:");
        Console.Write("-");
        foreach (var city in cities)
        {
            switch (format)
            {
                case DisplayFormat.Binary:
                    Console.Write($"{city.FormattedByte}-");
                    break;
                case DisplayFormat.Decimal:
                    Console.Write($"{city.ByteValue}-");
                    break;
                default:
                    Console.Write("null");
                    break;
            }
        }
    }
    
    public static void DisplayAllPaths(DisplayFormat format, IEnumerable<Path> paths)
    {
        Console.WriteLine("City Paths:");
        foreach (var path in paths)
        {
            DisplayPath(format, path.Cities);
            Console.WriteLine();
        }
    }

    public static void DisplayPath(DisplayFormat format, IEnumerable<City> path)
    {
        Console.Write("-");
        foreach (var city in path)
        {
            switch (format)
            {
                case DisplayFormat.Binary:
                    Console.Write($"{city.FormattedByte}-");
                    break;
                case DisplayFormat.Decimal:
                    Console.Write($"{city.ByteValue}-");
                    break;
                default:
                    Console.Write("null");
                    break;
            }
        }
    }
    
    public static void DisplayPathsAndCosts(DisplayFormat format, List<Path> paths, bool isCostInverted)
    {
        Console.WriteLine("City Paths with costs:");

        foreach (var path in paths)
        {
            DisplayPath(format, path.Cities);
            Console.WriteLine(isCostInverted ? $" -> {path.InvertedCost}" : $" -> {Math.Round(ExtraMath.InvertNumber(path.InvertedCost))}");
        }
    }

    public static void DisplayPathPairs(DisplayFormat format, List<PathPair> pathPairs, bool includeCosts)
    {
        for (int i = 0; i < pathPairs.Count; i++)
        {
            Console.WriteLine($"Couple {i + 1}");
            DisplayPath(format, pathPairs[i].Path1.Cities);
            if (includeCosts) Console.WriteLine($" -> {Math.Round(ExtraMath.InvertNumber(pathPairs[i].Path1.InvertedCost))}");
            DisplayPath(format, pathPairs[i].Path2.Cities);
            if (includeCosts) Console.WriteLine($" -> {Math.Round(ExtraMath.InvertNumber(pathPairs[i].Path2.InvertedCost))}");
        }
    }
}