namespace LuckySpin.Services
{
    public interface ILogger
    {
        void Error(string errorMessage);
        void Info(string errorMessage);
    }
}