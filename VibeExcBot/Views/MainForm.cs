using VibeExcBot.Interfaces;
using VibeExcBot.Utilities.Encryption;

namespace VibeExcBot.Views
{
    public partial class MainForm : Form
    {
        private readonly IAltVService _altService;
        private readonly IChatAIService _chatAIService;
        private readonly IChatlogService _chatlogService;
        private readonly IDiscordBotService _discordBotService;
        private readonly IConfigService _configService;
        private readonly IDiscordAuthService _discordAuthService;

        public MainForm(IAltVService altService, IChatAIService chatAIService, IChatlogService chatlog,
                        IDiscordBotService discordBotService, IConfigService configService,
                        IDiscordAuthService discordAuthService)
        {
            _altService = altService;
            _chatAIService = chatAIService;
            _chatlogService = chatlog;
            _discordBotService = discordBotService;
            _configService = configService;
            _discordAuthService = discordAuthService;

            InitializeComponent();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            var config = _configService.GetConfig();
            if (string.IsNullOrEmpty(config.CharacterId))
            {
                MessageBox.Show("Uzupełnij ID swojej postaci w ustawieniach.");
                return;
            }

            try
            {
                await _discordAuthService.AuthenticateAsync(_discordBotService);
                var vibeLoginForm = new VibeLoginForm(_altService, this, _chatAIService, _chatlogService, _discordAuthService, _discordBotService, config);
                vibeLoginForm.Show();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}");
            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            var configEditorForm = new ConfigEditorForm(_configService);
            configEditorForm.ShowDialog();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
