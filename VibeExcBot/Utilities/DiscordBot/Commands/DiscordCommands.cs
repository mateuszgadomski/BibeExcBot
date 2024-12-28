using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using VibeExcBot.Interfaces;

namespace VibeExcBot.Utilities.DiscordBot.Commands
{
    public class DiscordCommands(IChatAIService chatAIService, IAltVService altVService, IConfigService configService) : BaseCommandModule
    {
        [Command("exit")]
        public async Task ExitCommand(CommandContext ctx)
        {
            await ctx.RespondAsync("Aplikacja została wyłączona.");
            Application.Exit();
        }

        [Command("clear")]
        public async Task ClearCommand(CommandContext ctx)
        {
            chatAIService.ClearRecentMessages();
            await ctx.RespondAsync("Kontekst wcześniejszej rozmowy oraz wiadomości do AI zostały zresetowane.");
        }

        [Command("send")]
        public async Task SendCommand(CommandContext ctx, [RemainingText] string message)
        {
            altVService.RestoreAltVWindow(message);
            await ctx.RespondAsync($"**Wiadomość wysłana na czacie:** {message}");
        }

        [Command("ai")]
        public async Task ToggleAIResponse(CommandContext ctx)
        {
            var config = configService.LoadConfigFile();
            config.UseAIresponse = !config.UseAIresponse;
            configService.UpdateConfigFile(config);
            await ctx.RespondAsync($"Zmieniłeś działanie odpowiedzi AI na {config.UseAIresponse}");
        }
    }
}
