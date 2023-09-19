using Microsoft.Data.SqlClient;
using SQLDataAccess.DB;
using SQLDataAccess.Models;

namespace SQLDataAccess.Repositories;

public class CustomerSpenderRepository
{
    private readonly DatabaseConnection _dbConnection;

    public CustomerSpenderRepository(DatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }


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
    }}