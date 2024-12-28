namespace VibeExcBot.Views
{
    partial class VibeExcBotForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VibeExcBotForm));
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            startButton = new Button();
            closeButton = new Button();
            webView22 = new Microsoft.Web.WebView2.WinForms.WebView2();
            label1 = new Label();
            webView23 = new Microsoft.Web.WebView2.WinForms.WebView2();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webView22).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webView23).BeginInit();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = SystemColors.Control;
            webView21.Location = new Point(12, 12);
            webView21.Name = "webView21";
            webView21.Size = new Size(960, 424);
            webView21.TabIndex = 1;
            webView21.Visible = false;
            webView21.ZoomFactor = 1D;
            // 
            // startButton
            // 
            startButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            startButton.AutoSize = true;
            startButton.BackColor = Color.FromArgb(203, 14, 124);
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.Font = new Font("Raleway SemiBold", 15.75F, FontStyle.Bold);
            startButton.ForeColor = Color.White;
            startButton.Location = new Point(12, 885);
            startButton.Name = "startButton";
            startButton.Size = new Size(960, 44);
            startButton.TabIndex = 2;
            startButton.Text = "ROZPOCZNIJ DZIAŁANIE";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startButton_Click;
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.FromArgb(203, 14, 124);
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Raleway SemiBold", 15.75F, FontStyle.Bold);
            closeButton.ForeColor = Color.White;
            closeButton.Location = new Point(12, 935);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(960, 44);
            closeButton.TabIndex = 3;
            closeButton.Text = "ZAMKNIJ";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click;
            // 
            // webView22
            // 
            webView22.AllowExternalDrop = true;
            webView22.BackColor = Color.White;
            webView22.CreationProperties = null;
            webView22.DefaultBackgroundColor = SystemColors.Control;
            webView22.Location = new Point(12, 12);
            webView22.Name = "webView22";
            webView22.Size = new Size(960, 424);
            webView22.TabIndex = 6;
            webView22.ZoomFactor = 1D;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Location = new Point(336, 215);
            label1.Name = "label1";
            label1.Size = new Size(282, 15);
            label1.TabIndex = 7;
            label1.Text = "Logi pojawią się po rozpoczęciu działania programu.";
            // 
            // webView23
            // 
            webView23.AllowExternalDrop = true;
            webView23.BackColor = Color.White;
            webView23.CreationProperties = null;
            webView23.DefaultBackgroundColor = SystemColors.Control;
            webView23.Location = new Point(12, 455);
            webView23.Name = "webView23";
            webView23.Size = new Size(960, 424);
            webView23.TabIndex = 8;
            webView23.ZoomFactor = 1D;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Location = new Point(316, 657);
            label2.Name = "label2";
            label2.Size = new Size(341, 15);
            label2.TabIndex = 9;
            label2.Text = "Powiadomienia pojawią się po rozpoczęciu działania programu.";
            // 
            // VibeExcBotForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(984, 991);
            Controls.Add(label2);
            Controls.Add(webView23);
            Controls.Add(label1);
            Controls.Add(webView22);
            Controls.Add(closeButton);
            Controls.Add(startButton);
            Controls.Add(webView21);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1000, 1030);
            MinimumSize = new Size(1000, 1030);
            Name = "VibeExcBotForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VibeExcBotForm";
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ((System.ComponentModel.ISupportInitialize)webView22).EndInit();
            ((System.ComponentModel.ISupportInitialize)webView23).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Button startButton;
        private Button closeButton;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView22;
        private Label label1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView23;
        private Label label2;
    }
}