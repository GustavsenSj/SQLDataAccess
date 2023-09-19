namespace SQLDataAccess.Models;

/// <summary>
/// Represents an instance of customer and its total spending's from the Chinook database.
/// </summary>
public class CustomerSpender
{
   public int CustomerId { get; set; }
   public string FirstName { get; set; }
   public string LastName { get; set; }
   public decimal TotalSpent { get; set; }
}