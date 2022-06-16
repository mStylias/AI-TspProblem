using Tsp.Factories;
using Tsp.Logging;
using Tsp.Mathematics;

namespace Tsp;

public class Tester
{
    public DisplayFormat DisplayFormat { get; set; }
    private TravelingSalesmanProblem _tsp;

    public Tester()
    {
         TspOptions options = new TspOptions(10, 10, 5, 25);
         _tsp = new TravelingSalesmanProblem(options);
    }
    
    private static void DisplayTestPassed(int testNum)
    {
        Console.WriteLine($"\n------------------------------ TEST {testNum} PASSED ------------------------------");
    } 
    
    public void TestCities()
    {
        Logger.DisplayCities(DisplayFormat, _tsp.CreatePopulation());
        DisplayTestPassed(1);
    }

    public void TestPathManagement()
    {
        var cities = _tsp.CreatePopulation();
        var paths = _tsp.CreateRandomSolutions(cities);
        
        Logger.DisplayAllPaths(DisplayFormat, paths);
        DisplayTestPassed(2);
    }

    public void TestRateSolutions()
    {
        var cities = _tsp.CreatePopulation();
        var paths = _tsp.CreateRandomSolutions(cities);
        var ratedSolutions = _tsp.RateSolutions(cities, paths);

        Logger.DisplaySolutionsRating(ratedSolutions, DisplayFormat);
        DisplayTestPassed(3);
    }
}