using Microsoft.Data.SqlClient;
using SQLDataAccess.DB;
using SQLDataAccess.Models;

namespace SQLDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class CustomerRepository
{
    private readonly DatabaseConnection _dbConnection;

    public CustomerRepository(DatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public List<Customer> GetAllCustomers()
    {
        List<Customer> customers = new List<Customer>();

        using (SqlConnection connection = _dbConnection.GetConnection())
        {
            string query = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            CustomerId = (int)reader["CustomerId"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Country = reader["Country"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader["Email"].ToString()
                        });
                    }
                }
            }
        }

        return customers;
    }

    // Add other repository methods (e.g., GetById, Insert, Update, Delete) as needed
}


