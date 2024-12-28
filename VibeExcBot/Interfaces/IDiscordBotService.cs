using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace VibeExcBot.Interfaces
{
    public interface IDiscordBotService
    {
        Task ConnectAsync();

        CommandsNextExtension GetCommandsNextExtension();

        Task<DiscordMember> GetGuildMemberAsync(ulong guildId, ulong userId);

        Task SendPrivateMessageAsync(string message);
    }
}
