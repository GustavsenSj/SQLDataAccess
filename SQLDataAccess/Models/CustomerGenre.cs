namespace SQLDataAccess.Models;


/// <summary>
/// Represents an instance of customer and its favorite genre from the Chinook database.
/// </summary>
public class CustomerGenre
{
   public int CustomerId { get; set; }
   public string CustomerName { get; set; }= null!;
   public int GenreId { get; set; }
   public string GenreName { get; set; }= null!;
   public int TrackCount { get; set; }
   
}