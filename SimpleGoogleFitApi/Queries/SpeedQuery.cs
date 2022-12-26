using Google.Apis.Fitness.v1;
using SimpleGoogleFitApi;
using SimpleGoogleFitApi.Queries.Common;

namespace SimpleGoogleFitApi.Queries
{
    public class SpeedQuery : BaseFitnessQuery
    {
        private const string DataSource = "derived:com.google.speed:com.google.android.gms:merge_speed";
        private const string DataType = "com.google.speed";

        private const string scope = FitnessService.ScopeConstants.FitnessActivityRead;

        public SpeedQuery(FitnessService service, FitnessScopeManager scopeManager) :
            base(service, scopeManager, DataSource, DataType, scope)
        {
        }
    }
}