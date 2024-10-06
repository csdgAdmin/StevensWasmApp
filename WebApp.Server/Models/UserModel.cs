﻿namespace WebApp.Server.Models;

/// <summary>
/// User related properties.
/// </summary>
public class UserModel
{
    /// <summary>
    /// The unique username.
    /// </summary>
    public string UserName { get; set; } = string.Empty;
    /// <summary>
    /// The individual's password.
    /// </summary>
    public string PassWord { get; set; } = string.Empty;
    /// <summary>
    /// The individual's e-mail address.
    /// </summary>
    public string EmailAddress { get; set; } = string.Empty;
    /// <summary>
    /// The individual's security role.
    /// </summary>
    public string Role { get; set; } = string.Empty;
    /// <summary>
    /// The individual's first name.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// The individual's last name.
    /// </summary>
    public string LastName { get; set; } = string.Empty;
}