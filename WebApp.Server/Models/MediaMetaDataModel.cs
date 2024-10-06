namespace WebApp.Server.Models;

public class MediaMetaDataModel
{
    /// <summary>
    /// Release date, nullable if unreleased.
    /// </summary>
    public DateTime? ReleaseDate { get; set; } = null;
    /// <summary>
    /// The date the song was added to the app.
    /// </summary>
    public DateTime AdditionDate { get; set; }
    /// <summary>
    /// The name of the artist.
    /// </summary>
    public string ArtistName { get; set; } = string.Empty;
    /// <summary>
    /// A rating for the song where 1 is very bad and 5 is very good.
    /// </summary>
    public int Rating { get; set; }
}
