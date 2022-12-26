using Google.Apis.Fitness.v1;
using SimpleGoogleFitApi;
using SimpleGoogleFitApi.Queries.Common;

namespace SimpleGoogleFitApi.Queries
{
    public class StepsQuery : BaseFitnessQuery
    {
        private const string DataSource = "derived:com.google.step_count.delta:com.google.android.gms:merge_step_deltas";
        private const string DataType = "com.google.step_count.delta";

        private const string scope = FitnessService.ScopeConstants.FitnessActivityRead;

        public StepsQuery(FitnessService service, FitnessScopeManager scopeManager) :
            base(service, scopeManager, DataSource, DataType, scope)
        {
        }
    }
}