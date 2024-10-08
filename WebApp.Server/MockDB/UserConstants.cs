using WebApp.Server.Models;

namespace WebApp.Server.MockDB;

/// <summary>
/// Constants related to the User. This is a stand in for a DB table.
/// </summary>
public class UserConstants
{
    /// <summary>
    /// A reference to the Mock User Table file. Only for this test file.
    /// </summary>
    public static string MockUserFilePath { get; } = @"\MockDB\MockUserTable.json";
}
