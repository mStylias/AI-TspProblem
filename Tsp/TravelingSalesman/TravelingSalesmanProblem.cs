using Tsp.Factories;
using Tsp.Logging;
using Tsp.Mathematics;

namespace Tsp;

public class TravelingSalesmanProblem
{
    public TspOptions Options { get; }

    public TravelingSalesmanProblem(TspOptions options)
    {
        Options = options;
    }

    /// <summary>
    /// Solves the traveling salesman problem with the current options
    /// </summary>
    public void Solve()
    {
        var cities = CreatePopulation();
        var solutions = CreateRandomSolutions(cities);
        RateSolutions(solutions);
        
        Console.WriteLine("Starting cities:");
        Logger.DisplayCities(Options.DisplayFormat, cities);
        Console.WriteLine("Starting random paths");
        Logger.DisplayPathsAndCosts(Options.DisplayFormat, solutions, false);
        
        while (IsAcceptableSolutionFound(solutions) == false)
        {
            var parents = SelectParents(solutions);
            solutions = BreedNewPopulation(parents, cities[0]);
            RateSolutions(solutions);
        }
        
        var bestSolution = Path.BestPath;
        Console.WriteLine("The best path that was found is:");
        Logger.DisplayPath(Options.DisplayFormat, bestSolution.Cities);
        Console.WriteLine($"\nWith cost: {Math.Round(ExtraMath.InvertNumber(bestSolution.InvertedCost))}");
    }

    public List<City> CreatePopulation()
    {
        return new CitiesFactory().CreateMultipleCities(Options.NumberOfCities);
    }

    public List<Path> CreateRandomSolutions(List<City> cities)
    {
        var citiesDistances = new CitiesDistances();
        citiesDistances.GenerateRandomDistances(cities, Options.MinDistanceCost, Options.MaxDistanceCost);
        
        var pathManagement = new PathManagement(citiesDistances);
        return pathManagement.GenerateRandomPaths(Options.NumberOfRandomPaths, cities);
    }

    public void RateSolutions(List<Path> solutions)
    {
        foreach (var path in solutions)
        {
            Cost.CalculatePathCost(path);
        }
    }

    public List<PathPair> SelectParents(List<Path> paths)
    {
        var pathCostSums = Cost.CalculatePathsCostSums(paths);
        return Breeding.SelectParents(paths, pathCostSums);
    }

    public List<Path> BreedNewPopulation(List<PathPair> parents, City firstCity)
    {
        bool isSolutionsNumOdd;

        if (Options.NumberOfRandomPaths % 2 == 0) 
            isSolutionsNumOdd = false;
        else 
            isSolutionsNumOdd = true;

        return Breeding.BreedNewSolutions(parents, isSolutionsNumOdd, firstCity);
    }

    public bool IsAcceptableSolutionFound(List<Path> solutions)
    {
        var count = new Dictionary<double, int>();
        foreach (var path in solutions) {
            if (count.ContainsKey(path.InvertedCost)) {
                count[path.InvertedCost]++;
            } else {
                count.Add(path.InvertedCost, 1);
            }
        }
        
        double highestCount = 0;
        foreach (var pair in count) {
            if (pair.Value > highestCount) {
                highestCount = pair.Value;
            }
        }

        if (highestCount / solutions.Count > 0.95)
        {
            return true;
        }

        return false;
    }
}