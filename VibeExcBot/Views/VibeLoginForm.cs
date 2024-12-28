using Microsoft.Web.WebView2.Core;
using VibeExcBot.Interfaces;
using VibeExcBot.Models;

namespace VibeExcBot.Views
{
    public partial class VibeLoginForm : Form
    {
        private readonly Form _previousForm;
        private readonly IAltVService _altService;
        private readonly IChatAIService _chatAIService;
        private readonly IChatlogService _chatLogService;
        private readonly IDiscordBotService _discordBotService;
        private readonly IDiscordAuthService _discordAuthService;
        private readonly BotConfiguration _config;
        private readonly Uri _uri;

        private bool _actionCompleted;

        public VibeLoginForm(IAltVService altService, Form previousForm, IChatAIService chatAIService, IChatlogService chatlogService, IDiscordAuthService discordAuthService, IDiscordBotService discordBotService, BotConfiguration config)
        {
            _previousForm = previousForm;
            _altService = altService;
            _chatAIService = chatAIService;
            _chatLogService = chatlogService;
            _discordBotService = discordBotService;
            _discordAuthService = discordAuthService;

            _config = config;
            _uri = new Uri($"https://panel.v-rp.pl/#/login?redirect=%2Fchat-logs%2Fcharacter%2F{_config.CharacterId}");

            InitializeComponent();

            this.Load += VibeLoginForm_Load;
        }

        public async void VibeLoginForm_Load(object? sender, EventArgs e)
        {
            webView21.CoreWebView2InitializationCompleted += VibeLoginForm_CoreWebView2InitializationCompleted;
            await webView21.EnsureCoreWebView2Async(null);
            webView21.Source = _uri;
            _previousForm?.Hide();
        }

        private void VibeLoginForm_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                var settings = webView21.CoreWebView2.Settings;
                webView21.CoreWebView2.SourceChanged += CoreWebView2_SourceChanged;
            }
            else
            {
                MessageBox.Show("");
            }
        }

        private void CoreWebView2_SourceChanged(object? sender, object e)
        {
            var currentUrl = webView21.CoreWebView2.Source;
            if ((currentUrl.Contains($"/chat-logs/character/{_config.CharacterId}") && !_actionCompleted))
            {
                webView21.Visible = false;
                var vibeLoginForm = new VibeExcBotForm(_altService, _chatAIService, _chatLogService, _discordBotService, _discordAuthService, _config, currentUrl);
                vibeLoginForm.Show();
                this.BeginInvoke((Action)(() => this.Close()));
                _actionCompleted = true;
            }
        }

        private void button2_Click(object? sender, EventArgs e)
        {
            _previousForm.Show();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}
