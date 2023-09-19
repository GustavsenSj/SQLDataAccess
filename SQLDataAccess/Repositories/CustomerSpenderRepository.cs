using Microsoft.Data.SqlClient;
using SQLDataAccess.DB;
using SQLDataAccess.Models;

namespace SQLDataAccess.Repositories;

/// <summary>
/// Provides methods to access and retrieve information about the highest spending customers from the database.
/// </summary>
public class CustomerSpenderRepository
{
    private readonly DatabaseConnection _dbConnection;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerSpenderRepository"/> class with the specified database connection.
    /// </summary>
    /// <param name="dbConnection">The database connection to be used for data retrieval.</param>
    public CustomerSpenderRepository(DatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    /// <summary>
    /// Retrieves a list of the top X highest spending customers from the database.
    /// </summary>
    /// <param name="count">The number of highest spending customers to retrieve.</param>
    /// <returns>A list of <see cref="CustomerSpender"/> objects representing the highest spending customers.</returns>
    public List<CustomerSpender> GetTopXHighestSpenders(int count)
    {
        List<CustomerSpender> customers = new List<CustomerSpender>();
        string query =
            @" SELECT TOP (@TopCount) C.CustomerId, C.FirstName, C.LastName, SUM(I.Total) AS TotalSpent FROM Customer C JOIN Invoice I ON C.CustomerId = I.CustomerId JOIN InvoiceLine IL ON I.InvoiceId = IL.InvoiceId GROUP BY C.CustomerId, C.FirstName, C.LastName ORDER BY TotalSpent DESC;";

        using (SqlConnection connection = _dbConnection.GetConnection())
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TopCount", count);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new CustomerSpender
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            TotalSpent = Convert.ToDecimal(reader["TotalSpent"])
                        });
                    }
                }
            }
        }

        return customers;
    }
}