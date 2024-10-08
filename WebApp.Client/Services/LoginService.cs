using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using WebApp.Shared.Dto;

namespace WebApp.Client.Services;

public interface ILoginService
{
    Task<string> GetBearer(string endPointUrl);
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
    /// <returns>A string containing the bearer token for the caller.</returns>
    public async Task<string> GetBearer(string endPointUrl)
    {
        UserLoginDto userLoginDto = new() { 
            UserName = "UserOne",
            PassWord = "PasswordOne"
        };
        string fullAddress = "https://localhost:7138/api/Login"; //string.Join("api/", this._httpClient.BaseAddress, endPointUrl);
        try
        {
            var response = await this._httpClient.PostAsJsonAsync($"{fullAddress}", userLoginDto);
            string? bearer = response.Content.ToString();
            //string bearer = await this._httpClient.GetFromJsonAsync<string>($"{fullAddress}/{userLoginDto}");
            return bearer.ToString();
        }
        catch (Exception exception)
        {
            return null;
        }
    }

}
