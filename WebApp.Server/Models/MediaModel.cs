using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Server.Models;
/// <summary>
/// The Media Class
/// </summary>
public class MediaModel
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
    /// Specifies the location of the image file associated with this media.
    /// </summary>
    public string Image { get; set; } = string.Empty;
    /// <summary>
    /// Specifies the location of the data file associated with this media.
    /// </summary>
    public string DataFile { get; set; } = string.Empty;
    /// <summary>
    /// The metadata related to the song. Initially null.
    /// </summary>
    public MediaMetaDataModel? MetaData { get; set; } = null;
}
