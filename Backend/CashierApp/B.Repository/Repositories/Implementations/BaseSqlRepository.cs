using Microsoft.Data.SqlClient;

namespace B.Repository.Repositories.Implementations;
public class BaseSqlRepository
{
    protected SqlConnection OpenConnection()
    {
        var connection = new SqlConnection(@"Data Source=DESKTOP-1NLMPNC\SQLEXPRESS01; initial Catalog=CashierDbDapper;
                                                            Integrated Security=True;");
        connection.Open();
        return connection;
    }
}
