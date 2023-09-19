namespace SQLDataAccess.Models;
/// <summary>
/// Represents an album in the music database.
/// </summary>

public class Album
{
    private int AlbumId { get; set; }
    private string? Title { get; set; }
    private int ArtistId { get; set; }
}

