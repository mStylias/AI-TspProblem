using Tsp;
using Tsp.Logging;

TspOptions options = new TspOptions(40, 30, 5, 25)
{
    DisplayFormat = DisplayFormat.Decimal
};
var tsp = new TravelingSalesmanProblem(options);
tsp.Solve();


// Tester tester = new Tester
// {
//     DisplayFormat = DisplayFormat.Decimal
// };
// tester.TestRandomDoubles();
// tester.TestSortedDictionary();

// tester.TestCities();
// tester.TestPathManagement();
// tester.TestRateSolutions();
// tester.TestParentSelection();
// tester.TestBreeding();