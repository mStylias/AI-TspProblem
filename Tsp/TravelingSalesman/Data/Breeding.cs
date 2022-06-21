using Tsp.Mathematics;

namespace Tsp;

public static class Breeding
{
    #region Select Parents
    
    public static List<PathPair> SelectParents(List<Path> paths, List<double> pathsCostSums)
    {
        var random = new Random((int)DateTime.Now.Ticks);
        var couples = new List<PathPair>();

        // Loop through all the paths
        for (int i = 0; i < paths.Count; i += 2)
        {
            List<Path> parents = PickParentsByCostArea(paths, pathsCostSums, random);
            couples.Add(new PathPair(parents[0], parents[1]));
        }
        
        return couples;
    }
    
    /// <summary>
    /// Creates one pair from the available paths
    /// </summary>
    /// <param name="paths"> The available paths </param>
    /// <param name="pathsCostSums"> The paths costs </param>
    /// <param name="random"> A random number generator </param>
    /// <returns> A list with the 2 selected parents </returns>
    private static List<Path> PickParentsByCostArea(List<Path> paths, List<double> pathsCostSums, Random random)
    {
        List<Path> parents = new List<Path>();
        
        // Loop 2 times
        for (int parentIndex = 0; parentIndex < 2; parentIndex++)
        {
            parents.Add(PickParent(paths, pathsCostSums, parents, parentIndex, random));
        }

        return parents;
    }

    /// <summary>
    /// Picks 1 random parent according to the paths costs
    /// </summary>
    /// <param name="paths"> The available paths to choose from </param>
    /// <param name="pathsCostSums"> The cost of each path (the last element is the sum of all costs) </param>
    /// <param name="parents"> The parents list </param>
    /// <param name="parentIndex"> The current parent index </param>
    /// <param name="random"> A random number generator </param>
    /// <returns></returns>
    private static Path PickParent(List<Path> paths, List<double> pathsCostSums, List<Path> parents, int parentIndex, Random random)
    {
        var randomDouble = ExtraMath.GetRandomDoubleWithinRange(0, pathsCostSums.Last(), random);
        
        for (int pathIndex = 0; pathIndex < paths.Count; pathIndex++)
        {
            if (randomDouble <= pathsCostSums[pathIndex])
            {
                // Generate a different parent if the 2 parents are identical
                if (parentIndex > 0)
                {
                    while (AreParentsIdentical(parents[0], paths[pathIndex]))
                    {
                        return PickParent(paths, pathsCostSums, parents, parentIndex, random);
                    }    
                }
                
                return paths[pathIndex];
            }
        }

        return null;
    }

    /// <summary>
    /// Check if the given parents are identical
    /// </summary>
    private static bool AreParentsIdentical(Path parent1, Path parent2)
    {
        return parent1 == parent2;
    }
    
    #endregion

    #region BreedNewSolutions

    /// <summary>
    /// Breeds new paths from the given parents. 
    /// If the number of solutions that are required is odd
    /// then the last couple's second child will be mercilessly aborted
    /// </summary>
    /// <param name="couples"> The ancestors </param>
    /// <param name="isSolutionsNumOdd"> Bool that determines if the number of solutions is odd </param>
    /// <param name="firstCity"> The origin city where the travelling salesman begins and ends </param>
    /// <returns> A list of the newly born solutions </returns>
    public static List<Path> BreedNewSolutions(List<PathPair> couples, bool isSolutionsNumOdd, City firstCity)
    {
        var newSolutions = new List<Path>();
        
        foreach (var couple in couples)
        {
            newSolutions.Add(BreedOffspring(couple.Path1, couple.Path2, firstCity));
            newSolutions.Add(BreedOffspring(couple.Path2, couple.Path1, firstCity));
        }

        if (isSolutionsNumOdd)
        {
            newSolutions.Remove(newSolutions.Last());
        }

        return newSolutions;
    }

    /// <summary>
    /// Breeds a new offspring from the given couple
    /// The offspring consists of the first half
    /// of parent1 and the second half of parent2
    /// </summary>
    /// <returns> A new path </returns>
    private static Path BreedOffspring(Path parent1, Path parent2, City firstCity)
    {
        Path offspringPath = new Path(new List<City>());

        int cityIndex = 0;
        // Add the first half of parent1
        while (cityIndex < parent1.Cities.Count / 2)
        {
            offspringPath.Cities.Add(parent1.Cities[cityIndex]);
            cityIndex++;
        }
        
        // Add the second half of parent2 or potentially a bit from the beginning too (details below)
        // Loop while the offspring's cities are not the same as the parent's city minus 1,
        // because we add the last city (which is the origin) after the loop
        while (offspringPath.Cities.Count != parent2.Cities.Count-1)
        {
            // If some cities have already been added they are skipped
            // and the loop starts from the beginning until all cities
            // have been added
            // City index starts from one and ends at -2 from count because the origin city is excluded
            if (cityIndex > parent2.Cities.Count - 2)
            {
                cityIndex = 1;
            }
            
            // Skip the city if it is already contained in the offspring
            if (offspringPath.Cities.Contains(parent2.Cities[cityIndex]))
            {
                cityIndex++;
                continue;
            }
            
            offspringPath.Cities.Add(parent2.Cities[cityIndex]);
            cityIndex++;
        }
        
        offspringPath.Cities.Add(firstCity);
        return offspringPath;
    }

    #endregion
}