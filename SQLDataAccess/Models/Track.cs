namespace SQLDataAccess.Models;

public class Track
{
   private int TrackId { get; set; } 
   private string Name { get; set; }
   private int AlbumId { get; set; }
   private int MediaTypeId { get; set; }
   private int GenreId { get; set; }
   private string? Composer { get; set; }
   private int Milliseconds { get; set; }
   private int Bytes { get; set; }
   private double UnitPrice { get; set; }
}