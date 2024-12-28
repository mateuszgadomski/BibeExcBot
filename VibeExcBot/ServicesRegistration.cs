using Microsoft.Extensions.DependencyInjection;
using VibeExcBot.Interfaces;
using VibeExcBot.Services;
using VibeExcBot.Utilities.DiscordBot.Commands;
using VibeExcBot.Views;

namespace VibeExcBot
{
    public static class ServicesRegistration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MainForm>();
            services.AddScoped<IAltVService, AltVService>();
            services.AddScoped<IChatAIService, ChatAIService>();
            services.AddScoped<IChatlogService, ChatlogService>();
            services.AddScoped<IConfigService, ConfigService>();
            services.AddScoped<IDiscordBotService, DiscordBotService>();
            services.AddScoped<IDiscordAuthService, DiscordAuthService>();
        }
    }
}
