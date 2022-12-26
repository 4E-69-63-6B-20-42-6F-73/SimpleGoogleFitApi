using Google.Apis.Fitness.v1;
using SimpleGoogleFitApi;
using SimpleGoogleFitApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleGoogleFitApi.Queries.Common
{
    public class BaseFitnessQuery : FitnessQuery
    {
        const int MaxDayForAggregateRequest = 90;

        public BaseFitnessQuery(FitnessService service, string dataSourceId, string dataType) : base(service, dataSourceId, dataType)
        {
        }

        public BaseFitnessQuery(FitnessService service, FitnessScopeManager scopeManager, string DataSource, string DataType, string scope) :
            base(service, DataSource, DataType)
        {
            scopeManager.RequireScope(scope);
        }

        public IList<DataPoint> Query(DateTime start, DateTime end)
        {
            // There is a max period for aggregate data. 
            // So split the request in chunks of max.
            var result = new List<DataPoint>();

            int chunks = (int)Math.Ceiling((double)end.Subtract(start).Days / (double)MaxDayForAggregateRequest); // TODO: Creat helper function?

            for (int i = 0; i < chunks; i++)
            {
                var from = start.AddDays(MaxDayForAggregateRequest * i);

                var until = start.AddDays(MaxDayForAggregateRequest * (i + 1));
                if (until > end)
                {
                    until = end;
                }

                var request = CreateRequest(from, until);
                var response = ExecuteRequest(request);

                result.AddRange(response
                .Bucket
                .SelectMany(b => b.Dataset)
                .Where(d => d.Point != null)
                .SelectMany(d => d.Point)
                .Where(p => p.Value != null)
                .SelectMany(p =>
                {
                    return p.Value.Select(v =>
                        new DataPoint
                        {
                            Value = v.FpVal.GetValueOrDefault(Convert.ToDouble(v.IntVal.GetValueOrDefault())), // TODO Fix this...
                            Stamp = GoogleTime.FromNanoseconds(p.StartTimeNanos).ToDateTime()
                        });
                })
                .ToList());
            }

            return result;
        }

        public IList<DataPoint> QueryPerDay(DateTime start, DateTime end)
        {
            return Query(start, end)
                .OrderBy(w => w.Stamp)
                .GroupBy(w => w.Stamp.Date)
                .Select(g => new DataPoint
                {
                    Stamp = g.Key,
                    Max = g.Max(w => w.Value),
                    Min = g.Min(w => w.Value),
                    Value = g.Average(w => w.Value)
                })
                .ToList();
        }
    }
}