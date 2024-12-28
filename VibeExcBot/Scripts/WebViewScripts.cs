using System.Text;
using VibeExcBot.Models;

namespace VibeExcBot.Scripts
{
    public static class WebViewScripts
    {
        public static string GetChatLogScript()
        {
            return @"
            (function() {
                var open = window.XMLHttpRequest.prototype.open;
                window.XMLHttpRequest.prototype.open = function(method, url) {
                    if (url.includes('https://panel.v-rp.pl/api/user/chatLog/character')) {
                        this.addEventListener('load', function() {
                            var responseData = JSON.parse(this.response);
                            var entries = responseData.data;
                            var chatLogEntries = entries.map(function(entry) {
                                return {
                                    Id: entry.id,
                                    Message: entry.message,
                                    ChatLogType: entry.chatLogType,
                                    ChatLogTypeName: entry.chatLogTypeName,
                                    DateCreated: new Date(entry.dateCreated).toISOString(),
                                    SenderCharacterId: entry.senderCharacterId,
                                    SenderName: entry.senderName,
                                    AdditionalData: entry.additionalData
                                };
                            });
                            window.chrome.webview.postMessage(JSON.stringify(chatLogEntries));
                        });
                    }
                    open.apply(this, arguments);
                };
            })();
            ";
        }

        public static string GenerateChatLogHtml(List<ChatLogEntry> chatLogEntries)
        {
            var headers = new List<string> { "Treść", "Type", "Nadawca", "Data" };
            var rows = chatLogEntries.Select(entry
                => new List<string> { entry.Message, entry.ChatLogTypeName, entry.SenderName ?? "Brak", entry.DateCreated.ToString("yyyy-MM-dd HH:mm:ss") }).ToList();
            return GenerateTableHtml(headers, rows);
        }

        public static string GenerateAlertsTableHtml(List<ChatAlert> alerts)
        {
            var headers = new List<string> { "Treść", "Akcja", "Data" };
            var rows = alerts.OrderByDescending(a => a.CreatedAt).Select(alert
                => new List<string> { alert.Message, alert.Action, alert.CreatedAt.ToString("yyyy-MM-dd HH:mm") }).ToList();
            return GenerateTableHtml(headers, rows);
        }

        private static string GenerateTableHtml(List<string> headers, List<List<string>> rows)
        {
            var htmlBuilder = new StringBuilder();
            htmlBuilder.Append("<div style=\"overflow-y: auto; max-height: 400px;\">");
            htmlBuilder.Append("<table style='width:100%; border-collapse: collapse;'>");

            htmlBuilder.Append("<tr>");
            foreach (var header in headers)
            {
                htmlBuilder.Append($"<th style='border-bottom: 2px solid #dddddd; text-align: center; padding: 8px;'>{header}</th>");
            }
            htmlBuilder.Append("</tr>");

            foreach (var row in rows)
            {
                htmlBuilder.Append("<tr>");
                foreach (var cell in row)
                {
                    htmlBuilder.Append($"<td style='border: 1px solid #dddddd; text-align: left; padding: 8px;'>{cell}</td>");
                }
                htmlBuilder.Append("</tr>");
            }

            htmlBuilder.Append("</table>");
            htmlBuilder.Append("</div>");

            return htmlBuilder.ToString();
        }
    }
}
