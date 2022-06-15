using Tsp;
using Tsp.Logging;

// TspOptions options = new TspOptions(10, 10, 5, 25);
// IGeneticAlgorithm<List<City>, List<City>, double, string> tsp = new TravelingSalesmanProblem(options);
// tsp.Solve();


Tester tester = new Tester
{
    DisplayFormat = DisplayFormat.Binary
};

tester.TestCities();
tester.TestPathManagement();
tester.TestRateSolutions();
