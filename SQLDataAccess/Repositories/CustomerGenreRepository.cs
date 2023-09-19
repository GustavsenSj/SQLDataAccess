using Microsoft.Data.SqlClient;
using SQLDataAccess.DB;
using SQLDataAccess.Models;

namespace SQLDataAccess.Repositories;

public class CustomerGenreRepository
{
    private readonly DatabaseConnection _dbConnection;

    public CustomerGenreRepository(DatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
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