using System.Net;
using System.Net.Http.Headers;
using Botvex.DB.Models;
using Botvex.osu.Services.Interfaces;
using Newtonsoft.Json;

namespace Botvex.osu.Services;

public class OsuApiService : IOsuApiService
{
    private readonly HttpClient _httpClient;
    private const string BaseAddress = "https://osu.ppy.sh/api/v2";

    public OsuApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Beatmap> GetBeatmap(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Beatmapset> GetBeatmapset(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUser(int id)
    {
        var request = new HttpRequestMessage()
        {
            RequestUri = new Uri($"{BaseAddress}/users/{id}"),
            Method = HttpMethod.Get
        };
        
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Headers.Authorization = new AuthenticationHeaderValue(await GetBearerToken());

        var response = await _httpClient.SendAsync(request);
        
        var body = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());

        return body ?? new User();
    }

    private async Task<string> GetBearerToken()
    {
        var request = new HttpRequestMessage()
        {
            RequestUri = new Uri("https://osu.ppy.sh/oauth/token"),
            Method = HttpMethod.Post
        };
        
        
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        // request.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
        
        //Todo: store these credentials in the appsettings
        var content = new Dictionary<string, string>();
        content.Add("client_id", "28349");
        content.Add("client_secret", "zO5U5ABjU1fZJ12AzT7tS6goxoxB6TkjEBox2lH8");
        content.Add("grant_type", "client_credentials");
        content.Add("scope", "public");
        
        request.Content = new FormUrlEncodedContent(content);

        var response = await _httpClient.SendAsync(request);
        var responseBody = JsonConvert.DeserializeObject<AuthSuccess>(await response.Content.ReadAsStringAsync());

        if (responseBody is null)
        {
            return JsonConvert.DeserializeObject<AuthFailure>(await response.Content.ReadAsStringAsync())!.error;
        }

        return "Bearer " + responseBody.access_token;
    }

    private class AuthSuccess
    {
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string access_token { get; set; }
    }

    private class AuthFailure
    {
        public string error { get; set; }
        public string error_description { get; set; }
        public string message { get; set; }
    }
}