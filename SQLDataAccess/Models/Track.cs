namespace SQLDataAccess.Models;

/// <summary>
/// Represents an instance of track from the Chinook database.
/// </summary>
public class Track
{
   private int TrackId { get; set; } 
   private string Name { get; set; }= null!;
   private int AlbumId { get; set; }
   private int MediaTypeId { get; set; }
   private int GenreId { get; set; }
   private string? Composer { get; set; }
   private int Milliseconds { get; set; }
   private int Bytes { get; set; }
   private double UnitPrice { get; set; }
}