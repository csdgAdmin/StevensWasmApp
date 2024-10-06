using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Shared.Dto
{
    public class BasicSongDto
    {
        /// <summary>
        /// The title of the song.
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// A brief description of the media, this should be unique.
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
