using Newtonsoft.Json;

namespace VibeExcBot.Models
{
    public class DiscordTokenResponse
    {
        [JsonProperty("access_token")]
        public required string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public required string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public required string RefreshToken { get; set; }

        [JsonProperty("scope")]
        public required string Scope { get; set; }
    }
}
