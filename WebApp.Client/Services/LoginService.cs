using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using WebApp.Shared.Dto;

namespace WebApp.Client.Services;

public interface ILoginService
{
    Task<string> GetBearer(string endPointUrl, UserLoginDto userLoginDto);
}

/// <summary>
/// A service to perform log in activities.
/// </summary>
public class LoginService : ILoginService
{
    /// <summary>
    /// Local httpClient instance.
    /// </summary>
    private readonly HttpClient _httpClient;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="httpClient"></param>
    public LoginService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    /// <summary>
    /// Get the bearer token given the appropriate parameters.
    /// </summary>
    /// <param name="endPointUrl">The request endpoint for token retrieval.</param>
    /// <param name="userLoginDto">The UserLoginDto object containing the username and password.</param>
    /// <returns>A string containing the bearer token, when successful, null when unsuccessful.</returns>
    public async Task<string> GetBearer(string endPointUrl, UserLoginDto userLoginDto)
    {
        string fullAddress = string.Join("api/", this._httpClient.BaseAddress, endPointUrl);
        try
        {
            /* Await the response read activity to increase
             * likelyhood of blocking until bearer is formed  retrieved
             */
            HttpResponseMessage? response = await this._httpClient.PostAsJsonAsync($"{fullAddress}", userLoginDto);
            string? bearer = await response.Content.ReadAsStringAsync();
            return bearer;
        }
        catch (Exception exception)
        {
            exception.ToString();
            return null;
        }
    }

}
