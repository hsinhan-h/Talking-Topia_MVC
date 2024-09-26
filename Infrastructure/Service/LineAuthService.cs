using ApplicationCore.Dtos;
using ApplicationCore.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class LineAuthService : ILineAuthService
    {
        private readonly string _clientId = "2006372467";
        private readonly string _clientSecret = "1f42c2be3fd2e8783b2bcfc13370a584";
        private readonly string _redirectUri = "https://localhost:7263/Account/SSOcallback";

        public async Task<string> GetAccessTokenAsync(string code)
        {
            using (var httpClient = new HttpClient())
            {
                var requestContent = new FormUrlEncodedContent(new[]
                {
                            new KeyValuePair<string, string>("grant_type", "authorization_code"),
                            new KeyValuePair<string, string>("code", code),
                            new KeyValuePair<string, string>("redirect_uri", _redirectUri),
                            new KeyValuePair<string, string>("client_id", _clientId),
                            new KeyValuePair<string, string>("client_secret", _clientSecret)
                        });

                var response = await httpClient.PostAsync("https://api.line.me/oauth2/v2.1/token", requestContent);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var tokenResponse = JsonConvert.DeserializeObject<LineTokenResponseDto>(responseContent);
                    return tokenResponse.AccessToken; // Fix: Changed 'access_token' to 'AccessToken'
                }
                else
                {
                    // 在這裡記錄錯誤訊息，並查看完整的回應
                    throw new Exception($"Failed to retrieve access token. Response status code: {response.StatusCode}, Response content: {responseContent}");
                }
            }
        }

        public async Task<LineUserProfileDto> GetUserProfileAsync(string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await httpClient.GetAsync("https://api.line.me/v2/profile");

                if (response.IsSuccessStatusCode)
                {
                    var profileContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<LineUserProfileDto>(profileContent);
                }
                else
                {
                    throw new Exception("Failed to retrieve user profile");
                }
            }
        }
    }

}
