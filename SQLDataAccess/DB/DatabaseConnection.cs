using System.Data;
using Microsoft.Data.SqlClient;

namespace SQLDataAccess.DB;

/// <summary>
/// Represents a database connection that manages the SqlConnection instance.
/// </summary>
public class DatabaseConnection : IDisposable
{
    private readonly SqlConnection _connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseConnection"/> class with the provided connection string.
    /// </summary>
    /// <param name="connectionString">The connection string used to establish the database connection.</param>
    public DatabaseConnection(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
    }

    /// <summary>
    /// Opens and returns a SqlConnection instance, if not already open.
    /// </summary>
    /// <returns>The SqlConnection instance used for database operations.</returns>
    /// <exception cref="SqlException">Thrown if there is an error while opening the connection.</exception>
    public SqlConnection GetConnection()
    {
        try
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            return _connection;
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Database connection error: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Disposes of the SqlConnection instance and closes it if it is open.
    /// </summary>
    public void Dispose()
    {
        if (_connection.State != ConnectionState.Closed)
        {
            _connection.Close();
        }

        _connection.Dispose();
    }
}