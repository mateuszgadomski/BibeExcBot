using OpenAI.Chat;
using VibeExcBot.Models;

namespace VibeExcBot.Interfaces
{
    public interface IChatAIService
    {
        Task<string> GetAIResponseAsync(List<ChatLogEntry> chatLogEntries);

        public List<ChatMessage> GetChatMessages();

        public void ClearRecentMessages();
    }
}
