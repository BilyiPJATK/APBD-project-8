namespace tutorial8.Services.Abstractions
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrentDateTime();
        DateTime GetCurrentDate();
        TimeSpan GetCurrentTime();
    }
}