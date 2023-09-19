namespace SQLDataAccess.Models;

/// <summary>
/// Represents an instance of an invoice from the Chinook database.
/// </summary>
public class Invoice
{
   private int InvoiceId { get; set; } 
   private string InvoiceDate { get; set; } = null!;
   private string? BillingAddress { get; set; } 
   private string? BillingCity { get; set; } 
   private string? BillingState { get; set; } 
   private string? BillingCountry { get; set; } 
   private string? BillingPostalCode { get; set; } 
   private double Total { get; set; } 
}