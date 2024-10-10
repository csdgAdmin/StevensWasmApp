using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Server.Models;
using WebApp.Shared;
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
    [AllowAnonymous]
    [HttpGet("GetUser/{userName}")]
    public UserDetailsDto? GetUserDetails(string userName)
    {
        UserModel? userModel = new();

        if (string.IsNullOrWhiteSpace(userName))
        {
            userModel = GetCurrentUser();
        }
        else
        {
            ObjBuilder objBuilder = new();
            List<UserModel>? userModels = objBuilder.BuildObjFromJsonFile<List<UserModel>?>($"{Directory.GetCurrentDirectory()}{CommonConstants.MockUserFilePath}");
            if (userModels != null && userModels.Count > 0)
            {
                userModel = userModels.Find(selectedUser => selectedUser.UserName.ToUpper() == userName.ToUpper());
            }
        }


        if (userModel != null)
        {
            return new()
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                EmailAddress = userModel.EmailAddress,
                Role = userModel.Role
            };
        }

        return null;
    }

    /// <summary>
    /// Get a collection of user details for all users.
    /// </summary>
    /// <returns>A list containing details about the all user identity.</returns>
    [AllowAnonymous]
    [HttpGet("GetAllUsers")]
    public List<UserDetailsDto>? GetAllUsers()
    {
        ObjBuilder objBuilder = new();
        List<UserModel>? userModels = objBuilder.BuildObjFromJsonFile<List<UserModel>?>($"{Directory.GetCurrentDirectory()}{CommonConstants.MockUserFilePath}");
        if (userModels != null && userModels.Count > 0)
        {
            List<UserDetailsDto>? userDetailDtos = new();
            foreach (UserModel userModel in userModels)
            {
                userDetailDtos.Add(new()
                {
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
    /// Get details about media that relates to the given title.
    /// </summary>
    /// <returns>A collection of objects that match the title provided.</returns>
    [AllowAnonymous]
    [HttpGet("GetMedia/Title/{title}")]
    public List<MediaDetailsDto>? GetMediaByTitle(string title)
    {
        List<MediaDetailsDto>? mediaDetailDtos = new();

        if (string.IsNullOrWhiteSpace(title))
        {
            return null;
        }
        else
        {
            ObjBuilder objBuilder = new();
            List<MediaModel>? mediaModels = objBuilder.BuildObjFromJsonFile<List<MediaModel>?>($"{Directory.GetCurrentDirectory()}{CommonConstants.MockMediaFilePath}");
            if (mediaModels != null && mediaModels.Count > 0)
            {
                foreach(MediaModel mediaModel in mediaModels)
                {
                    if(mediaModel.Title == title)
                    {
                        mediaDetailDtos.Add(new() {
                            Title = mediaModel.Title,
                            Description = mediaModel.Description
                        });

                    }
                }
                return mediaDetailDtos;
            }
        }
        return null;
    }
    /// <summary>
    /// Get a collection of all media.
    /// </summary>
    /// <returns>A list containing details about the all media.</returns>
    [AllowAnonymous]
    [HttpGet("GetAllMedia")]
    public List<MediaDetailsDto>? GetAllMedia()
    {
        ObjBuilder objBuilder = new();
        List<MediaModel>? mediaModels = objBuilder.BuildObjFromJsonFile<List<MediaModel>?>($"{Directory.GetCurrentDirectory()}{CommonConstants.MockMediaFilePath}");
        if (mediaModels != null && mediaModels.Count > 0)
        {
            List<MediaDetailsDto>? mediaDetailsDtos = new();
            foreach (MediaModel mediaModel in mediaModels)
            {
                mediaDetailsDtos.Add(new()
                {
                    Title = mediaModel.Title,
                    Description = mediaModel.Description
                });
            }
            return mediaDetailsDtos;
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
