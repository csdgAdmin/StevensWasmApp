using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Shared.Dto;

public class UserDetailsDto
{
    /// <summary>
    /// The unique username.
    /// </summary>
    public string UserName { get; set; } = string.Empty;
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
