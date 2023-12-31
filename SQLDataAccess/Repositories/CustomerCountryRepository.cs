﻿using Microsoft.Data.SqlClient;
using SQLDataAccess.DB;
using SQLDataAccess.Models;

namespace SQLDataAccess.Repositories;

/// <summary>
/// Represents a repository for querying customer counts by country.
/// </summary>
public class CustomerCountryRepository
{
    private readonly DatabaseConnection _dbConnection;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerCountryRepository"/> class with the specified database connection.
    /// </summary>
    /// <param name="dbConnection">The database connection to be used for data retrieval.</param>
    public CustomerCountryRepository(DatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }


    /// <summary>
    /// Retrieves a list of customer counts by country.
    /// </summary>
    /// <returns>A list of <see cref="CustomerCountry"/> objects representing customer counts by country. List is empty if no found</returns>
    public List<CustomerCountry> GetCustomersCountByCountry()
    {
        List<CustomerCountry> customerCountry = new List<CustomerCountry>();
        using SqlConnection connection = _dbConnection.GetConnection();
        const string query = @" SELECT Country, COUNT(CustomerId) AS NumberOfCustomers FROM Customer GROUP BY Country ORDER BY NumberOfCustomers DESC;";
        try
        {
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                customerCountry.Add(new CustomerCountry
                {
                    Country = reader["Country"].ToString()!,
                    Count = Convert.ToInt32(reader["NumberOfCustomers"])
                });
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"SQL Error: {ex.Message}");
            throw;
        }

        return customerCountry;
    }
}