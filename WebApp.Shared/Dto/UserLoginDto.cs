namespace WebApp.Shared.Dto;

/// <summary>
/// An object specifically for login in activity, which contains only the username and password.
/// </summary>
public class UserLoginDto
{
    /// <summary>
    /// The unique username.
    /// </summary>
    public string UserName { get; set; } = string.Empty;
    /// <summary>
    /// The individual's password.
    /// </summary>
    public string PassWord { get; set; } = string.Empty;
}
