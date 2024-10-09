namespace WebApp.Client.Common
{
    public class ClientConstants
    {   
        /// <summary>
        /// The uri for the development server
        /// </summary>
        public static string DevServerUri { get; } = "https://localhost:7138";
        /// <summary>
        /// The name of the endpoint name for the Login API.
        /// </summary>
        public static string LoginEndpoint { get;} = "Login";
        /// <summary>
        /// The name of the endpoint name used to get a list of all users.
        /// </summary>
        public static string GetAllUsersEndpoint { get; } = "User/GetAllUsers";
        /// <summary>
        /// The bearer token that will be used during requests
        /// </summary>
        public string? BearerToken { get; set; } = null;
    }
}
