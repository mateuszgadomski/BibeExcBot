using Microsoft.Web.WebView2.Core;
using VibeExcBot.Interfaces;
using VibeExcBot.Models;
using VibeExcBot.Scripts;
using VibeExcBot.Utilities;

namespace VibeExcBot.Views
{
    public partial class VibeExcBotForm : Form
    {
        private readonly IAltVService _altService;
        private readonly IChatAIService _chatService;
        private readonly IChatlogService _chatLogService;
        private readonly IDiscordBotService _discordBotService;
        private readonly IDiscordAuthService _discordAuthService;
        private readonly BotConfiguration _config;
        private readonly string _url;

        private readonly List<ChatAlert> _alerts = new();

        public VibeExcBotForm(IAltVService altService, IChatAIService chatService, IChatlogService chatLogService, IDiscordBotService discordBotService, IDiscordAuthService discordAuthService, BotConfiguration config, string url)
        {
            _altService = altService;
            _chatService = chatService;
            _chatLogService = chatLogService;
            _discordAuthService = discordAuthService;
            _config = config;
            _url = url;

            InitializeComponent();
            this.Load += VibeExcBotForm_Load;
        }

        private void ToggleRefreshTimer()
        {
            if (TimerUtility.IsTimerState(true))
            {
                TimerUtility.StopTimer();
                startButton.Text = "ROZPOCZNIJ DZIAŁANIE";
                return;
            }

            TimerUtility.StartTimer(RefreshWebView, new object(), TimeSpan.Zero, TimeSpan.FromSeconds(60));
            startButton.Text = "ZATRZYMAJ DZIAŁANIE";
        }

        private async void VibeExcBotForm_Load(object? sender, EventArgs e)
        {
            await SetupWebViewAsync();
        }

        private async void CoreWebView2_InitializationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            await webView21.CoreWebView2.ExecuteScriptAsync(WebViewScripts.GetChatLogScript());
        }

        private async void CoreWebView2_WebMessageReceived(object? sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            if (TimerUtility.IsTimerState(false))
            {
                return;
            }

            try
            {
                var chatLogEntries = await _chatLogService.GetChatLogEntriesAsync(e);
                if (chatLogEntries != null)
                {
                    await _chatLogService.ProcessChatLogEntriesAsync(chatLogEntries, _altService, _chatService, _config, _alerts);
                    await _chatLogService.UpdateChatLogViewAsync(chatLogEntries, webView22.CoreWebView2, label1);
                    await _chatLogService.UpdateAlertsViewAsync(webView23.CoreWebView2, _alerts, label2);
                }
                else
                {
                    MessageBox.Show("Nie znaleziono żadnych wpisów w logach czatu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}");
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            var currentUrl = webView21.CoreWebView2.Source;
            if (!currentUrl.Contains($"/chat-logs/character/{_config.CharacterId}"))
            {
                MessageBox.Show("Postać, której id zostało podane w ustawieniach nie należy do twojego konta.");
                this.Close();
            }

            ToggleRefreshTimer();
        }

        private void closeButton_Click(object sender, EventArgs e)
            => this.Close();

        protected override void OnFormClosing(FormClosingEventArgs e)
            => base.OnFormClosing(e);

        private async Task SetupWebViewAsync()
        {
            await webView21.EnsureCoreWebView2Async();
            await webView22.EnsureCoreWebView2Async();
            await webView23.EnsureCoreWebView2Async();

            if (Uri.TryCreate(_url, UriKind.Absolute, out Uri? validatedUri))
            {
                webView21.Source = validatedUri;
            }
            else
            {
                MessageBox.Show("Niepoprawny adres URL.");
                return;
            }

            webView21.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;
            webView21.CoreWebView2.NavigationCompleted += CoreWebView2_InitializationCompleted;
        }

        private void RefreshWebView(object? state)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => RefreshWebView(state)));
                return;
            }

            if (webView21.CoreWebView2 != null)
            {
                webView21.CoreWebView2.Reload();
            }
        }
    }
}
