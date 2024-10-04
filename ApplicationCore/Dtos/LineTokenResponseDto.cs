using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Dtos
{
    public class LineTokenResponseDto
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }      // 用來呼叫 LINE API 的 access_token

        [JsonProperty("token_type")]
        public string TokenType { get; set; }        // 類型，通常為 "Bearer"

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }           // Token 有效時間 (秒)

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }     // 用來刷新 access_token 的 refresh_token

        [JsonProperty("scope")]
        public string Scope { get; set; }            // 權限範圍

        [JsonProperty("id_token")]
        public string IdToken { get; set; }          // (Optional) 若要求 OpenID Connect，也會回傳 id_token
    }
}
