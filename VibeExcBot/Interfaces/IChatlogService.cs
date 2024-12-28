using Microsoft.Web.WebView2.Core;
using VibeExcBot.Models;

namespace VibeExcBot.Interfaces
{
    public interface IChatlogService
    {
        Task<List<ChatLogEntry>> GetChatLogEntriesAsync(CoreWebView2WebMessageReceivedEventArgs e);

        Task ProcessChatLogEntriesAsync(List<ChatLogEntry> chatLogEntries, IAltVService altService, IChatAIService chatAIService, BotConfiguration config, List<ChatAlert> alerts);

        Task UpdateChatLogViewAsync(List<ChatLogEntry> chatLogEntries, CoreWebView2 webView, Label label);

        Task UpdateAlertsViewAsync(CoreWebView2 webView, List<ChatAlert> alerts, Label label);
    }
}
