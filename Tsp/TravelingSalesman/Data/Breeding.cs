using Tsp.Mathematics;

namespace Tsp;

public static class Breeding
{
    public static List<PathPair> SelectCouples(List<Path> paths, List<double> pathsCostSums)
    {
        var random = new Random((int)DateTime.Now.Ticks);
        var couples = new List<PathPair>();

        for (int i = 0; i < paths.Count; i += 2)
        {
            Path[] parents = new Path[2];

            for (int parentIndex = 0; parentIndex < parents.Length; parentIndex++)
            {
                var randomDouble = ExtraMath.GetRandomDoubleWithinRange(0, pathsCostSums.Last(), random);
                for (int pathIndex = 0; pathIndex < paths.Count; pathIndex++)
                {
                    if (randomDouble <= pathsCostSums[pathIndex])
                    {
                        parents[parentIndex] = paths[parentIndex];
                        
                        if (pathIndex > 0)
                        {
                            while (parents[parentIndex] == parents[parentIndex - 1])
                            {
                                
                            }    
                        }
                        
                        break;
                    }
                }
            }
            
            couples.Add(new PathPair(parent1, parent2));
        }

        return couples;
    }
}