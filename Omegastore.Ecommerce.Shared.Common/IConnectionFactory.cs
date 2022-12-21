using System.Data;

namespace Omegastore.Ecommerce.Shared.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
