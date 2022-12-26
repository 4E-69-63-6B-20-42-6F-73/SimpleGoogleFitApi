using Google.Apis.Fitness.v1;
using SimpleGoogleFitApi;
using SimpleGoogleFitApi.Queries.Common;

namespace SimpleGoogleFitApi.Queries
{
    public class HeartMinutesQuery : BaseFitnessQuery
    {
        private const string DataSource = "derived:com.google.heart_minutes:com.google.android.gms:merge_heart_minutes";
        private const string DataType = "com.google.heart_minutes";

        private const string scope = FitnessService.ScopeConstants.FitnessActivityRead;

        public HeartMinutesQuery(FitnessService service, FitnessScopeManager scopeManager) :
            base(service, scopeManager, DataSource, DataType, scope)
        {
        }
    }
}