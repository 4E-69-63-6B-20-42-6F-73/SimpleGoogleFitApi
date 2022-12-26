using Google.Apis.Fitness.v1;
using Google.Apis.Fitness.v1.Data;
using SimpleGoogleFitApi.Common;
using System;

/// <summary>
/// Helper class that hides the complexity of the fitness API.
/// </summary>
public abstract class FitnessQuery
{
    private FitnessService _service;
    private string _dataSourceId;
    private string _dataType;

    /// <summary>
    /// Initializes a new instance of the <see cref="FitnessQuery"/> class.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <param name="dataSourceId">The data source identifier.</param>
    /// <param name="dataType">Type of the data.</param>
    public FitnessQuery(FitnessService service, string dataSourceId, string dataType)
    {
        _service = service;
        _dataSourceId = dataSourceId;
        _dataType = dataType;
    }

    /// <summary>
    /// Creates the request.
    /// </summary>
    /// <param name="start">The start.</param>
    /// <param name="end">The end.</param>
    /// <returns>The request.</returns>
    protected virtual AggregateRequest CreateRequest(DateTime start, DateTime end, TimeSpan? bucketDuration = null)
    {
        var bucketTimeSpan = bucketDuration.GetValueOrDefault(TimeSpan.FromDays(1));

        return new AggregateRequest
        {
            AggregateBy = new AggregateBy[] {
                new AggregateBy
                {
                    DataSourceId = _dataSourceId,
                    DataTypeName = _dataType
                }
            },

            BucketByTime = new BucketByTime
            {
                DurationMillis = (long)bucketTimeSpan.TotalMilliseconds
            },

            StartTimeMillis = GoogleTime.FromDateTime(start).TotalMilliseconds,
            EndTimeMillis = GoogleTime.FromDateTime(end).TotalMilliseconds

        };
    }

    /// <summary>
    /// Executes the request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="userId">The user identifier.</param>
    /// <returns>
    /// The response.
    /// </returns>
    protected virtual AggregateResponse ExecuteRequest(AggregateRequest request, string userId = "me")
    {
        var agg = _service.Users.Dataset.Aggregate(request, userId);
        return agg.Execute();
    }
}