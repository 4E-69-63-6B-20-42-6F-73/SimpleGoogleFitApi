using Google.Apis.Fitness.v1;
using SimpleGoogleFitApi.Common;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SimpleGoogleFitApi
{
    public class FitnessScopeManager
    {
        private readonly List<string> scopes = new List<string>();
        private FitnessScopeManager AddScope(string scope)
        {
            scopes.Add(scope);

            return this;
        }

        public string[] Scopes { get => scopes.ToArray(); }

        public void RequireScope(string scopeName)
        {
            if (!scopes.Contains(scopeName))
            {
                throw new MissingScopeException($"Scope is missing. Register using scopemanager in setup. Scope: {scopeName} ");
            }
        }

        public FitnessScopeManager RequestActivityRead() => AddScope(FitnessService.ScopeConstants.FitnessActivityRead);
        public FitnessScopeManager RequestBloodGlucoseRead() => AddScope(FitnessService.ScopeConstants.FitnessBloodGlucoseRead);
        public FitnessScopeManager RequestBloodPressureRead() => AddScope(FitnessService.ScopeConstants.FitnessBloodPressureRead);
        public FitnessScopeManager RequestBodyRead() => AddScope(FitnessService.ScopeConstants.FitnessBodyRead);
        public FitnessScopeManager RequestBodyTemperatureRead() => AddScope(FitnessService.ScopeConstants.FitnessBodyTemperatureRead);
        public FitnessScopeManager RequestHeartRateRead() => AddScope(FitnessService.ScopeConstants.FitnessHeartRateRead);
        public FitnessScopeManager RequestLocationRead() => AddScope(FitnessService.ScopeConstants.FitnessLocationRead);
        public FitnessScopeManager RequestNutritionRead() => AddScope(FitnessService.ScopeConstants.FitnessNutritionRead);
        public FitnessScopeManager RequestOxygenSaturationRead() => AddScope(FitnessService.ScopeConstants.FitnessOxygenSaturationRead);
        public FitnessScopeManager RequestReproductiveHealthRead() => AddScope(FitnessService.ScopeConstants.FitnessReproductiveHealthRead);
        public FitnessScopeManager RequestSleepRead() => AddScope(FitnessService.ScopeConstants.FitnessSleepRead);

        public FitnessScopeManager RequestAllRead() => RequestActivityRead()
            .RequestBloodGlucoseRead()
            .RequestBloodPressureRead()
            .RequestBodyRead()
            .RequestBodyTemperatureRead()
            .RequestHeartRateRead()
            .RequestLocationRead()
            .RequestNutritionRead()
            .RequestOxygenSaturationRead()
            .RequestReproductiveHealthRead()
            .RequestSleepRead();

    }
}

