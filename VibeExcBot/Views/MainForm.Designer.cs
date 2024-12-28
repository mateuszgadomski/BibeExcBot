namespace VibeExcBot.Views
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            buttonLogin = new Button();
            buttonSettings = new Button();
            buttonClose = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // buttonLogin
            // 
            buttonLogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonLogin.AutoSize = true;
            buttonLogin.BackColor = Color.FromArgb(203, 14, 124);
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Raleway SemiBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLogin.ForeColor = SystemColors.Control;
            buttonLogin.Location = new Point(12, 185);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(376, 89);
            buttonLogin.TabIndex = 0;
            buttonLogin.Text = "ZALOGUJ SIĘ";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonSettings
            // 
            buttonSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonSettings.AutoSize = true;
            buttonSettings.BackColor = Color.FromArgb(203, 14, 124);
            buttonSettings.FlatStyle = FlatStyle.Flat;
            buttonSettings.Font = new Font("Raleway SemiBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSettings.ForeColor = SystemColors.Control;
            buttonSettings.Location = new Point(12, 280);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(376, 89);
            buttonSettings.TabIndex = 1;
            buttonSettings.Text = "USTAWIENIA";
            buttonSettings.UseVisualStyleBackColor = false;
            buttonSettings.Click += buttonSettings_Click;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonClose.AutoSize = true;
            buttonClose.BackColor = Color.FromArgb(203, 14, 124);
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Raleway SemiBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonClose.ForeColor = SystemColors.Control;
            buttonClose.Location = new Point(12, 375);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(376, 89);
            buttonClose.TabIndex = 2;
            buttonClose.Text = "WYJDŹ";
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.BibeExcBot_main;
            pictureBox1.Location = new Point(-1, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(125, 0, 125, 0);
            pictureBox1.Size = new Size(400, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(203, 14, 124);
            label1.Location = new Point(329, 476);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 4;
            label1.Text = "0.1.0-beta";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(400, 500);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(buttonClose);
            Controls.Add(buttonSettings);
            Controls.Add(buttonLogin);
            ForeColor = SystemColors.ButtonFace;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(400, 500);
            MinimumSize = new Size(400, 500);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BibeExcBot - Menu";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLogin;
        private Button buttonSettings;
        private Button buttonClose;
        private PictureBox pictureBox1;
        private Label label1;
    }
}