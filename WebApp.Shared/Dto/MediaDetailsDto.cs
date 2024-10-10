using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Shared.Dto;

/// <summary>
/// An object that communications only the title, description and image location for a piece of media.
/// </summary>
public class MediaDetailsDto
{
    /// <summary>
    /// The title of the media.
    /// </summary>
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// A brief description of the media, this should be unique.
    /// </summary>
    public string Description { get; set; } = string.Empty;
}
