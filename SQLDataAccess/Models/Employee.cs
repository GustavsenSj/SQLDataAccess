namespace SQLDataAccess.Models;

/// <summary>
/// Represents an instance of a employee in the Chinook database.
/// </summary>
public class Employee
{
   private int EmployeeId { get; set; } 
   private string FirstName { get; set; }
   private string LastName { get; set; }
   private string? Title { get; set; }
   private int? ReportsTo { get; set; }
   private string? BirthDate { get; set; }
   private string? HireDate { get; set; }
   private string? Address { get; set; }
   private string? City { get; set; }
   private string? State { get; set; }
   private string? Country { get; set; }
   private string? PostalCode { get; set; }
   private string? Phone { get; set; }
   private string? Fax { get; set; }
   private string? Email { get; set; }
}