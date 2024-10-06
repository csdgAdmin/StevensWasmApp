namespace WebApp.Server.MockDB
{
    public class MediaTypeConstants
    {
        /// <summary>
        /// A list specifying valid media types for this application.
        /// </summary>
        public static List<string> MediaTypes = new()
        {
            "Movie",
            "Song",
            "Video Game",
            /* A collection of songs published by an artist*/
            "Album",
            /* A collection of media created by the individual*/
            "Play List"
        };
    }
}
