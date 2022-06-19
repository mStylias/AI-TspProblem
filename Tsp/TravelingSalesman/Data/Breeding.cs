using Tsp.Mathematics;

namespace Tsp;

public static class Breeding
{
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
    /// <param name="pathsCostSums"> The cost of each path </param>
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
        if (parent1 == parent2)
        {
            Console.WriteLine("Found Identical Parents");
            return true;
        }

        return false;
    }
}