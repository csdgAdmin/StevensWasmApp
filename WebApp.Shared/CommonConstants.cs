using WebApp.Shared;

namespace WebApp.Shared;

/// <summary>
/// Constants related to the User. This is a stand in for a DB table.
/// </summary>
public class CommonConstants
{
    /// <summary>
    /// A reference to the Mock User Table file. Only for this test file.
    /// </summary>
    public static string MockUserFilePath { get; } = @"\MockDB\MockUserTable.json";
    /// <summary>
    /// A reference to the Mock Media Table file. Only for this test file.
    /// </summary>
    public static string MockMediaFilePath { get; } = @"\MockDB\MockMediaTable.json";
    /// <summary>
    /// A reference to the location where image files are stored.
    /// </summary>
    public static string ImageFilePath { get; } = @"\Images\";
    /// <summary>
    /// The uri for the development server
    /// </summary>
    public static string DevServerUri { get; } = "https://localhost:7138";
    /// <summary>
    /// The name of the endpoint name for the Login API.
    /// </summary>
    public static string LoginEndpoint { get; } = "Login";
    /// <summary>
    /// The name of the endpoint name used to get a list of all users.
    /// </summary>
    public static string GetAllUsersEndpoint { get; } = "User/GetAllUsers";
    /// <summary>
    /// The bearer token that will be used during requests
    /// </summary>
    public string? BearerToken { get; set; } = null;
}
