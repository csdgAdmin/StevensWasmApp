using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Server.Models;

public class Media
{
    /// <summary>
    /// The title of the song.
    /// </summary>
    [Required]
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// A brief description of the media, this should be unique.
    /// </summary>
    [Required]
    public string Description { get; set; } = string.Empty;
    /// <summary>
    /// Specifies the type of media. Ideally, this will be sourced from a prepopulated list.
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// The metadata related to the song. Initially null.
    /// </summary>
    public MediaMetaData? SongMetaData { get; set; } = null;
    /// <summary>
    /// Nullable reference to the content related to this media
    /// </summary>
    public byte[]? Data { get; set; } = null;
}
