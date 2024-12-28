namespace VibeExcBot.Models
{
    public class BotConfiguration
    {
        public required string BasicRules { get; set; }
        public required string CharacterId { get; set; }
        public required string CharacterAppearance { get; set; }
        public required string SceneDescription { get; set; }
        public string? ResponseStyle { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? Goals { get; set; }
        public required List<string> Nicknames { get; set; }
        public required List<string> CharacterTraits { get; set; }
        public required List<string> Skills { get; set; }
        public required List<string> Actions { get; set; }
        public required List<string> Professions { get; set; }
        public bool UseAIresponse { get; set; }
        public bool UseChatAlerts { get; set; }
        public bool UseAutoCharacterActions { get; set; }
        public bool UseDiscordAlerts { get; set; }
    }
}
