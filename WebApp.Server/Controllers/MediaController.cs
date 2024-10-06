using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Server.Models;
using WebApp.Shared.Dto;

namespace WebApp.Server.Controllers
{
    /// <summary>
    /// This controller is responsible for media related activity.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        /// <summary>
        /// Find the appropriate song object based on the arguments provided.
        /// </summary>
        /// <param name="title">The title of the song to be retrieved.</param>
        /// <param name="description">The description of the song to be retrieved.</param>
        /// <returns>An Http response and serialized data containing the appropriate object.</returns>
        [HttpGet]
        public IActionResult GetBasicSongData(string title, string description)
        {

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description))
            {
                return BadRequest("Invalid parameter vlaue");
            }
            /* Perform a linq look up for the desired song
             * object and type
             */
            else
            {
                return Ok(new BasicSongDto()
                {
                    Title = title,
                    Description = description
                });
            }
        }
    }
}
