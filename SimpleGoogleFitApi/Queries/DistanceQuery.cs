using Google.Apis.Fitness.v1;
using SimpleGoogleFitApi;
using SimpleGoogleFitApi.Queries.Common;

namespace SimpleGoogleFitApi.Queries
{
    public class DistanceQuery : BaseFitnessQuery
    {
        private const string DataSource = "derived:com.google.distance.delta:com.google.android.gms:merge_distance_delta";
        private const string DataType = "com.google.distance.delta";

        private const string scope = FitnessService.ScopeConstants.FitnessActivityRead;

        public DistanceQuery(FitnessService service, FitnessScopeManager scopeManager) :
            base(service, scopeManager, DataSource, DataType, scope)
        {
        }
    }
}