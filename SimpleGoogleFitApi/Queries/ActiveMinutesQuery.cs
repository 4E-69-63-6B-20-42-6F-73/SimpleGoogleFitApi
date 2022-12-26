using Google.Apis.Fitness.v1;
using SimpleGoogleFitApi;
using SimpleGoogleFitApi.Queries.Common;

namespace SimpleGoogleFitApi.Queries
{
    public class ActiveMinutesQuery : BaseFitnessQuery
    {
        private const string DataSource = "derived:com.google.active_minutes:com.google.android.gms:merge_active_minutes";
        private const string DataType = "com.google.active_minutes";

        private const string scope = FitnessService.ScopeConstants.FitnessActivityRead;

        public ActiveMinutesQuery(FitnessService service, FitnessScopeManager scopeManager) :
            base(service, scopeManager, DataSource, DataType, scope)
        {
        }
    }
}