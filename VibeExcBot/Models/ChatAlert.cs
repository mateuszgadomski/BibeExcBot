namespace VibeExcBot.Models
{
    public class ChatAlert
    {
        public required string Action { get; set; }
        public required string Message { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
    }
}
