using Tsp.Factories;

namespace Tsp;

public class TravelingSalesmanProblem //: IGeneticAlgorithm<List<City>, Path, double>
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
        
        while (IsAcceptableSolutionFound() == false)
        {
            // var solutionRatings = RateSolutions(cities, solutions);
            // var parents = SelectParents(solutions, solutionRatings);
            // cities = BreedNewPopulation(parents);
        }
        
        Console.WriteLine($"The best path that was found is");
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

    public List<City> BreedNewPopulation(List<Path> parents)
    {
        throw new NotImplementedException();
    }

    public bool IsAcceptableSolutionFound()
    {
        throw new NotImplementedException();
    }
}