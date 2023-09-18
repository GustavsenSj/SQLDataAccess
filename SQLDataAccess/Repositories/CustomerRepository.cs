﻿using Microsoft.Data.SqlClient;
using SQLDataAccess.DB;
using SQLDataAccess.Models;

namespace SQLDataAccess.Repositories;

using System.Collections.Generic;

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

    public Customer? GetCustomerById(int id)
    {
        Customer? foundCustomer = null;
        using SqlConnection connection = _dbConnection.GetConnection();
        string query =
            $"SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CustomerId = {id}";

        using SqlCommand command = new SqlCommand(query, connection);
        using SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            foundCustomer = new Customer
            {
                CustomerId = (int)reader["CustomerId"],
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Country = reader["Country"].ToString(),
                PostalCode = reader["PostalCode"].ToString(),
                Phone = reader["Phone"].ToString(),
                Email = reader["Email"].ToString()
            };
        }

        return foundCustomer;
    }


    public List<Customer> GetAllCustomersByName(string name)
    {
        List<Customer> customers = new List<Customer>();

        using (SqlConnection connection = _dbConnection.GetConnection())
        {
            string query =
                @"SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CONCAT(FirstName, ' ', LastName) LIKE @name";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", "%" + name + "%");
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


    public List<Customer> GetCustomerInRange(int limit, int offset)
    {
        List<Customer> customers = new List<Customer>();

        using (SqlConnection connection = _dbConnection.GetConnection())
        {
            string query = @"SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM (SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email,ROW_NUMBER() OVER (ORDER BY CustomerId) AS RowNum FROM Customer) AS Temp WHERE RowNum BETWEEN @offset + 1 AND @offset + @limit;";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                
                command.Parameters.AddWithValue("@limit", limit);
                command.Parameters.AddWithValue("@offset", offset);
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
}