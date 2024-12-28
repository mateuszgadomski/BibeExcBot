using VibeExcBot.Models;

namespace VibeExcBot.Interfaces
{
    public interface IConfigService
    {
        BotConfiguration LoadConfigFile();

        void UpdateConfigFile(BotConfiguration updatedConfig);

        BotConfiguration GetConfig();
    }
}
