namespace SQLDataAccess.Models;

public class CustomerSpender
{
   public int CustomerId { get; set; }
   public string FirstName { get; set; }
   public string LastName { get; set; }
   public decimal TotalSpent { get; set; }
}