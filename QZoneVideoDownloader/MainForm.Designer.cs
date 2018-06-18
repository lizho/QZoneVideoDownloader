namespace QZoneVideoDownloader
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label2;
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbUserInfo = new System.Windows.Forms.TextBox();
            this.VideoTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Download = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvCover = new System.Windows.Forms.ListView();
            this.cmsDownload = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ilCover = new System.Windows.Forms.ImageList(this.components);
            this.btnPre = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btnSel = new System.Windows.Forms.Button();
            this.fbdSaveDir = new System.Windows.Forms.FolderBrowserDialog();
            this.tDownload = new System.Windows.Forms.Timer(this.components);
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            this.cmsDownload.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 381);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 12);
            label2.TabIndex = 10;
            label2.Text = "保存路径：";
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(643, 347);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(12, 12);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // tbUserInfo
            // 
            this.tbUserInfo.BackColor = System.Drawing.SystemColors.Window;
            this.tbUserInfo.Location = new System.Drawing.Point(93, 14);
            this.tbUserInfo.Name = "tbUserInfo";
            this.tbUserInfo.ReadOnly = true;
            this.tbUserInfo.Size = new System.Drawing.Size(625, 21);
            this.tbUserInfo.TabIndex = 4;
            this.tbUserInfo.Text = "请登录";
            // 
            // VideoTitle
            // 
            this.VideoTitle.Text = "视频";
            // 
            // Download
            // 
            this.Download.Text = "下载";
            // 
            // lvCover
            // 
            this.lvCover.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.VideoTitle,
            this.Download});
            this.lvCover.ContextMenuStrip = this.cmsDownload;
            this.lvCover.FullRowSelect = true;
            this.lvCover.LargeImageList = this.ilCover;
            this.lvCover.Location = new System.Drawing.Point(12, 41);
            this.lvCover.Name = "lvCover";
            this.lvCover.Size = new System.Drawing.Size(706, 300);
            this.lvCover.TabIndex = 1;
            this.lvCover.UseCompatibleStateImageBehavior = false;
            // 
            // cmsDownload
            // 
            this.cmsDownload.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DLToolStripMenuItem});
            this.cmsDownload.Name = "contextMenuStrip1";
            this.cmsDownload.Size = new System.Drawing.Size(101, 26);
            // 
            // DLToolStripMenuItem
            // 
            this.DLToolStripMenuItem.Name = "DLToolStripMenuItem";
            this.DLToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.DLToolStripMenuItem.Text = "下载";
            this.DLToolStripMenuItem.Click += new System.EventHandler(this.DLToolStripMenuItem_Click);
            // 
            // ilCover
            // 
            this.ilCover.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilCover.ImageSize = new System.Drawing.Size(180, 120);
            this.ilCover.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnPre
            // 
            this.btnPre.Enabled = false;
            this.btnPre.Location = new System.Drawing.Point(562, 347);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(75, 23);
            this.btnPre.TabIndex = 2;
            this.btnPre.Text = "上一页";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.BtnPre_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 9;
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(81, 378);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(516, 21);
            this.tbPath.TabIndex = 5;
            // 
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(603, 376);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(34, 23);
            this.btnSel.TabIndex = 6;
            this.btnSel.Text = "...";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.BtnSel_Click);
            // 
            // tDownload
            // 
            this.tDownload.Enabled = true;
            this.tDownload.Interval = 20;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(643, 410);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 8;
            this.btnQuit.Text = "退出";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(643, 376);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "清除路径";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 445);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSel);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.lvCover);
            this.Controls.Add(this.tbUserInfo);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnNext);
            this.Name = "MainForm";
            this.Text = "QZone video downloader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cmsDownload.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tbUserInfo;
        private System.Windows.Forms.ColumnHeader VideoTitle;
        private System.Windows.Forms.ColumnHeader Download;
        private System.Windows.Forms.ListView lvCover;
        private System.Windows.Forms.ImageList ilCover;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.FolderBrowserDialog fbdSaveDir;
        private System.Windows.Forms.ContextMenuStrip cmsDownload;
        private System.Windows.Forms.ToolStripMenuItem DLToolStripMenuItem;
        private System.Windows.Forms.Timer tDownload;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnClear;
    }
}

