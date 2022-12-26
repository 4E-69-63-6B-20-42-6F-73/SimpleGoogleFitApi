using Google.Apis.Fitness.v1;
using SimpleGoogleFitApi;
using SimpleGoogleFitApi.Queries.Common;

namespace SimpleGoogleFitApi.Queries
{
    public class FatPercentageQuery : BaseFitnessQuery
    {
        private const string DataSource = "derived:com.google.body.fat.percentage:com.google.android.gms:merged";
        private const string DataType = "com.google.body.fat.percentage";

        private const string scope = FitnessService.ScopeConstants.FitnessBodyRead;

        public FatPercentageQuery(FitnessService service, FitnessScopeManager scopeManager) :
            base(service, scopeManager, DataSource, DataType, scope)
        {
        }
    }
}