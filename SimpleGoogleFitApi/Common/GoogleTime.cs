using System;

namespace SimpleGoogleFitApi.Common
{
    public class GoogleTime
    {
        private static readonly DateTime zero = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public long TotalMilliseconds { get; private set; }

        private GoogleTime()
        {
        }

        public static GoogleTime FromDateTime(DateTime dt)
        {
            if (dt < zero)
            {
                throw new Exception("Invalid Google datetime.");
            }

            return new GoogleTime
            {
                TotalMilliseconds = (long)(dt - zero).TotalMilliseconds,
            };
        }

        public static GoogleTime FromNanoseconds(long? nanoseconds)
        {
            if (nanoseconds < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(nanoseconds), "Must be greater than 0.");
            }

            return new GoogleTime
            {
                TotalMilliseconds = nanoseconds.GetValueOrDefault(0) / 1000000
            };
        }

        public static GoogleTime Now
        {
            get { return FromDateTime(DateTime.Now); }
        }

        public GoogleTime Add(TimeSpan timeSpan)
        {
            return new GoogleTime
            {
                TotalMilliseconds = TotalMilliseconds + (long)timeSpan.TotalMilliseconds
            };
        }

        public DateTime ToDateTime()
        {
            return zero.AddMilliseconds(TotalMilliseconds);
        }
    }
}