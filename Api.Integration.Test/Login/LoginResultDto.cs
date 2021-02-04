using System;
using Newtonsoft.Json;

namespace Api.Integration.Test.Login
{
    public class LoginResultDto
    {
        [JsonProperty("authenticated")]
        public bool Authenticated { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        [JsonProperty("acessToken")]
        public string AcessToken { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
