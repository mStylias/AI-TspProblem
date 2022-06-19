namespace Tsp;

/// <summary>
/// The general form of a genetic algorithm
/// </summary>
public interface IGeneticAlgorithm<TPopulation, TSolution, TRate>
{
    /// <summary>
    /// Solves the problem using the genetic algorithm
    /// </summary>
    public void Solve();
    
    /// <summary>
    /// Creates the original population with the given size
    /// </summary>
    /// <returns> A generic type of population </returns>
    public TPopulation CreatePopulation();

    /// <summary>
    /// Creates a random and probably non optimal collection of solutions for the problem
    /// </summary>
    /// <returns> A generic solution </returns>
    public List<TSolution> CreateRandomSolutions(TPopulation population);

    /// <summary>
    /// Rates the created solutions
    /// </summary>
    /// <param name="population"> The population </param>
    /// <param name="solutions"> A collection of the solutions to rate </param>
    /// <returns> A key-value collection of solutions and their ratings </returns>
    public List<TRate> RateSolutions(TPopulation population, List<TSolution> solutions);

    /// <summary>
    /// Combine members of the population giving higher priority on high rated population members
    /// </summary>
    /// <param name="solutions"> The list of current solutions </param>
    /// <param name="ratedSolutions"> The rating of the solutions </param>
    public List<TPopulation> SelectParents(List<TSolution> solutions, List<TRate> ratedSolutions);

    /// <summary>
    /// Breed a new population from the given couples. Each couple creates 2 offsprings
    /// </summary>
    /// <param name="couples"> The couples that will create the population </param>
    /// <returns> A new population </returns>
    public TPopulation BreedNewPopulation(List<TPopulation> couples);

    /// <summary>
    /// Determines whether a satisfying solutions is found 
    /// </summary>
    /// <returns></returns>
    public bool IsAcceptableSolutionFound();
}