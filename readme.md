# SimpleGoogleFitApi

SimpleGoogleFitApi is a c# simple opinionated library for reading from the Google Fit Api.
The only supported way of using this libary is with Dependency Injection. See the sample under Usage for more details

It is based on the works of [keestalkstech](https://keestalkstech.com/2016/07/getting-your-weight-from-google-fit-with-c/)
## Installation

Use the package manager [NuGet](https://www.nuget.org/) to install SimpleGoogleFitApi.

```bash
NuGet Install-Package SimpleGoogleFitApi
```

## Usage
First of all, register for Google cloud and enable the Fit api. Remember to create an o-auth client and download the client_secrets.json!
Then, use the following code as a quick start:

```c#
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
```

## Supported endpoints
-ActiveMinutes
-ActivitySegments 
-FatPercentage
-BaseMetabolicRate
-ExpendedCalories
-Distance
-HeartMinutes
-HeartRate
-Height
-OxygenSaturation
-Speed
-Steps
-Weight

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

## License

None?
