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
         TspOptions options = new TspOptions(15, 11, 5, 25);
         _tsp = new TravelingSalesmanProblem(options);
    }
    
    private static void DisplayTestPassed(int testNum)
    {
        Console.WriteLine($"\n------------------------------ TEST {testNum} PASSED ------------------------------");
    }

    public void TestRandomDoubles()
    {
        for (int i = 0; i < 30; i++)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            var randomDouble = ExtraMath.GetRandomDoubleWithinRange(0, 0.09, random);
            Console.WriteLine(randomDouble);
        }
    }
    
    public void TestSortedDictionary()
    {
        var dic = new SortedDictionary<int, string>();
        for (int i = 0; i < 10; i++)
        {
            dic.Add(i, $"I said: {i}");
        }

        foreach (var keyvalue in dic)
        {
            Console.WriteLine(keyvalue.Key + " " + keyvalue.Value);
        }
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
        _tsp.RateSolutions(paths);
    
        Logger.DisplayPathsAndCosts(DisplayFormat, paths);
        DisplayTestPassed(3);
    }
    
    public void TestParentSelection()
    {
        var cities = _tsp.CreatePopulation();
        var paths = _tsp.CreateRandomSolutions(cities);
        _tsp.RateSolutions(paths);
        var parents = _tsp.SelectParents(paths);
        
        Logger.DisplayPathsAndCosts(DisplayFormat, paths);
        
        Console.WriteLine("\nSelected parents");
        Logger.DisplayPathPairs(DisplayFormat, parents, true);

        DisplayTestPassed(4);
    }
}