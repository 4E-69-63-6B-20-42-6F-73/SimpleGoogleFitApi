using Google.Apis.Fitness.v1;
using SimpleGoogleFitApi;
using SimpleGoogleFitApi.Queries.Common;

namespace SimpleGoogleFitApi.Queries
{
    public class ExpendedCaloriesQuery : BaseFitnessQuery
    {
        private const string DataSource = "derived:com.google.calories.expended:com.google.android.gms:merge_calories_expended";
        private const string DataType = "com.google.calories.expended";

        private const string scope = FitnessService.ScopeConstants.FitnessNutritionRead;

        public ExpendedCaloriesQuery(FitnessService service, FitnessScopeManager scopeManager) :
            base(service, scopeManager, DataSource, DataType, scope)
        {
        }
    }
}