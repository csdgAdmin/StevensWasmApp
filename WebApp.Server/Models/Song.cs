namespace WebApp.Server.Models;

public class Song
{
    /// <summary>
    /// The title of the song.
    /// </summary>
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// A brief description of the media, this should be unique.
    /// </summary>
    public string Description { get; set; } = string.Empty;
    /// <summary>
    /// The metadata related to the song. Initially null.
    /// </summary>
    public SongMetaData? SongMetaData { get; set; } = null;
}
