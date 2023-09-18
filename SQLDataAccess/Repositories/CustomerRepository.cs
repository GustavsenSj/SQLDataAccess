using Microsoft.Data.SqlClient;
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

    public CustomerGenre GetTopGenreOfCustomerWithId(int id)
    {
        CustomerGenre customerGenre = null;

        string query =
            " SELECT TOP 1 c.FirstName, c.LastName,c.CustomerId, t.GenreId, g.Name AS GenreName, COUNT(*) AS TrackCount FROM Customer c JOIN Invoice i ON c.CustomerId = i.CustomerId JOIN InvoiceLine il ON i.InvoiceId = il.InvoiceId JOIN Track t ON il.TrackId = t.TrackId JOIN Genre g ON t.GenreId = g.GenreId WHERE c.CustomerId = @id GROUP BY c.FirstName, c.LastName, c.CustomerId, t.GenreId, g.Name ORDER BY COUNT(*) DESC;";

        using (SqlConnection connection = _dbConnection.GetConnection())
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                         customerGenre = (new CustomerGenre()
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            CustomerName = reader["FirstName"].ToString() + reader["LastName"].ToString(),
                            GenreId = Convert.ToInt32(reader["Genreid"]),
                            GenreName = reader["GenreName"].ToString(),
                            TrackCount = Convert.ToInt32(reader["TrackCount"]),
                        });
                    }
                }
            }
        }

        return customerGenre;
    }
}