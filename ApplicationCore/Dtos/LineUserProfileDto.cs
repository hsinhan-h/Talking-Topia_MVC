using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Dtos
{
    public class LineUserProfileDto
    {
        [JsonProperty("userId")]
        public string LineUserId { get; set; } // 使用者的 LINE userId

        [JsonProperty("displayName")]
        public string DisplayName { get; set; } // 使用者的暱稱

        [JsonProperty("email")]
        public string Email { get; set; } // 使用者的 Email（注意：LINE 通常不會提供 email，只有在特定 scope 下才有可能獲取）

        [JsonProperty("pictureUrl")]
        public string PictureUrl { get; set; } // 使用者的頭像圖片 URL

        [JsonProperty("statusMessage")]
        public string StatusMessage { get; set; } // 使用者的狀態訊息
    }
}
