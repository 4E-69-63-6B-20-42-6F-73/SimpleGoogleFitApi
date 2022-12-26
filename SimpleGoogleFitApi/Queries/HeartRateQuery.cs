using Google.Apis.Fitness.v1;
using SimpleGoogleFitApi;
using SimpleGoogleFitApi.Queries.Common;

namespace SimpleGoogleFitApi.Queries
{
    public class HeartRateQuery : BaseFitnessQuery
    {
        private const string DataSource = "derived:com.google.heart_rate.bpm:com.google.android.gms:merge_heart_rate_bpm";
        private const string DataType = "com.google.heart_rate.bpm";

        private const string scope = FitnessService.ScopeConstants.FitnessHeartRateRead;
        public HeartRateQuery(FitnessService service, FitnessScopeManager scopeManager) :
            base(service, scopeManager, DataSource, DataType, scope)
        {
        }
    }
}