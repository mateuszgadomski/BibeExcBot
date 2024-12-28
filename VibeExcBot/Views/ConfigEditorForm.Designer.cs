namespace VibeExcBot.Views
{
    partial class ConfigEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigEditorForm));
            textBoxId = new TextBox();
            textBoxCharacterAppearance = new TextBox();
            textBoxNicknames = new TextBox();
            textBoxTraits = new TextBox();
            buttonSave = new Button();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            useAIResponseButton = new CheckBox();
            textBoxResponseStyle = new TextBox();
            label5 = new Label();
            textBoxProffesionInfo = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            characterActionTextBox1 = new TextBox();
            characterActionTextBox2 = new TextBox();
            characterActionTextBox3 = new TextBox();
            characterActionTextBox4 = new TextBox();
            characterActionTextBox5 = new TextBox();
            characterActionTextBox6 = new TextBox();
            characterActionTextBox7 = new TextBox();
            characterActionTextBox8 = new TextBox();
            characterActionTextBox9 = new TextBox();
            characterActionTextBox10 = new TextBox();
            characterActionTextBox11 = new TextBox();
            useAutoCharacterActionsBox = new CheckBox();
            useAlertsBox = new CheckBox();
            textBoxSceneDescription = new TextBox();
            label2 = new Label();
            buttonClose = new Button();
            textBoxCharacterSkills = new TextBox();
            label9 = new Label();
            textBoxCharacterGoals = new TextBox();
            label10 = new Label();
            textBoxAdditionalInfo = new TextBox();
            label11 = new Label();
            label12 = new Label();
            useDiscordAlerts = new CheckBox();
            SuspendLayout();
            // 
            // textBoxId
            // 
            textBoxId.BackColor = SystemColors.ControlLight;
            textBoxId.BorderStyle = BorderStyle.FixedSingle;
            textBoxId.Location = new Point(12, 208);
            textBoxId.MaxLength = 6;
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new Size(61, 23);
            textBoxId.TabIndex = 0;
            // 
            // textBoxCharacterAppearance
            // 
            textBoxCharacterAppearance.BackColor = SystemColors.ControlLight;
            textBoxCharacterAppearance.BorderStyle = BorderStyle.FixedSingle;
            textBoxCharacterAppearance.Location = new Point(12, 136);
            textBoxCharacterAppearance.MaxLength = 1000;
            textBoxCharacterAppearance.Multiline = true;
            textBoxCharacterAppearance.Name = "textBoxCharacterAppearance";
            textBoxCharacterAppearance.Size = new Size(960, 49);
            textBoxCharacterAppearance.TabIndex = 1;
            // 
            // textBoxNicknames
            // 
            textBoxNicknames.BackColor = SystemColors.ControlLight;
            textBoxNicknames.BorderStyle = BorderStyle.FixedSingle;
            textBoxNicknames.Location = new Point(79, 208);
            textBoxNicknames.MaxLength = 50;
            textBoxNicknames.Name = "textBoxNicknames";
            textBoxNicknames.Size = new Size(370, 23);
            textBoxNicknames.TabIndex = 2;
            // 
            // textBoxTraits
            // 
            textBoxTraits.BackColor = SystemColors.ControlLight;
            textBoxTraits.BorderStyle = BorderStyle.FixedSingle;
            textBoxTraits.Location = new Point(455, 208);
            textBoxTraits.MaxLength = 80;
            textBoxTraits.Name = "textBoxTraits";
            textBoxTraits.Size = new Size(517, 23);
            textBoxTraits.TabIndex = 3;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.FromArgb(203, 14, 124);
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Raleway SemiBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSave.ForeColor = SystemColors.Control;
            buttonSave.Location = new Point(862, 940);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(126, 48);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "ZAPISZ";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 188);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 5;
            label1.Text = "Id postaci:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(79, 188);
            label3.Name = "label3";
            label3.Size = new Size(119, 15);
            label3.TabIndex = 7;
            label3.Text = "Pseudonimy, imiona:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(455, 188);
            label4.Name = "label4";
            label4.Size = new Size(102, 15);
            label4.TabIndex = 8;
            label4.Text = "Cechy charakteru:";
            // 
            // useAIResponseButton
            // 
            useAIResponseButton.AutoSize = true;
            useAIResponseButton.Location = new Point(12, 421);
            useAIResponseButton.Name = "useAIResponseButton";
            useAIResponseButton.Size = new Size(827, 19);
            useAIResponseButton.TabIndex = 10;
            useAIResponseButton.Text = "Używaj automatycznych odpowiedzi na czacie AI (wykrywa automatycznie aktywność na czacie i odpowiada według wytycznych lub odgrywa czynność)";
            useAIResponseButton.UseVisualStyleBackColor = true;
            // 
            // textBoxResponseStyle
            // 
            textBoxResponseStyle.BackColor = SystemColors.ControlLight;
            textBoxResponseStyle.BorderStyle = BorderStyle.FixedSingle;
            textBoxResponseStyle.Location = new Point(12, 252);
            textBoxResponseStyle.MaxLength = 50;
            textBoxResponseStyle.Name = "textBoxResponseStyle";
            textBoxResponseStyle.Size = new Size(140, 23);
            textBoxResponseStyle.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 234);
            label5.Name = "label5";
            label5.Size = new Size(93, 15);
            label5.TabIndex = 12;
            label5.Text = "Styl odpowiedzi:";
            // 
            // textBoxProffesionInfo
            // 
            textBoxProffesionInfo.BackColor = SystemColors.ControlLight;
            textBoxProffesionInfo.BorderStyle = BorderStyle.FixedSingle;
            textBoxProffesionInfo.Location = new Point(158, 252);
            textBoxProffesionInfo.MaxLength = 150;
            textBoxProffesionInfo.Name = "textBoxProffesionInfo";
            textBoxProffesionInfo.Size = new Size(291, 23);
            textBoxProffesionInfo.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(158, 234);
            label6.Name = "label6";
            label6.Size = new Size(114, 15);
            label6.TabIndex = 14;
            label6.Text = "Twój zawód i hobby:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 118);
            label7.Name = "label7";
            label7.Size = new Size(120, 15);
            label7.TabIndex = 15;
            label7.Text = "Opis wyglądu postaci";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 457);
            label8.Name = "label8";
            label8.Size = new Size(266, 15);
            label8.TabIndex = 16;
            label8.Text = "Ustawienia dla akcji wykonywanych przez postać:";
            // 
            // characterActionTextBox1
            // 
            characterActionTextBox1.BackColor = SystemColors.ControlLight;
            characterActionTextBox1.BorderStyle = BorderStyle.FixedSingle;
            characterActionTextBox1.Location = new Point(12, 475);
            characterActionTextBox1.MaxLength = 200;
            characterActionTextBox1.Name = "characterActionTextBox1";
            characterActionTextBox1.Size = new Size(960, 23);
            characterActionTextBox1.TabIndex = 17;
            // 
            // characterActionTextBox2
            // 
            characterActionTextBox2.BackColor = SystemColors.ControlLight;
            characterActionTextBox2.BorderStyle = BorderStyle.FixedSingle;
            characterActionTextBox2.Location = new Point(12, 504);
            characterActionTextBox2.MaxLength = 200;
            characterActionTextBox2.Name = "characterActionTextBox2";
            characterActionTextBox2.Size = new Size(960, 23);
            characterActionTextBox2.TabIndex = 18;
            // 
            // characterActionTextBox3
            // 
            characterActionTextBox3.BackColor = SystemColors.ControlLight;
            characterActionTextBox3.BorderStyle = BorderStyle.FixedSingle;
            characterActionTextBox3.Location = new Point(12, 533);
            characterActionTextBox3.MaxLength = 200;
            characterActionTextBox3.Name = "characterActionTextBox3";
            characterActionTextBox3.Size = new Size(960, 23);
            characterActionTextBox3.TabIndex = 19;
            // 
            // characterActionTextBox4
            // 
            characterActionTextBox4.BackColor = SystemColors.ControlLight;
            characterActionTextBox4.BorderStyle = BorderStyle.FixedSingle;
            characterActionTextBox4.Location = new Point(12, 562);
            characterActionTextBox4.MaxLength = 200;
            characterActionTextBox4.Name = "characterActionTextBox4";
            characterActionTextBox4.Size = new Size(960, 23);
            characterActionTextBox4.TabIndex = 20;
            // 
            // characterActionTextBox5
            // 
            characterActionTextBox5.BackColor = SystemColors.ControlLight;
            characterActionTextBox5.BorderStyle = BorderStyle.FixedSingle;
            characterActionTextBox5.Location = new Point(12, 591);
            characterActionTextBox5.MaxLength = 200;
            characterActionTextBox5.Name = "characterActionTextBox5";
            characterActionTextBox5.Size = new Size(960, 23);
            characterActionTextBox5.TabIndex = 21;
            // 
            // characterActionTextBox6
            // 
            characterActionTextBox6.BackColor = SystemColors.ControlLight;
            characterActionTextBox6.BorderStyle = BorderStyle.FixedSingle;
            characterActionTextBox6.Location = new Point(12, 620);
            characterActionTextBox6.MaxLength = 200;
            characterActionTextBox6.Name = "characterActionTextBox6";
            characterActionTextBox6.Size = new Size(960, 23);
            characterActionTextBox6.TabIndex = 22;
            // 
            // characterActionTextBox7
            // 
            characterActionTextBox7.BackColor = SystemColors.ControlLight;
            characterActionTextBox7.BorderStyle = BorderStyle.FixedSingle;
            characterActionTextBox7.Location = new Point(12, 649);
            characterActionTextBox7.MaxLength = 200;
            characterActionTextBox7.Name = "characterActionTextBox7";
            characterActionTextBox7.Size = new Size(960, 23);
            characterActionTextBox7.TabIndex = 23;
            // 
            // characterActionTextBox8
            // 
            characterActionTextBox8.BackColor = SystemColors.ControlLight;
            characterActionTextBox8.BorderStyle = BorderStyle.FixedSingle;
            characterActionTextBox8.Location = new Point(12, 678);
            characterActionTextBox8.MaxLength = 200;
            characterActionTextBox8.Name = "characterActionTextBox8";
            characterActionTextBox8.Size = new Size(960, 23);
            characterActionTextBox8.TabIndex = 24;
            // 
            // characterActionTextBox9
            // 
            characterActionTextBox9.BackColor = SystemColors.ControlLight;
            characterActionTextBox9.BorderStyle = BorderStyle.FixedSingle;
            characterActionTextBox9.Location = new Point(12, 707);
            characterActionTextBox9.MaxLength = 200;
            characterActionTextBox9.Name = "characterActionTextBox9";
            characterActionTextBox9.Size = new Size(960, 23);
            characterActionTextBox9.TabIndex = 25;
            // 
            // characterActionTextBox10
            // 
            characterActionTextBox10.BackColor = SystemColors.ControlLight;
            characterActionTextBox10.BorderStyle = BorderStyle.FixedSingle;
            characterActionTextBox10.Location = new Point(12, 736);
            characterActionTextBox10.MaxLength = 200;
            characterActionTextBox10.Name = "characterActionTextBox10";
            characterActionTextBox10.Size = new Size(960, 23);
            characterActionTextBox10.TabIndex = 26;
            // 
            // characterActionTextBox11
            // 
            characterActionTextBox11.BackColor = SystemColors.ControlLight;
            characterActionTextBox11.BorderStyle = BorderStyle.FixedSingle;
            characterActionTextBox11.Location = new Point(12, 765);
            characterActionTextBox11.MaxLength = 200;
            characterActionTextBox11.Name = "characterActionTextBox11";
            characterActionTextBox11.Size = new Size(960, 23);
            characterActionTextBox11.TabIndex = 27;
            // 
            // useAutoCharacterActionsBox
            // 
            useAutoCharacterActionsBox.AutoSize = true;
            useAutoCharacterActionsBox.Location = new Point(12, 794);
            useAutoCharacterActionsBox.Name = "useAutoCharacterActionsBox";
            useAutoCharacterActionsBox.Size = new Size(415, 19);
            useAutoCharacterActionsBox.TabIndex = 29;
            useAutoCharacterActionsBox.Text = "Używaj automatycznych akcji /me, /do i /ame podczas używania AntyAFK";
            useAutoCharacterActionsBox.UseVisualStyleBackColor = true;
            // 
            // useAlertsBox
            // 
            useAlertsBox.AutoSize = true;
            useAlertsBox.Location = new Point(12, 819);
            useAlertsBox.Name = "useAlertsBox";
            useAlertsBox.Size = new Size(712, 19);
            useAlertsBox.TabIndex = 30;
            useAlertsBox.Text = "Używaj powiadomień wizualnych i dźwiękowych dla akcji w kierunku twojej postaci ze strony innego gracza, gdy używasz AntyAFK";
            useAlertsBox.UseVisualStyleBackColor = true;
            // 
            // textBoxSceneDescription
            // 
            textBoxSceneDescription.BackColor = SystemColors.ControlLight;
            textBoxSceneDescription.BorderStyle = BorderStyle.FixedSingle;
            textBoxSceneDescription.Location = new Point(12, 66);
            textBoxSceneDescription.MaxLength = 1000;
            textBoxSceneDescription.Multiline = true;
            textBoxSceneDescription.Name = "textBoxSceneDescription";
            textBoxSceneDescription.Size = new Size(960, 49);
            textBoxSceneDescription.TabIndex = 31;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 48);
            label2.Name = "label2";
            label2.Size = new Size(253, 15);
            label2.TabIndex = 32;
            label2.Text = "Aktualna sceneria, w której znajduje się postać:";
            // 
            // buttonClose
            // 
            buttonClose.BackColor = Color.FromArgb(203, 14, 124);
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Raleway SemiBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonClose.ForeColor = SystemColors.Control;
            buttonClose.Location = new Point(730, 940);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(126, 48);
            buttonClose.TabIndex = 33;
            buttonClose.Text = "WYJDŹ";
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // textBoxCharacterSkills
            // 
            textBoxCharacterSkills.BackColor = SystemColors.ControlLight;
            textBoxCharacterSkills.BorderStyle = BorderStyle.FixedSingle;
            textBoxCharacterSkills.Location = new Point(455, 252);
            textBoxCharacterSkills.MaxLength = 150;
            textBoxCharacterSkills.Name = "textBoxCharacterSkills";
            textBoxCharacterSkills.Size = new Size(517, 23);
            textBoxCharacterSkills.TabIndex = 34;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(455, 234);
            label9.Name = "label9";
            label9.Size = new Size(125, 15);
            label9.TabIndex = 35;
            label9.Text = "Twoje umiejętności to:";
            // 
            // textBoxCharacterGoals
            // 
            textBoxCharacterGoals.BackColor = SystemColors.ControlLight;
            textBoxCharacterGoals.BorderStyle = BorderStyle.FixedSingle;
            textBoxCharacterGoals.Location = new Point(12, 296);
            textBoxCharacterGoals.MaxLength = 500;
            textBoxCharacterGoals.Multiline = true;
            textBoxCharacterGoals.Name = "textBoxCharacterGoals";
            textBoxCharacterGoals.Size = new Size(960, 49);
            textBoxCharacterGoals.TabIndex = 36;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 278);
            label10.Name = "label10";
            label10.Size = new Size(122, 15);
            label10.TabIndex = 37;
            label10.Text = "Aktualne cele postaci:";
            // 
            // textBoxAdditionalInfo
            // 
            textBoxAdditionalInfo.BackColor = SystemColors.ControlLight;
            textBoxAdditionalInfo.BorderStyle = BorderStyle.FixedSingle;
            textBoxAdditionalInfo.Location = new Point(12, 366);
            textBoxAdditionalInfo.MaxLength = 500;
            textBoxAdditionalInfo.Multiline = true;
            textBoxAdditionalInfo.Name = "textBoxAdditionalInfo";
            textBoxAdditionalInfo.Size = new Size(960, 49);
            textBoxAdditionalInfo.TabIndex = 38;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 348);
            label11.Name = "label11";
            label11.Size = new Size(126, 15);
            label11.TabIndex = 39;
            label11.Text = "Dodatkowe infomacje:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(79, 19);
            label12.Name = "label12";
            label12.Size = new Size(834, 15);
            label12.TabIndex = 40;
            label12.Text = "Założenia odnośnie uniwersum oraz przestrzegania zasad wraz z ogrywaniem przez niego na /me są narzucone odgórnie i nie należy ich dodatkowo podawać.";
            // 
            // useDiscordAlerts
            // 
            useDiscordAlerts.AutoSize = true;
            useDiscordAlerts.Location = new Point(12, 844);
            useDiscordAlerts.Name = "useDiscordAlerts";
            useDiscordAlerts.Size = new Size(226, 19);
            useDiscordAlerts.TabIndex = 41;
            useDiscordAlerts.Text = "Używaj powiadomień poprzez Discord";
            useDiscordAlerts.UseVisualStyleBackColor = true;
            // 
            // ConfigEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 1000);
            Controls.Add(useDiscordAlerts);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(textBoxAdditionalInfo);
            Controls.Add(label10);
            Controls.Add(textBoxCharacterGoals);
            Controls.Add(label9);
            Controls.Add(textBoxCharacterSkills);
            Controls.Add(buttonClose);
            Controls.Add(label2);
            Controls.Add(textBoxSceneDescription);
            Controls.Add(useAlertsBox);
            Controls.Add(useAutoCharacterActionsBox);
            Controls.Add(characterActionTextBox11);
            Controls.Add(characterActionTextBox10);
            Controls.Add(characterActionTextBox9);
            Controls.Add(characterActionTextBox8);
            Controls.Add(characterActionTextBox7);
            Controls.Add(characterActionTextBox6);
            Controls.Add(characterActionTextBox5);
            Controls.Add(characterActionTextBox4);
            Controls.Add(characterActionTextBox3);
            Controls.Add(characterActionTextBox2);
            Controls.Add(characterActionTextBox1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(textBoxProffesionInfo);
            Controls.Add(label5);
            Controls.Add(textBoxResponseStyle);
            Controls.Add(useAIResponseButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(buttonSave);
            Controls.Add(textBoxTraits);
            Controls.Add(textBoxNicknames);
            Controls.Add(textBoxCharacterAppearance);
            Controls.Add(textBoxId);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1000, 1000);
            MinimumSize = new Size(1000, 900);
            Name = "ConfigEditorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BibeExcBot - Konfiguracja i ustawienia";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxId;
        private TextBox textBoxCharacterAppearance;
        private TextBox textBoxNicknames;
        private TextBox textBoxTraits;
        private Button buttonSave;
        private Label label1;
        private Label label3;
        private Label label4;
        private CheckBox useAIResponseButton;
        private TextBox textBoxResponseStyle;
        private Label label5;
        private TextBox textBoxProffesionInfo;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox characterActionTextBox1;
        private TextBox characterActionTextBox2;
        private TextBox characterActionTextBox3;
        private TextBox characterActionTextBox4;
        private TextBox characterActionTextBox5;
        private TextBox characterActionTextBox6;
        private TextBox characterActionTextBox7;
        private TextBox characterActionTextBox8;
        private TextBox characterActionTextBox9;
        private TextBox characterActionTextBox10;
        private TextBox characterActionTextBox11;
        private CheckBox useAutoCharacterActionsBox;
        private CheckBox useAlertsBox;
        private TextBox textBoxSceneDescription;
        private Label label2;
        private Button buttonClose;
        private TextBox textBoxCharacterSkills;
        private Label label9;
        private TextBox textBoxCharacterGoals;
        private Label label10;
        private TextBox textBoxAdditionalInfo;
        private Label label11;
        private Label label12;
        private CheckBox useDiscordAlerts;
    }
}