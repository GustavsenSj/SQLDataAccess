using Microsoft.Data.SqlClient;
using SQLDataAccess.DB;
using SQLDataAccess.Models;

namespace SQLDataAccess.Repositories;

/// <summary>
/// Represents a repository for querying the top genre of a customer by their ID.
/// </summary>
public class CustomerGenreRepository
{
    private readonly DatabaseConnection _dbConnection;


    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerGenreRepository"/> class with the specified database connection.
    /// </summary>
    /// <param name="dbConnection">The database connection to be used for data retrieval.</param>
    public CustomerGenreRepository(DatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }


    /// <summary>
    /// Retrieves the top genre of a customer with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the customer for whom to find the top genre.</param>
    /// <returns>A <see cref="CustomerGenre"/> object representing the top genre of the customer. returns null if no customer is found</returns>
    public CustomerGenre? GetTopGenreOfCustomerWithId(int id)
    {
        CustomerGenre customerGenre = null;
        const string query =
            " SELECT TOP 1 c.FirstName, c.LastName,c.CustomerId, t.GenreId, g.Name AS GenreName, COUNT(*) AS TrackCount FROM Customer c JOIN Invoice i ON c.CustomerId = i.CustomerId JOIN InvoiceLine il ON i.InvoiceId = il.InvoiceId JOIN Track t ON il.TrackId = t.TrackId JOIN Genre g ON t.GenreId = g.GenreId WHERE c.CustomerId = @id GROUP BY c.FirstName, c.LastName, c.CustomerId, t.GenreId, g.Name ORDER BY COUNT(*) DESC;";
        using SqlConnection connection = _dbConnection.GetConnection();
        try
        {
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            using SqlDataReader reader = command.ExecuteReader();
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
        catch (SqlException ex)
        {
            Console.WriteLine($"SQL Error: {ex.Message}");
            throw;
        }

        return customerGenre;
    }
}