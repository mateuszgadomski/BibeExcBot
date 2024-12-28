namespace VibeExcBot.Models
{
    public class ChatLogEntry
    {
        public required string Id { get; set; }
        public required string Message { get; set; }
        public int ChatLogType { get; set; }
        public required string ChatLogTypeName { get; set; }
        public DateTime DateCreated { get; set; }
        public int? SenderCharacterId { get; set; }
        public string? SenderName { get; set; }
    }
}
