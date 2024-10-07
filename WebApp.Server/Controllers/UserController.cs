using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using WebApp.Server.MockDB;
using WebApp.Server.Models;
using WebApp.Shared.Dto;

namespace WebApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    /// <summary>
    /// Get details about the current user's identity.
    /// </summary>
    /// <returns>An object containing details about the current user's identity.</returns>
    [Authorize]
    [HttpGet("GetMyUserDetails")]
    public UserDetailsDto? GetUserDetails()
    {
        UserModel? user = GetCurrentUser();
        /*ToDo: Use the mapper*/
        if(user != null)
        {
            return new()
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                Role = user.Role
            };
        }
        return null;
    }

    /// <summary>
    /// Get a collection of user details for all users.
    /// </summary>
    /// <returns>A list containing details about the all user identity.</returns>
    [Authorize(Roles = "Administrator, PowerUser")]
    [HttpGet("GetAllUserDetails")]
    public List<UserDetailsDto?>? GetAllUserDetails()
    {
        List<UserModel>? userModels = UserConstants.Users;
        if(userModels != null && userModels.Count > 0)
        {
            List<UserDetailsDto?> userDetailDtos = new();
            foreach (UserModel userModel in userModels)
            {
                userDetailDtos.Add(new() {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    UserName = userModel.UserName,
                    EmailAddress = userModel.EmailAddress,
                    Role = userModel.Role
                });
            }
            return userDetailDtos;
        }
        return null;
    }

    /// <summary>
    /// Get the current user identity.
    /// </summary>
    /// <returns>A user model representing the individual using the application.</returns>
    private UserModel? GetCurrentUser()
    {
        ClaimsIdentity? userIdentity = HttpContext.User.Identity as ClaimsIdentity;
        if (userIdentity != null)
        {
            IEnumerable<Claim> userClaims = userIdentity.Claims;
            return new()
            {
                UserName = userClaims.FirstOrDefault(uClaim => uClaim.Type == ClaimTypes.NameIdentifier)?.Value!,
                EmailAddress = userClaims.FirstOrDefault(uClaim => uClaim.Type == ClaimTypes.Email)?.Value!,
                FirstName = userClaims.FirstOrDefault(uClaim => uClaim.Type == ClaimTypes.GivenName)?.Value!,
                LastName = userClaims.FirstOrDefault(uClaim => uClaim.Type == ClaimTypes.Surname)?.Value!,
                Role = userClaims.FirstOrDefault(uClaim => uClaim.Type == ClaimTypes.Role)?.Value!,
            };
        }

        else
        return null;
    }
}
