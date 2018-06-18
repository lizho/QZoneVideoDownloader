namespace QZoneVideoDownloader
{
    partial class MiniBrowser
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
            this.wbLogin = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbLogin
            // 
            this.wbLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbLogin.Location = new System.Drawing.Point(0, 0);
            this.wbLogin.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbLogin.Name = "wbLogin";
            this.wbLogin.Size = new System.Drawing.Size(398, 273);
            this.wbLogin.TabIndex = 0;
            this.wbLogin.Url = new System.Uri("https://i.qq.com/", System.UriKind.Absolute);
            this.wbLogin.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.WbLogin_Navigated);
            // 
            // MiniBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 273);
            this.Controls.Add(this.wbLogin);
            this.Name = "MiniBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MiniBrowser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MiniBrowser_FormClosing);
            this.Shown += new System.EventHandler(this.MiniBrowser_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbLogin;
    }
}