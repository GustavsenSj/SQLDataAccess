namespace SQLDataAccess.Models;

/// <summary>
/// Represents an instance of customer count by country from the Chinook database.
/// </summary>
public class CustomerCountry
{
    public string Country { get; set; }= null!;
    public int Count { get; set; }
}