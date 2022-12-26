using Google.Apis.Fitness.v1;
using SimpleGoogleFitApi;
using SimpleGoogleFitApi.Queries.Common;

namespace SimpleGoogleFitApi.Queries
{
    public class OxygenSaturationQuery : BaseFitnessQuery
    {
        private const string DataSource = "derived:com.google.oxygen_saturation:com.google.android.gms:merged";
        private const string DataType = "com.google.oxygen_saturation";

        private const string scope = FitnessService.ScopeConstants.FitnessOxygenSaturationRead;

        public OxygenSaturationQuery(FitnessService service, FitnessScopeManager scopeManager) :
            base(service, scopeManager, DataSource, DataType, scope)
        {
        }
    }
}