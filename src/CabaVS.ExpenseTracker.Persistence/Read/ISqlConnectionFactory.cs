using Microsoft.Data.SqlClient;

namespace CabaVS.ExpenseTracker.Persistence.Read;

public interface ISqlConnectionFactory
{
    SqlConnection CreateConnection();
}
