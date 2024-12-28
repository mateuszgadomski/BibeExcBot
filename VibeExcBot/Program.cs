using Microsoft.Extensions.DependencyInjection;

using VibeExcBot.Views;

namespace VibeExcBot
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var serviceCollection = new ServiceCollection();
            ServicesRegistration.ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            Application.Run(serviceProvider.GetRequiredService<MainForm>());
        }
    }
}
