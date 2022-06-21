using Tsp;
using Tsp.Logging;
using Path = Tsp.Path;

var options = new TspOptions(20, 15, 5, 25)
{
    DisplayFormat = DisplayFormat.Binary
};

IGeneticAlgorithm<City, Path, PathPair> tsp = new TravelingSalesmanProblem(options);
tsp.Solve();

// Tester tester = new Tester
// {
//     DisplayFormat = DisplayFormat.Binary
// };

// tester.TestRandomDoubles();
// tester.TestSortedDictionary();

// tester.TestCities();
// tester.TestPathManagement();
// tester.TestRateSolutions();
// tester.TestParentSelection();
// tester.TestBreeding();