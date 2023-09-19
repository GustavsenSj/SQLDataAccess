namespace SQLDataAccess.Models;

/// <summary>
/// Represents an instance of invoice line from the Chinook database.
/// </summary>
public class InvoiceLine
{
    private int InvoiceLineId { get; set; }
    private int InvoiceId { get; set; }
    private int TrackId { get; set; }
    private double UnitPrice { get; set; }
    private int Quantity { get; set; }
}