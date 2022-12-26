using Google.Apis.Fitness.v1;
using SimpleGoogleFitApi;
using SimpleGoogleFitApi.Queries.Common;

namespace SimpleGoogleFitApi.Queries
{
    public class ActivitySegmentsQuery : BaseFitnessQuery
    {
        private const string DataSource = "derived:com.google.activity.segment:com.google.android.gms:merge_activity_segments";
        private const string DataType = "com.google.activity.segment";

        private const string scope = FitnessService.ScopeConstants.FitnessActivityRead;

        public ActivitySegmentsQuery(FitnessService service, FitnessScopeManager scopeManager) :
            base(service, scopeManager, DataSource, DataType, scope)
        {
        }
    }
}