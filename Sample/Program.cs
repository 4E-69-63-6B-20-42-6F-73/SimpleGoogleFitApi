using Microsoft.Extensions.DependencyInjection;
using SimpleGoogleFitApi;
using SimpleGoogleFitApi.Queries;

/*
 This simple example will request the weight of the last 10 days.
 Make sure to place set the path to the client_secrets file right!
 */

var serviceProvider = new ServiceCollection()
    .AddGoogleFitApi(x => x.RequestBodyRead(), "client_secrets.json") // Here we request the BodyRead scope, which is needed to execute the query.
    .BuildServiceProvider();

var query = serviceProvider.GetRequiredService<WeightQuery>();

// Request the weight for the last 10 days
var weightsPerDay = query.QueryPerDay(DateTime.Now.AddDays(-10), DateTime.Now);

// Print the output.
Console.WriteLine($"date \t\t min \t max \t average");

foreach (var weight in weightsPerDay)
{
    Console.WriteLine($"{weight.Stamp.ToShortDateString()} \t {Math.Round(weight.Min, 2)} \t {Math.Round(weight.Max, 2)} \t {Math.Round(weight.Value, 2)}");
}