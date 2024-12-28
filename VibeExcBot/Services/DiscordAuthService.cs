using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using VibeExcBot.Interfaces;
using VibeExcBot.Models;
using VibeExcBot.Utilities.Encryption;

namespace VibeExcBot.Services
{
    internal class DiscordAuthService : IDiscordAuthService
    {
        private readonly string _clientId = EncryptionHelper.GetEnvironmentWithDecrypt("D_C_ID_ENCRYPTED");
        private readonly string _clientSecret = EncryptionHelper.GetEnvironmentWithDecrypt("D_C_S_ID_ENCRYPTED");
        private readonly string _redirectUri = "https://localhost:44300/callback";
        private readonly string _discordAuthorizeUrl = "https://discord.com/api/oauth2/authorize";
        private readonly string _discordTokenUrl = "https://discord.com/api/oauth2/token";
        private readonly string _discordUserUrl = "https://discord.com/api/users/@me";
        private readonly HttpClient _httpClient = new();
        private readonly HttpListener _httpListener = new();
        private DiscordUserResponse _discordUserResponse;

        private string _discordAuthorizeUrlWithParameters => $"{_discordAuthorizeUrl}?client_id={_clientId}&redirect_uri={Uri.EscapeDataString(_redirectUri)}&response_type=code&scope=identify email";

        public async Task<string> StartHttpListenerAsync()
        {
            _httpListener.Prefixes.Add(_redirectUri + "/");
            _httpListener.Start();

            var context = await _httpListener.GetContextAsync();
            var request = context.Request;
            var response = context.Response;
            response.ContentType = "text/html; charset=utf-8";
            string responseString = "<html><body>Możesz zamknąć kartę i wrócić do aplikacji.</body></html>";
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.OutputStream.Close();

            _httpListener.Stop();

            return request.QueryString["code"] ?? throw new InvalidOperationException("Brak kodu autoryzacji w zapytaniu.");
        }

        public async Task AuthenticateAsync(IDiscordBotService discordBotService)
        {
            await discordBotService.ConnectAsync();

            Process.Start(new ProcessStartInfo
            {
                FileName = _discordAuthorizeUrlWithParameters,
                UseShellExecute = true
            });

            string code = await StartHttpListenerAsync();

            if (string.IsNullOrEmpty(code))
            {
                throw new InvalidOperationException("Nie udało się uzyskać kodu autoryzacji.");
            }

            var tokenResponse = await GetTokenAsync(code);
            _discordUserResponse = await GetUserInfoAsync(tokenResponse.AccessToken);

            await discordBotService.GetGuildMemberAsync(1299479911546880102, _discordUserResponse.Id);
        }

        public async Task<DiscordTokenResponse> GetTokenAsync(string code)
        {
            var requestBody = new StringContent($"client_id={_clientId}&client_secret={_clientSecret}&grant_type=authorization_code&code={code}&redirect_uri={Uri.EscapeDataString(_redirectUri)}", Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await _httpClient.PostAsync(_discordTokenUrl, requestBody);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DiscordTokenResponse>(responseString)
                ?? throw new InvalidOperationException($"Błąd serializacji {responseString}");
        }

        public async Task<DiscordUserResponse> GetUserInfoAsync(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _httpClient.GetAsync(_discordUserUrl);
            response.EnsureSuccessStatusCode();

            var userInfo = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DiscordUserResponse>(userInfo)
                ?? throw new InvalidOperationException($"Błąd serializacji: {userInfo}");
        }

        public DiscordUserResponse GetDiscordUser()
            => _discordUserResponse;
    }
}
