namespace Tsp;

/// <summary>
/// The general form of a genetic algorithm
/// </summary>
public interface IGeneticAlgorithm<TPopulation, TSolution, TCouple>
{
    /// <summary>
    /// Solves the traveling salesman problem with the current options
    /// </summary>
    void Solve();

    /// <summary>
    /// Creates the original population with the given size
    /// </summary>
    /// <returns> A generic type of population </returns>
    List<TPopulation> CreatePopulation();
    
    /// <summary>
    /// Creates a random and probably non optimal collection of solutions for the problem
    /// </summary>
    /// <returns> A generic solution </returns>
    List<TSolution> CreateRandomSolutions(List<TPopulation> population);
    
    /// <summary>
    /// Rates the created solutions
    /// </summary>
    void RateSolutions(List<TSolution> solutions);
    
    /// <summary>
    /// Combine members of the population giving higher priority on high rated population members
    /// </summary>
    List<TCouple> SelectParents(List<TSolution> solutions);
    
    /// <summary>
    /// Breed a new population from the given couples. Each couple creates 2 offsprings
    /// </summary>
    List<TSolution> BreedNewPopulation(List<TCouple> parents, TPopulation population);
    
    /// <summary>
    /// Determines whether a satisfying solutions is found 
    /// </summary>
    bool AreSolutionsConverging(List<TSolution> solutions);
}