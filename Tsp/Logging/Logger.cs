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
    
    public static void DisplayAllPaths(DisplayFormat format, IEnumerable<List<City>> paths)
    {
        Console.WriteLine("City Paths:");
        foreach (var path in paths)
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
            Console.WriteLine();
        }
    }

    public static void DisplaySolutionsRating(ICollection<KeyValuePair<List<City>, double>> solutionsRatings, DisplayFormat format)
    {
        Console.WriteLine("City Paths with costs:");
        foreach (var solutionRatings in solutionsRatings)
        {
            var path = solutionRatings.Key;
            var cost = solutionRatings.Value;
            
            switch (format)
            {
                case DisplayFormat.Binary:
                    Console.Write("-");
                    foreach (var city in path)
                    {
                        Console.Write($"{city.FormattedByte}-");
                    }
                    
                    Console.Write($" : Cost -> {cost}");
                    break;
                case DisplayFormat.Decimal:
                    Console.Write("-");
                    foreach (var city in path)
                    {
                        Console.Write($"{city.ByteValue}-");
                    }
                    
                    Console.Write($" : Cost -> {cost}");
                    break;
                default:
                    Console.Write("null");
                    break;
            }
            Console.WriteLine();
        }
    }
}