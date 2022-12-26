using Google.Apis.Fitness.v1;
using SimpleGoogleFitApi;
using SimpleGoogleFitApi.Queries.Common;

namespace SimpleGoogleFitApi.Queries
{
    public class HeightQuery : BaseFitnessQuery
    {
        private const string DataSource = "derived:com.google.height:com.google.android.gms:merge_height";
        private const string DataType = "com.google.height";

        private const string scope = FitnessService.ScopeConstants.FitnessBodyRead;

        public HeightQuery(FitnessService service, FitnessScopeManager scopeManager) :
            base(service, scopeManager, DataSource, DataType, scope)
        {
        }
    }
}