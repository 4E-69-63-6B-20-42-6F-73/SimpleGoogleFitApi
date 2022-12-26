using Google.Apis.Auth.OAuth2;
using Google.Apis.Fitness.v1;
using Google.Apis.Services;
using Microsoft.Extensions.DependencyInjection;
using SimpleGoogleFitApi.Queries;
using System;
using System.Reflection;
using System.Threading;

namespace SimpleGoogleFitApi
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddGoogleFitApi(this IServiceCollection services, Func<FitnessScopeManager, FitnessScopeManager> configureScopeManager, string secretsFilePath)
        {
            services.AddSingleton<FitnessScopeManager>(x => configureScopeManager(new FitnessScopeManager()));

            services.AddFitnessService(secretsFilePath);

            services.AddTransient<ActiveMinutesQuery>();
            services.AddTransient<ActivitySegmentsQuery>();
            services.AddTransient<FatPercentageQuery>();
            services.AddTransient<BaseMetabolicRateQuery>();
            services.AddTransient<ExpendedCaloriesQuery>();
            services.AddTransient<DistanceQuery>();
            services.AddTransient<HeartMinutesQuery>();
            services.AddTransient<HeartRateQuery>();
            services.AddTransient<HeightQuery>();
            services.AddTransient<OxygenSaturationQuery>();
            services.AddTransient<SpeedQuery>();
            services.AddTransient<StepsQuery>();
            services.AddTransient<WeightQuery>();

            return services;
        }

        private static IServiceCollection AddFitnessService(this IServiceCollection services, string secretsFilePath)
        {
            services.AddTransient(x => CreateFitService(x, secretsFilePath));

            return services;
        }

        private static FitnessService CreateFitService(IServiceProvider serviceProvider, string secretsFilePath)
        {
            // TODO: Fix async await??
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromFile(secretsFilePath).Secrets, serviceProvider.GetRequiredService<FitnessScopeManager>().Scopes,
                    "user", CancellationToken.None);


            var service = new FitnessService(new BaseClientService.Initializer()
            {
                ApplicationName = Assembly.GetExecutingAssembly().GetName().Name,
                HttpClientInitializer = credential.Result
            });

            return service;
        }
    }
}