using Tsp;

TspOptions options = new TspOptions(10, 20, 5, 25);
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