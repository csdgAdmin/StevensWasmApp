using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Shared.Dto;

/// <summary>
/// An object that communications only the title, description and image location for a piece of media.
/// </summary>
public class BasicMediaDataDto
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
    /// The location of the image associated with this media
    /// </summary>
    public string ImagLocation { get; set; } = string.Empty;
}
