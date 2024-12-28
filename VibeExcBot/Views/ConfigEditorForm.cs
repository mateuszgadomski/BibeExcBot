using System.Data;
using VibeExcBot.Interfaces;
using VibeExcBot.Models;

namespace VibeExcBot.Views
{
    public partial class ConfigEditorForm : Form
    {
        private readonly IConfigService _configService;
        private readonly BotConfiguration _config;

        public ConfigEditorForm(IConfigService configService)
        {
            _configService = configService;
            InitializeComponent();

            _config = _configService.GetConfig();
            LoadConfigIntoUI();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (UpdateConfigFromUI())
            {
                this.Close();
            }
        }

        private void LoadConfigIntoUI()
        {
            LoadBasicConfigValues();
            LoadActionTextBoxes();
        }

        private void LoadBasicConfigValues()
        {
            textBoxId.Text = _config.CharacterId;
            textBoxCharacterAppearance.Text = _config.CharacterAppearance;
            textBoxSceneDescription.Text = _config.SceneDescription;
            textBoxResponseStyle.Text = _config.ResponseStyle;
            textBoxCharacterGoals.Text = _config.Goals;
            textBoxCharacterSkills.Text = string.Join(", ", _config.Skills);
            textBoxProffesionInfo.Text = string.Join(", ", _config.Professions);
            textBoxNicknames.Text = string.Join(", ", _config.Nicknames);
            textBoxTraits.Text = string.Join(", ", _config.CharacterTraits);

            useAIResponseButton.Checked = _config.UseAIresponse;
            useAlertsBox.Checked = _config.UseChatAlerts;
            useAutoCharacterActionsBox.Checked = _config.UseAutoCharacterActions;
            useDiscordAlerts.Checked = _config.UseDiscordAlerts;
        }

        private void LoadActionTextBoxes()
        {
            var actionTextBoxes = GetActionTextBoxes();

            for (int i = 0; i < actionTextBoxes.Count && i < _config.Actions.Count; i++)
            {
                actionTextBoxes[i].Text = _config.Actions[i];
            }
        }

        private bool UpdateConfigFromUI()
        {
            UpdateBasicConfigValues();
            return UpdateActionsFromTextBoxes();
        }

        private void UpdateBasicConfigValues()
        {
            _config.CharacterId = textBoxId.Text;
            _config.CharacterAppearance = textBoxCharacterAppearance.Text;
            _config.SceneDescription = textBoxSceneDescription.Text;
            _config.ResponseStyle = textBoxResponseStyle.Text;
            _config.Goals = textBoxCharacterGoals.Text;
            _config.Skills = textBoxCharacterSkills.Text.Split(',').Select(n => n.Trim()).ToList();
            _config.Professions = textBoxProffesionInfo.Text.Split(',').Select(n => n.Trim()).ToList();
            _config.Nicknames = textBoxNicknames.Text.Split(',').Select(n => n.Trim()).ToList();
            _config.CharacterTraits = textBoxTraits.Text.Split(',').Select(t => t.Trim()).ToList();

            _config.UseAIresponse = useAIResponseButton.Checked;
            _config.UseChatAlerts = useAlertsBox.Checked;
            _config.UseAutoCharacterActions = useAutoCharacterActionsBox.Checked;
            _config.UseDiscordAlerts = useDiscordAlerts.Checked;
        }

        private bool UpdateActionsFromTextBoxes()
        {
            _config.Actions.Clear();

            var actionTextBoxes = GetActionTextBoxes();

            foreach (var textBox in actionTextBoxes)
            {
                var text = textBox.Text.Trim();
                if (!ValidateActionText(text))
                {
                    return false;
                }
                _config.Actions.Add(text);
            }

            _configService.UpdateConfigFile(_config);
            MessageBox.Show("Konfiguracja została zaktualizowana.");
            return true;
        }

        private List<TextBox> GetActionTextBoxes()
        {
            return Controls.OfType<TextBox>()
                .Where(t => t.Name.Contains("characterActionTextBox"))
                .OrderBy(t => t.TabIndex)
                .ToList();
        }

        private static bool ValidateActionText(string text)
        {
            if (!string.IsNullOrWhiteSpace(text) && !(text.StartsWith("/me", StringComparison.OrdinalIgnoreCase)
                || text.StartsWith("/do", StringComparison.OrdinalIgnoreCase)
                || text.StartsWith("/ame", StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Akcja musi na początku tekstu zawierać /me, /do lub /ame");
                return false;
            }
            return true;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
