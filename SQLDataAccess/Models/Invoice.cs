namespace SQLDataAccess.Models;

public class Invoice
{
   private int InvoiceId { get; set; } 
   private string InvoiceDate { get; set; } 
   private string? BillingAddress { get; set; } 
   private string? BillingCity { get; set; } 
   private string? BillingState { get; set; } 
   private string? BillingCountry { get; set; } 
   private string? BillingPostalCode { get; set; } 
   private double Total { get; set; } 
}