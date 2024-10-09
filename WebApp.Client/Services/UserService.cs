using Blazored.SessionStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using WebApp.Shared.Dto;

namespace WebApp.Client.Services
{
    public interface IUserService
    {
        Task<List<UserDetailsDto>?> GetUsers(string endPointUri, string bearerToken);
    }

    public class UserService : IUserService
    {
        /// <summary>
        /// Local httpClient instance.
        /// </summary>
        private readonly HttpClient _httpClient;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient"></param>
        public UserService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<UserDetailsDto>?> GetUsers(string endPointUri, string bearerToken)
        {
            string fullAddress = string.Join("api/", this._httpClient.BaseAddress, endPointUri);
            try
            {
                this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                HttpResponseMessage? response = await this._httpClient.GetAsync($"{fullAddress}");
                string? userDtosString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<UserDetailsDto>>(userDtosString);
            }
            catch (Exception exception)
            {
                exception.ToString();
                return null;
            }
        }
    }
}
