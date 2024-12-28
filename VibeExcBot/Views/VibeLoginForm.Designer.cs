namespace VibeExcBot.Views
{
    partial class VibeLoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VibeLoginForm));
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(12, 12);
            webView21.Name = "webView21";
            webView21.Size = new Size(476, 571);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.AutoSize = true;
            button2.BackColor = Color.FromArgb(203, 14, 124);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Raleway SemiBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.Control;
            button2.Location = new Point(12, 603);
            button2.Name = "button2";
            button2.Size = new Size(476, 46);
            button2.TabIndex = 2;
            button2.Text = "WRÓĆ DO MENU";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(45, 12);
            label1.Name = "label1";
            label1.Size = new Size(417, 15);
            label1.TabIndex = 3;
            label1.Text = "Logowanie jest wymagane w celu uzyskania dostępu do logów Twojej postaci.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(150, 31);
            label2.Name = "label2";
            label2.Size = new Size(201, 15);
            label2.TabIndex = 4;
            label2.Text = "Program nie zapisuje twoich danych.";
            // 
            // VibeLoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(500, 661);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(webView21);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "VibeLoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VibeLoginForm";
            Load += VibeLoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Button button2;
        private Label label1;
        private Label label2;
    }
}