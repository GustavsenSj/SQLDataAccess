using Microsoft.Data.SqlClient;
using SQLDataAccess.DB;
using SQLDataAccess.Models;

namespace SQLDataAccess.Repositories;

using System.Collections.Generic;

/// <summary>
/// Provides methods to access and manipulate customer data in the database.
/// </summary>
public class CustomerRepository
{
    private readonly DatabaseConnection _dbConnection;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerRepository"/> class with the specified database connection.
    /// </summary>
    /// <param name="dbConnection">The database connection to be used for data retrieval.</param>
    public CustomerRepository(DatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }


    /// <summary>
    /// Retrieves a list of all customers from the database.
    /// </summary>
    /// <returns>A list of <see cref="Customer"/> objects representing customers. List is empty if no customers is found</returns>
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

    /// <summary>
    /// Retrieves a customer by their ID from the database.
    /// </summary>
    /// <param name="id">The ID of the customer to retrieve.</param>
    /// <returns>A <see cref="Customer"/> object representing the customer with the specified ID, or null if not found.</returns>
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

    /// <summary>
    /// Retrieves a list of customers whose names contain a specified search term.
    /// </summary>
    /// <param name="name">The search term to match against customer names.</param>
    /// <returns>A list of <see cref="Customer"/> objects matching the search criteria.</returns>
    public List<Customer> GetAllCustomersByName(string name)
    {
        List<Customer> customers = new List<Customer>();

        using (SqlConnection connection = _dbConnection.GetConnection())
        {
            string query =
                "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CONCAT(FirstName, ' ', LastName) LIKE @name";

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

    /// <summary>
    /// Retrieves a paged list of customers from the database.
    /// </summary>
    /// <param name="limit">The maximum number of customers to retrieve.</param>
    /// <param name="offset">The offset for paging.</param>
    /// <returns>A paged list of <see cref="Customer"/> objects.</returns>
    public List<Customer> GetCustomerInRange(int limit, int offset)
    {
        List<Customer> customers = new List<Customer>();

        using (SqlConnection connection = _dbConnection.GetConnection())
        {
            string query =
                @"SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM (SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email,ROW_NUMBER() OVER (ORDER BY CustomerId) AS RowNum FROM Customer) AS Temp WHERE RowNum BETWEEN @offset + 1 AND @offset + @limit;";
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


    /// <summary>
    /// Adds a new customer to the database.
    /// </summary>
    /// <param name="customer">The <see cref="Customer"/> object representing the customer to be added.</param>
    /// <returns>True if the customer was successfully added, otherwise false.</returns>
    public bool AddCustomer(Customer customer)
    {
        bool success;
        using (SqlConnection connection = _dbConnection.GetConnection())
        {
            string query =
                @"INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email) VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@Country", customer.Country);
                command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                command.Parameters.AddWithValue("@Email", customer.Email);

                int rowsAffected = command.ExecuteNonQuery();

                success = rowsAffected > 0;
            }
        }

        return success;
    }


    /// <summary>
    /// Updates an existing customer's information in the database.
    /// </summary>
    /// <param name="id">The ID of the customer to update.</param>
    /// <param name="customer">The updated <see cref="Customer"/> object representing the customer's information.</param>
    /// <returns>True if the customer was successfully updated, otherwise false.</returns>
    public bool UpdateCustomerWithId(int id, Customer customer)
    {
        bool success;
        string query =
            @"UPDATE Customer SET FirstName = @FirstName,  LastName = @LastName,  Country = @Country,  PostalCode = @PostalCode,  Phone = @Phone,  Email = @Email WHERE CustomerId = @CustomerId;";

        using (SqlConnection connection = _dbConnection.GetConnection())
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@Country", customer.Country);
                command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                command.Parameters.AddWithValue("@Email", customer.Email);
                ;
                command.Parameters.AddWithValue("@CustomerId", id);

                int rowsAffected = command.ExecuteNonQuery();

                success = rowsAffected > 0;
            }
        }

        return success;
    }
}