namespace Tsp;

public interface IGeneticAlgorithm
{
    /// <summary>
    /// Solves the traveling salesman problem with the current options
    /// </summary>
    void Solve();

    List<City> CreatePopulation();
    List<Path> CreateRandomSolutions(List<City> cities);
    void RateSolutions(List<Path> solutions);
    List<PathPair> SelectParents(List<Path> paths);
    List<Path> BreedNewPopulation(List<PathPair> parents, City firstCity);
    bool IsAcceptableSolutionFound(List<Path> solutions);
}