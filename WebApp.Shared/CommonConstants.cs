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
}
