using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using SQLDataAccess.DB;
using SQLDataAccess.Models;

namespace SQLDataAccess.Repositories;

public class CustomerCountryRepository
{
    private readonly DatabaseConnection _dbConnection;

    public CustomerCountryRepository(DatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public List<CustomerCountry> GetCustomersCountByCountry()
    {
        List<CustomerCountry> customerCountry = new List<CustomerCountry>();

        using (SqlConnection connection = _dbConnection.GetConnection())
        {
            string query =
                @" SELECT Country, COUNT(CustomerId) AS NumberOfCustomers FROM Customer GROUP BY Country ORDER BY NumberOfCustomers DESC;";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customerCountry.Add(new CustomerCountry
                        {
                            Country = reader["Country"].ToString(),
                            Count = Convert.ToInt32(reader["NumberOfCustomers"])
                        });
                    }
                }
            }
        }

        return customerCountry;
    }
}