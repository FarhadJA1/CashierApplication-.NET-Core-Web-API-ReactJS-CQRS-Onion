using Microsoft.Data.SqlClient;

namespace B.Repository.Data;
public class AppDbContext
{
    public static SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-1NLMPNC\SQLEXPRESS01; initial Catalog=CashierDbDapper;
                                                            Integrated Security=True;");
    
    public static void OpenConnection()
    {
        if (sqlConnection.State== System.Data.ConnectionState.Closed)
        {
            sqlConnection.Open();
        }        
    }
    public static void CloseConnection()
    {
        if (sqlConnection.State == System.Data.ConnectionState.Open)
        {
            sqlConnection.Close();
        }
    }
}
