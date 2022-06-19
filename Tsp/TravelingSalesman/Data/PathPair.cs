namespace Tsp;

/// <summary>
/// A pair of 2 paths
/// </summary>
public class PathPair
{
    public Path Path1 { get; }
    public Path Path2 { get; }

    public PathPair(Path path1, Path path2)
    {
        Path1 = path1;
        Path2 = path2;
    }
}