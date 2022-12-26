using Google.Apis.Fitness.v1;
using SimpleGoogleFitApi;
using SimpleGoogleFitApi.Queries.Common;

namespace SimpleGoogleFitApi.Queries
{
    public class WeightQuery : BaseFitnessQuery
    {
        private const string DataSource = "derived:com.google.weight:com.google.android.gms:merge_weight";
        private const string DataType = "com.google.weight";

        private const string scope = FitnessService.ScopeConstants.FitnessBodyRead;

        public WeightQuery(FitnessService service, FitnessScopeManager scopeManager) :
            base(service, scopeManager, DataSource, DataType, scope)
        {
        }
    }
}