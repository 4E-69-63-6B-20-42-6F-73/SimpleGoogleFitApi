using Google.Apis.Fitness.v1;
using SimpleGoogleFitApi;
using SimpleGoogleFitApi.Queries.Common;

namespace SimpleGoogleFitApi.Queries
{
    public class BaseMetabolicRateQuery : BaseFitnessQuery
    {
        private const string DataSource = "derived:com.google.calories.bmr:com.google.android.gms:merged";
        private const string DataType = "com.google.calories.bmr";

        private const string scope = FitnessService.ScopeConstants.FitnessNutritionRead;

        public BaseMetabolicRateQuery(FitnessService service, FitnessScopeManager scopeManager) :
            base(service, scopeManager, DataSource, DataType, scope)
        {
        }
    }
}