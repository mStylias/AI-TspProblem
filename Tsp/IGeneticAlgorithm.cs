namespace Tsp;

/// <summary>
/// The general form of a genetic algorithm
/// </summary>
public interface IGeneticAlgorithm<TPopulation, TSolution, TRate, TCouple>
{
    /// <summary>
    /// Solves the problem using the genetic algorithm
    /// </summary>
    public void Solve();
    
    /// <summary>
    /// Creates the original population with the given size
    /// </summary>
    /// <returns> A generic type of population </returns>
    public TPopulation CreatePopulation(int populationSize);

    /// <summary>
    /// Creates a random and probably non optimal collection of solutions for the problem
    /// </summary>
    /// <returns> A generic solution </returns>
    public ICollection<TSolution> CreateRandomSolutions(TPopulation population);

    /// <summary>
    /// Rates the created solutions
    /// </summary>
    /// <param name="population"> The population </param>
    /// <param name="solutions"> A collection of the solutions to rate </param>
    /// <returns> A key-value collection of solutions and their ratings </returns>
    public ICollection<KeyValuePair<TSolution, TRate>> RateSolutions(TPopulation population, ICollection<TSolution> solutions);
    
    /// <summary>
    /// The function that is used to rate a solution
    /// </summary>
    /// <returns> Returns a rating for the given solution </returns>
    public TRate FitnessFunction(TSolution solution);

    /// <summary>
    /// Combine members of the population giving higher priority on high rated population members
    /// </summary>
    /// <param name="population"> The population to form couples </param>
    /// <param name="ratedSolutions"> The rating of the solutions </param>
    public ICollection<TCouple> FormCouples(TPopulation population, ICollection<KeyValuePair<TSolution, TRate>> ratedSolutions);

    /// <summary>
    /// Breed a new population from the given couples. Each couple creates 2 offsprings
    /// </summary>
    /// <param name="couples"> The couples that will create the population </param>
    /// <returns> A new population </returns>
    public TPopulation BreedNewPopulation(ICollection<TCouple> couples);

    /// <summary>
    /// Determines whether a satisfying solutions is found 
    /// </summary>
    /// <returns></returns>
    public bool IsAcceptableSolutionFound();
}