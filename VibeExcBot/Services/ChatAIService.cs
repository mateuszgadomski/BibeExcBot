using OpenAI.Chat;
using VibeExcBot.Interfaces;
using VibeExcBot.Models;
using VibeExcBot.Utilities.Encryption;

namespace VibeExcBot.Services
{
    internal class ChatAIService : IChatAIService
    {
        private readonly ChatClient _client;
        private readonly IConfigService _configService;
        private ChatMessage? _systemChatMessage;
        private readonly List<ChatMessage> _recentMessages = new();

        public ChatAIService(IConfigService configService)
        {
            _configService = configService;
            var apiKey = EncryptionHelper.GetEnvironmentWithDecrypt("O_A_ENCRYPTED_KEY");
            _client = new ChatClient(model: "gpt-4-turbo", apiKey: apiKey);
            InitializeSystemAIMessage();
        }

        private void InitializeSystemAIMessage()
        {
            var config = _configService.GetConfig()
                ?? throw new InvalidOperationException("Config nie został poprawnie wczytany.");

            #region AI_SYSTEM_MESSAGE

            var systemMessage =
                "Podstawowe zasady: \n" +
                $"{config.BasicRules}" +
                "Postać:\n" +
                $"- Twoje imię i pseudonimy: {config.Nicknames}\n" +
                $"- Twój zawód, hobby: {config.Professions}\n" +
                $"- Twój charakter: {config.CharacterTraits}\n" +
                $"- Twój styl odpowiedzi: {config.ResponseStyle}\n" +
                $"- Wygląd postaci, w którą się wcielasz: {config.CharacterAppearance}\n" +
                $"- Twoje najlepsze umiejętności to: {config.Skills}\n" +
                $"- Dodatkowe informacje dla ciebie to: {config.AdditionalInfo}\n" +
                $"- Aktualne cele postaci, w którą się wcielasz: {config.Goals}\n\n" +

                $"Aktualna sceneria, w której jest twoja postać:{config.SceneDescription}";

            #endregion AI_SYSTEM_MESSAGE

            _systemChatMessage = ChatMessage.CreateSystemMessage(systemMessage);
            _recentMessages.Insert(0, _systemChatMessage);
        }

        public async Task<string> GetAIResponseAsync(List<ChatLogEntry> chatLogEntries)
        {
            foreach (var entry in chatLogEntries)
            {
                var userChatMessage = ChatMessage.CreateUserMessage(entry.Message);
                _recentMessages.Add(userChatMessage);
            }

            if (_recentMessages.Count > 5)
            {
                _recentMessages.RemoveAt(0);
            }

            ChatCompletion completion = await _client.CompleteChatAsync(_recentMessages);
            var assistantMessage = ChatMessage.CreateAssistantMessage(completion.Content[0].Text);
            _recentMessages.Add(assistantMessage);

            return completion.Content[0].Text;
        }

        public void ClearRecentMessages()
        {
            _recentMessages.Clear();
            _recentMessages.Insert(0, _systemChatMessage ?? throw new InvalidOperationException("Nie ma systemowej wiadomości do OpenAI."));
        }

        public List<ChatMessage> GetChatMessages()
            => _recentMessages;
    }
}
