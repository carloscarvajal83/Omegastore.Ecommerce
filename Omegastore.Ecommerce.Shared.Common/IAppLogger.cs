namespace Omegastore.Ecommerce.Shared.Common
{
    public interface IAppLogger<T>
    {
        void LogInformation(string message, params object[] args);

        void LogWaring(string message, params object[] args);

        void LogError(string message, params object[] args);
    }
}
