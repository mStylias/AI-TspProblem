using Tsp.Factories;

namespace Tsp;

public class TravelingSalesmanProblem : 
    IGeneticAlgorithm<List<City>, List<City>, double, string>
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
        var cities = CreatePopulation(Options.NumberOfCities);

        while (IsAcceptableSolutionFound() == false)
        {
            var solutions = CreateRandomSolutions(cities);
            var solutionRatings = RateSolutions(cities, solutions);
            var couples = FormCouples(cities, solutionRatings);
            cities = BreedNewPopulation(couples);
        }
        
        Console.WriteLine($"The best path that was found is");
    }

    public List<City> CreatePopulation(int numberOfCities)
    {
        CitiesFactory cityFactory = new CitiesFactory();
        return cityFactory.CreateMultipleCities(numberOfCities);
    }

    public ICollection<List<City>> CreateRandomSolutions(List<City> cities)
    {
        PathManagement pathManagement = new PathManagement();
        return pathManagement.GenerateRandomPaths(Options.NumberOfRandomPaths, cities);
    }

    public ICollection<KeyValuePair<List<City>, double>> RateSolutions(List<City> cities, ICollection<List<City>> solutions)
    {
        // Generate random distance costs between all cities
        var citiesDistances = new CitiesDistances();
        citiesDistances.GenerateRandomDistanceCosts(cities,Options.MinimumDistanceCost, Options.MaximumDistanceCost);
        
        // Calculate the cost of each available path and add it to the dictionary
        var solutionRatings = new Dictionary<List<City>, double>();
        foreach (var path in solutions)
        {
            var cost = Cost.CalculatePathCost(path, citiesDistances);
            solutionRatings.Add(path, cost);
        }

        return solutionRatings;
    }

    public double FitnessFunction(List<City> solution)
    {
        throw new NotImplementedException();
    }

    public ICollection<string> FormCouples(List<City> population, ICollection<KeyValuePair<List<City>, double>> ratedSolutions)
    {
        throw new NotImplementedException();
    }

    public List<City> BreedNewPopulation(ICollection<string> couples)
    {
        throw new NotImplementedException();
    }

    public bool IsAcceptableSolutionFound()
    {
        throw new NotImplementedException();
    }
}