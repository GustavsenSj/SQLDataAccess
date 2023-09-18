using System.Data;
using Microsoft.Data.SqlClient;

namespace SQLDataAccess.DB;

public class DatabaseConnection : IDisposable
{
    private readonly SqlConnection _connection;

    public DatabaseConnection(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
    }

    public SqlConnection GetConnection()
    {
        if (_connection.State == ConnectionState.Closed)
        {
            _connection.Open();
        }

        return _connection;
    }

    public void Dispose()
    {
        if (_connection.State != ConnectionState.Closed)
        {
            _connection.Close();
        }
        _connection.Dispose();
    }
}

