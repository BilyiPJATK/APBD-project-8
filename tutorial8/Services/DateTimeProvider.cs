using tutorial8.Services.Abstractions;

namespace tutorial8.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now; 
        }

        public DateTime GetCurrentDate()
        {
            return DateTime.Today; 
        }

        public TimeSpan GetCurrentTime()
        {
            return DateTime.Now.TimeOfDay; 
        }
    }
}