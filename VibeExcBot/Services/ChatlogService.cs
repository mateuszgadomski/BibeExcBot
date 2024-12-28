using Microsoft.Web.WebView2.Core;
using System.Text;
using System.Text.Json;
using VibeExcBot.Interfaces;
using VibeExcBot.Models;
using VibeExcBot.Scripts;

namespace VibeExcBot.Services
{
    internal class ChatlogService(IDiscordBotService discordBotService) : IChatlogService
    {
        private static Random _random = new();

        public async Task<List<ChatLogEntry>> GetChatLogEntriesAsync(CoreWebView2WebMessageReceivedEventArgs e)
        {
            var messageJson = e.TryGetWebMessageAsString();
            var chatLogEntries = await Task.Run(() =>
            {
                return JsonSerializer.Deserialize<List<ChatLogEntry>>(messageJson)
                    ?? throw new ArgumentNullException(nameof(messageJson), "JSON nie został przekazany poprawnie.");
            });

            return chatLogEntries.Where(entry => entry.DateCreated <= DateTime.UtcNow.AddHours(1)).ToList();
        }

        public async Task ProcessChatLogEntriesAsync(List<ChatLogEntry> chatLogEntries, IAltVService altService, IChatAIService chatAIService, BotConfiguration config, List<ChatAlert> alerts)
        {
            var recentChatEntries = chatLogEntries.OrderByDescending(entry => entry.DateCreated).Take(5).ToList()
                ?? throw new InvalidOperationException("Wiadomości z chatlogu nie zostały poprawnie załadowane.");

            var chatEntries = chatAIService.GetChatMessages();

            var validChatEntries = recentChatEntries
                .Where(entry => IsValidChatInCharacter(entry, config.CharacterId)
                    && entry.Message != null
                    && !chatEntries.Any(chatEntry => chatEntry.Content.Any(part => part.Text == entry.Message)))
                .ToList();

            var invalidChatEntries = recentChatEntries
               .Where(entry => !IsValidChatInCharacter(entry, config.CharacterId))
               .ToList();

            await SendMessagesToDiscordAsync(validChatEntries, "Najnowsze wiadomości po odświeżeniu", entry => $"[{entry.DateCreated}] {entry.Message}");

            if (config.UseAIresponse && validChatEntries.Count != 0)
            {
                await HandleAIResponseAsync(validChatEntries, config, altService, chatAIService, alerts);
            }

            if (config.UseAutoCharacterActions && _random.Next(100) < 7)
            {
                HandleAutoCharacterActions(config, altService, alerts);
            }

            if (invalidChatEntries.Count != 0)
            {
                await ProcessChatTriggers(invalidChatEntries, altService, config, alerts);
            }

            if (validChatEntries.Count == 0)
            {
                altService.RestoreAltVWindow();
            }
        }

        private static void HandleAutoCharacterActions(BotConfiguration config, IAltVService altService, List<ChatAlert> alerts)
        {
            string action;
            do
            {
                var randomIndex = _random.Next(config.Actions.Count);
                action = config.Actions[randomIndex];
            } while (string.IsNullOrWhiteSpace(action));

            altService.RestoreAltVWindow(action);
            alerts.Add(new ChatAlert() { Action = "Automatyczna akcja", Message = action });
            HandleChatAlerts(config, altService);
        }

        private static async Task HandleAIResponseAsync(List<ChatLogEntry> recentChatEntries, BotConfiguration config, IAltVService altService, IChatAIService chatAIService, List<ChatAlert> alerts)
        {
            var aiResponse = await chatAIService.GetAIResponseAsync(recentChatEntries);
            altService.RestoreAltVWindow(aiResponse);
            alerts.Add(new ChatAlert() { Action = "Odpowiedź AI", Message = aiResponse });
            HandleChatAlerts(config, altService);
        }

        private async Task ProcessChatTriggers(List<ChatLogEntry> chatLogEntries, IAltVService altService, BotConfiguration config, List<ChatAlert> alerts)
        {
            foreach (var entry in chatLogEntries)
            {
                if (IsAlertTriggered(entry, alerts, config.CharacterId))
                {
                    var newAlert = new ChatAlert() { Action = entry.ChatLogTypeName, Message = entry.Message };

                    if (!alerts.Contains(newAlert))
                    {
                        alerts.Add(newAlert);
                        HandleChatAlerts(config, altService);
                    }
                }
            }
            await SendMessagesToDiscordAsync(alerts, "Alerty z logu czatu", alert => $"[{alert.Action}] [{alert.CreatedAt}] {alert.Message}");
        }

        private static void HandleChatAlerts(BotConfiguration config, IAltVService altService)
        {
            if (config.UseChatAlerts)
            {
                altService.NotifyUser();
            }
        }

        private static bool IsAlertTriggered(ChatLogEntry entry, List<ChatAlert> alerts, string characterId)
        {
            return (entry.ChatLogTypeName.Equals("PW", StringComparison.OrdinalIgnoreCase) ||
                    entry.ChatLogTypeName.Equals("Komenda", StringComparison.OrdinalIgnoreCase)) &&
                   !alerts.Any(a => a.Message == entry.Message) && entry.SenderCharacterId.ToString() != characterId;
        }

        public async Task UpdateChatLogViewAsync(List<ChatLogEntry> chatLogEntries, CoreWebView2 webView, Label label)
        {
            var htmlTable = WebViewScripts.GenerateChatLogHtml(chatLogEntries);
            label.Visible = false;
            await webView.ExecuteScriptAsync($"document.body.innerHTML = `{htmlTable}`;");
        }

        public async Task UpdateAlertsViewAsync(CoreWebView2 webView, List<ChatAlert> alerts, Label label)
        {
            var htmlTable = WebViewScripts.GenerateAlertsTableHtml(alerts);
            label.Visible = false;
            await webView.ExecuteScriptAsync($"document.body.innerHTML = `{htmlTable}`;");
        }

        private async Task SendMessagesToDiscordAsync<T>(List<T> items, string header, Func<T, string> formatItem)
        {
            var messageHeader = $"({DateTime.UtcNow:dd-MM-yyyy - HH:mm}) **{header}** :\n";
            var allMessages = new StringBuilder(messageHeader);
            allMessages.Append(string.Join("\n", items.Select(formatItem)));
            await discordBotService.SendPrivateMessageAsync(allMessages.ToString());
        }

        private static bool IsValidChatInCharacter(ChatLogEntry chatlogEntry, string characterId)
        {
            bool isICChat = chatlogEntry.ChatLogTypeName.Equals("czat ic", StringComparison.OrdinalIgnoreCase)
                || chatlogEntry.ChatLogTypeName.Equals("akcja /me", StringComparison.OrdinalIgnoreCase);
            bool isFromDailyGlobe = chatlogEntry.SenderName != null
                && chatlogEntry.SenderName.Contains("Daily Globe", StringComparison.OrdinalIgnoreCase);
            bool isYourCharacter = chatlogEntry.SenderCharacterId != null
                && chatlogEntry.SenderCharacterId.ToString() == characterId;
            return isICChat && !(isFromDailyGlobe || isYourCharacter);
        }
    }
}
