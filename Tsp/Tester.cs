using Tsp.Factories;
using Tsp.Logging;
using Tsp.Mathematics;

namespace Tsp;

public class Tester
{
    public DisplayFormat DisplayFormat { get; set; }

    private static void DisplayTestPassed(int testNum)
    {
        Console.WriteLine($"\n------------------------------ TEST {testNum} PASSED ------------------------------");
    } 
    
    public void TestCities()
    {
        CitiesFactory factory = new CitiesFactory();
        var cities = factory.CreateMultipleCities(10);
        Logger.DisplayCities(DisplayFormat, cities);

        DisplayTestPassed(1);
    }

    public void TestPathManagement()
    {
        CitiesFactory factory = new CitiesFactory();
        var cities = factory.CreateMultipleCities(10);
        
        PathManagement pathManagement = new PathManagement();
        var paths = pathManagement.GenerateRandomPaths(10, cities);
        Logger.DisplayAllPaths(DisplayFormat, paths);

        DisplayTestPassed(2);
    }

    public void TestRateSolutions()
    {
        // Create cities
        CitiesFactory factory = new CitiesFactory();
        var cities = factory.CreateMultipleCities(10);
        
        // Create paths
        PathManagement pathManagement = new PathManagement();
        var paths = pathManagement.GenerateRandomPaths(10, cities);
        
        // Generate random distance costs between all cities
        var citiesDistances = new CitiesDistances();
        citiesDistances.GenerateRandomDistanceCosts(cities,5, 30);
        
        // Calculate the cost of each available path and add it to the dictionary
        var solutionRatings = new Dictionary<List<City>, double>();
        foreach (var path in paths)
        {
            var cost = ExtraMath.InvertNumber(Cost.CalculatePathCost(path, citiesDistances));
            solutionRatings.Add(path, cost);
        }

        Logger.DisplaySolutionsRating(solutionRatings, DisplayFormat);
        
        DisplayTestPassed(3);
    }
}