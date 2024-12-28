namespace VibeExcBot.Interfaces
{
    public interface IAltVService
    {
        void RestoreAltVWindow(string? message = default);

        void NotifyUser();
    }
}
