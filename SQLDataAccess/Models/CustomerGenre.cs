namespace SQLDataAccess.Models;

public class CustomerGenre
{
   public int CustomerId { get; set; }
   public string CustomerName { get; set; }
   public int GenreId { get; set; }
   public string GenreName { get; set; }
   public int TrackCount { get; set; }
   
}