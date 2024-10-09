using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using WebApp.Client.Services;
using WebApp.Shared.Dto;
using static WebApp.Client.Common.ClientConstants;

namespace WebApp.Client.Pages
{
    public partial class Home
    {
        /// <summary>
        /// The login service
        /// </summary>
        [Inject]
        public ILoginService? LoginService { get; set; }
        /// <summary>
        /// The user service
        /// </summary>
        [Inject]
        public IUserService? UserService { get; set; }
        /// <summary>
        /// Session storage container.
        /// </summary>
        [Inject]
        public ISessionStorageService? sessionStorage { get; set; }
        /// <summary>
        /// A stirng to hold the bearer token value, after the awaited acquisition.
        /// </summary>
        private string? _bearerToken = null;
        /// <summary>
        /// The login data that will be used to for authentication.
        /// </summary>
        private UserLoginDto _userLoginDto = new();
        /* TMP - DELETE*/
        private List<UserDetailsDto>? _userLoginDtos = null;
        /// <summary>
        /// Attempts to login and retrieve the bearer token.
        /// </summary>
        /// <returns></returns>
        protected async Task Login()
        {
            if (LoginService != null)
            {
                if (sessionStorage != null)
                {
                    this._bearerToken = await LoginService.GetBearer(LoginEndpoint, this._userLoginDto);
                    await sessionStorage.SetItemAsync("bearerToken", this._bearerToken);
                }
            }
        }

        protected async Task ListUsers()
        {
            if (UserService != null)
            {
                if (sessionStorage != null)
                {
                    this._bearerToken = await sessionStorage.GetItemAsync<string>("bearerToken");
                    this._userLoginDtos = await UserService.GetUsers(GetAllUsersEndpoint, this._bearerToken);
                }
            }
        }
    }
}