namespace VibeExcBot.Models
{
    public class DiscordUserResponse
    {
        public required ulong Id { get; set; }
        public required string Username { get; set; }
        public required string Discriminator { get; set; }
        public required string Avatar { get; set; }
    }
}
