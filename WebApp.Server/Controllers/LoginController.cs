﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApp.Server.MockDB;
using WebApp.Server.Models;

namespace WebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLoginDto loginDto)
        {
            User user = Authenticate(loginDto);
            if(user != null)
            {
                var bearerToken = GenerateToken(user);
                return Ok(bearerToken);
            }
            return NotFound($"User {loginDto.UserName} was not found");
        }

        /// <summary>
        /// Generates a bearer token based on the user. This is for testing purposes only!!
        /// </summary>
        /// <param name="user">The user for whom the token should be generated.</param>
        /// <returns>a string which is can / should be used as the bearer token for the authenticated user.</returns>
        private string GenerateToken(User user)
        {
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!));
            SigningCredentials credeintials = new(securityKey, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new() {
                new(ClaimTypes.NameIdentifier, user.UserName),
                new(ClaimTypes.Email, user.EmailAddress),
                new(ClaimTypes.GivenName, user.FirstName),
                new(ClaimTypes.Surname, user.LastName),
                new(ClaimTypes.Role, user.Role)
            };
            JwtSecurityToken token = new(_config["JwtSettings:Issuer"],
                                         _config["JwtSettings:Audience"],
                                         claims,
                                         expires: DateTime.Now.AddMinutes(10),
                                         signingCredentials: credeintials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Performs operations related to user authentication given login data.
        /// </summary>
        /// <param name="loginDto">The data to be used to login</param>
        /// <returns>A user object representing the authenticated individual</returns>
        private User? Authenticate(UserLoginDto loginDto)
        {
            return UserConstants.Users.FirstOrDefault(user =>
                                                      loginDto.UserName.ToUpper() == user.UserName.ToUpper()
                                                      && loginDto.PassWord == user.PassWord);
        }
    }
}
