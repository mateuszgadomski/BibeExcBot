using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Exceptions;
using System.Diagnostics;
using VibeExcBot.Interfaces;
using VibeExcBot.Utilities.DiscordBot.Commands;
using VibeExcBot.Utilities.Encryption;

namespace VibeExcBot.Services
{
    public class DiscordBotService(IServiceProvider serviceProvider, IDiscordAuthService discordAuthService) : IDiscordBotService
    {
        private DiscordClient _discordClient;
        private CommandsNextExtension _commandsNextExtension;

        private readonly string _token = EncryptionHelper.GetEnvironmentWithDecrypt("D_B_T_ENCRYPTED");
        private readonly string _prefix = "!";
        private readonly string _appVersion = "0.1.0-beta";

        public async Task ConnectAsync()
        {
            InitializeDiscordClient();
            InitializeCommandsNext(serviceProvider);
            await CheckForUpdatesAsync();

            await _discordClient.ConnectAsync();
        }

        private void InitializeDiscordClient()
        {
            var discordConfig = new DiscordConfiguration
            {
                Intents = DiscordIntents.All,
                Token = _token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };

            _discordClient = new DiscordClient(discordConfig);
            _discordClient.Ready += DiscordClient_Ready;
        }

        private void InitializeCommandsNext(IServiceProvider serviceProvider)
        {
            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = [_prefix],
                Services = serviceProvider,
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false
            };

            _commandsNextExtension = _discordClient.UseCommandsNext(commandsConfig);
            _commandsNextExtension.RegisterCommands<DiscordCommands>();
        }

        private Task DiscordClient_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }

        public async Task SendPrivateMessageAsync(string message)
        {
            if (_discordClient == null)
            {
                throw new InvalidOperationException("Discord bot nie jest podłączony.");
            }

            try
            {
                var userId = discordAuthService.GetDiscordUser().Id;

                var guild = await _discordClient.GetGuildAsync(1299479911546880102);
                var member = await guild.GetMemberAsync(userId);
                var dmChannel = await member.CreateDmChannelAsync();
                await dmChannel.SendMessageAsync(message);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Nie udało się wysłać wiadomości prywatnej: {ex.Message}", ex);
            }
        }

        public async Task<DiscordMember> GetGuildMemberAsync(ulong guildId, ulong userId)
        {
            var guild = await _discordClient.GetGuildAsync(guildId)
                ?? throw new InvalidOperationException($"Serwer o id {guildId} nie został znaleziony.");

            try
            {
                return await guild.GetMemberAsync(userId);
            }
            catch (NotFoundException)
            {
                var result = MessageBox.Show("Nie masz dostępu do tej aplikacji, ponieważ nie jesteś członkiem serwera. Kliknij OK, aby dołączyć.", "Błąd", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    Process.Start(new ProcessStartInfo("https://discord.gg/UaXQzhDg") { UseShellExecute = true });
                }

                throw new UnauthorizedAccessException("Uruchom aplikację ponownie po dołączeniu do serwera Discord.");
            }
        }

        public async Task CheckForUpdatesAsync()
        {
            var application = await _discordClient.GetCurrentApplicationAsync();

            if (application.Description != _appVersion)
            {
                MessageBox.Show($"Posiadasz wersję: {_appVersion}, a jest dostępna nowsza: {application.Description}");
            }
        }

        public CommandsNextExtension GetCommandsNextExtension()
            => _commandsNextExtension;
    }
}
