using VibeExcBot.Models;

namespace VibeExcBot.Interfaces
{
    public interface IDiscordAuthService
    {
        Task AuthenticateAsync(IDiscordBotService discordBotService);

        Task<DiscordTokenResponse> GetTokenAsync(string code);

        Task<DiscordUserResponse> GetUserInfoAsync(string accessToken);

        DiscordUserResponse GetDiscordUser();
    }
}
