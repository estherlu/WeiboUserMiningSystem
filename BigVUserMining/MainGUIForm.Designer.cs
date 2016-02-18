namespace WebYQCrawling
{
    partial class MainGUIForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUIForm));
            this.toolBarMain = new System.Windows.Forms.ToolBar();
            this.toolBarBtnSystem = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnSettings = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnSeg = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnFacebook = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnNews = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnBlog = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnSeg2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnStart = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnpause = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnStop = new System.Windows.Forms.ToolBarButton();
            this.imageListToolBar = new System.Windows.Forms.ImageList(this.components);
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.statusBarPanelInfo = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelURLs = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelFiles = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelPages = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelByteCount = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelErrors = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelCPU = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelMem = new System.Windows.Forms.StatusBarPanel();
            this.timerMem = new System.Windows.Forms.Timer(this.components);
            this.timerConnectionInfo = new System.Windows.Forms.Timer(this.components);
            this.imageListPercentage = new System.Windows.Forms.ImageList(this.components);
            this.tabPageMicroBlog = new System.Windows.Forms.TabPage();
            this.tabPageMicroBlogPanel = new System.Windows.Forms.Panel();
            this.tabPageSinaT = new System.Windows.Forms.TabPage();
            this.tabPageSinaTBlogPanel = new System.Windows.Forms.Panel();
            this.tabPageStat = new System.Windows.Forms.TabPage();
            this.tabControlPanel = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelURLs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelPages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelByteCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelCPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelMem)).BeginInit();
            this.tabPageMicroBlog.SuspendLayout();
            this.tabPageSinaT.SuspendLayout();
            this.tabControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBarMain
            // 
            this.toolBarMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBarMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarBtnSystem,
            this.toolBarBtnSettings,
            this.toolBarBtnSeg,
            this.toolBarBtnFacebook,
            this.toolBarBtnNews,
            this.toolBarBtnBlog,
            this.toolBarBtnSeg2,
            this.toolBarBtnStart,
            this.toolBarBtnpause,
            this.toolBarBtnStop});
            this.toolBarMain.DropDownArrows = true;
            this.toolBarMain.ImageList = this.imageListToolBar;
            this.toolBarMain.Location = new System.Drawing.Point(0, 0);
            this.toolBarMain.Name = "toolBarMain";
            this.toolBarMain.ShowToolTips = true;
            this.toolBarMain.Size = new System.Drawing.Size(1016, 41);
            this.toolBarMain.TabIndex = 0;
            // 
            // toolBarBtnSystem
            // 
            this.toolBarBtnSystem.ImageIndex = 6;
            this.toolBarBtnSystem.Name = "toolBarBtnSystem";
            this.toolBarBtnSystem.Text = "系统";
            this.toolBarBtnSystem.ToolTipText = "系统菜单";
            // 
            // toolBarBtnSettings
            // 
            this.toolBarBtnSettings.ImageIndex = 4;
            this.toolBarBtnSettings.Name = "toolBarBtnSettings";
            this.toolBarBtnSettings.Text = "设置";
            this.toolBarBtnSettings.ToolTipText = "系统设置";
            // 
            // toolBarBtnSeg
            // 
            this.toolBarBtnSeg.Name = "toolBarBtnSeg";
            this.toolBarBtnSeg.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarBtnFacebook
            // 
            this.toolBarBtnFacebook.ImageIndex = 11;
            this.toolBarBtnFacebook.Name = "toolBarBtnFacebook";
            this.toolBarBtnFacebook.Text = "用户采集";
            this.toolBarBtnFacebook.ToolTipText = "微博用户数据采集";
            // 
            // toolBarBtnNews
            // 
            this.toolBarBtnNews.ImageIndex = 5;
            this.toolBarBtnNews.Name = "toolBarBtnNews";
            this.toolBarBtnNews.Text = "统计分析";
            this.toolBarBtnNews.ToolTipText = "微博名人堂用户信息统计分析";
            // 
            // toolBarBtnBlog
            // 
            this.toolBarBtnBlog.ImageIndex = 7;
            this.toolBarBtnBlog.Name = "toolBarBtnBlog";
            this.toolBarBtnBlog.Text = "社区发现";
            this.toolBarBtnBlog.ToolTipText = "名人堂社区发现";
            // 
            // toolBarBtnSeg2
            // 
            this.toolBarBtnSeg2.Name = "toolBarBtnSeg2";
            this.toolBarBtnSeg2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarBtnStart
            // 
            this.toolBarBtnStart.ImageIndex = 0;
            this.toolBarBtnStart.Name = "toolBarBtnStart";
            this.toolBarBtnStart.Text = "运行";
            this.toolBarBtnStart.ToolTipText = "开始运行";
            // 
            // toolBarBtnpause
            // 
            this.toolBarBtnpause.ImageIndex = 1;
            this.toolBarBtnpause.Name = "toolBarBtnpause";
            this.toolBarBtnpause.Text = "暂停";
            this.toolBarBtnpause.ToolTipText = "暂停运行";
            // 
            // toolBarBtnStop
            // 
            this.toolBarBtnStop.ImageIndex = 2;
            this.toolBarBtnStop.Name = "toolBarBtnStop";
            this.toolBarBtnStop.Text = "停止";
            this.toolBarBtnStop.ToolTipText = "停止运行";
            // 
            // imageListToolBar
            // 
            this.imageListToolBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListToolBar.ImageStream")));
            this.imageListToolBar.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListToolBar.Images.SetKeyName(0, "");
            this.imageListToolBar.Images.SetKeyName(1, "");
            this.imageListToolBar.Images.SetKeyName(2, "");
            this.imageListToolBar.Images.SetKeyName(3, "");
            this.imageListToolBar.Images.SetKeyName(4, "");
            this.imageListToolBar.Images.SetKeyName(5, "【Eye-“社会”超越“发展”高度聚焦“生态”】.jpg");
            this.imageListToolBar.Images.SetKeyName(6, "3齿轮.jpg");
            this.imageListToolBar.Images.SetKeyName(7, "Blog-32x32.ico");
            this.imageListToolBar.Images.SetKeyName(8, "量子雷达.png");
            this.imageListToolBar.Images.SetKeyName(9, "炮炮兵.jpg");
            this.imageListToolBar.Images.SetKeyName(10, "Crawler.jpg");
            this.imageListToolBar.Images.SetKeyName(11, "Facebook3.jpg");
            // 
            // statusBar
            // 
            this.statusBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.statusBar.Dock = System.Windows.Forms.DockStyle.None;
            this.statusBar.Location = new System.Drawing.Point(0, 712);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanelInfo,
            this.statusBarPanelURLs,
            this.statusBarPanelFiles,
            this.statusBarPanelPages,
            this.statusBarPanelByteCount,
            this.statusBarPanelErrors,
            this.statusBarPanelCPU,
            this.statusBarPanelMem});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(1016, 24);
            this.statusBar.TabIndex = 4;
            this.statusBar.Text = "Ready";
            // 
            // statusBarPanelInfo
            // 
            this.statusBarPanelInfo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanelInfo.Name = "statusBarPanelInfo";
            this.statusBarPanelInfo.ToolTipText = "View total parsed uris";
            this.statusBarPanelInfo.Width = 710;
            // 
            // statusBarPanelURLs
            // 
            this.statusBarPanelURLs.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.statusBarPanelURLs.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanelURLs.Name = "statusBarPanelURLs";
            this.statusBarPanelURLs.ToolTipText = "View unique hits count";
            this.statusBarPanelURLs.Width = 10;
            // 
            // statusBarPanelFiles
            // 
            this.statusBarPanelFiles.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.statusBarPanelFiles.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanelFiles.Name = "statusBarPanelFiles";
            this.statusBarPanelFiles.ToolTipText = "View total hits count";
            this.statusBarPanelFiles.Width = 10;
            // 
            // statusBarPanelPages
            // 
            this.statusBarPanelPages.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.statusBarPanelPages.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanelPages.Name = "statusBarPanelPages";
            this.statusBarPanelPages.ToolTipText = "View total Articles have been extracted";
            this.statusBarPanelPages.Width = 10;
            // 
            // statusBarPanelByteCount
            // 
            this.statusBarPanelByteCount.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.statusBarPanelByteCount.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanelByteCount.Name = "statusBarPanelByteCount";
            this.statusBarPanelByteCount.ToolTipText = "View total bytes of parsed items";
            this.statusBarPanelByteCount.Width = 10;
            // 
            // statusBarPanelErrors
            // 
            this.statusBarPanelErrors.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.statusBarPanelErrors.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanelErrors.Icon = ((System.Drawing.Icon)(resources.GetObject("statusBarPanelErrors.Icon")));
            this.statusBarPanelErrors.Name = "statusBarPanelErrors";
            this.statusBarPanelErrors.ToolTipText = "View errors count";
            this.statusBarPanelErrors.Width = 31;
            // 
            // statusBarPanelCPU
            // 
            this.statusBarPanelCPU.Icon = ((System.Drawing.Icon)(resources.GetObject("statusBarPanelCPU.Icon")));
            this.statusBarPanelCPU.Name = "statusBarPanelCPU";
            this.statusBarPanelCPU.ToolTipText = "CPU usage";
            this.statusBarPanelCPU.Width = 109;
            // 
            // statusBarPanelMem
            // 
            this.statusBarPanelMem.Name = "statusBarPanelMem";
            this.statusBarPanelMem.ToolTipText = "Available memory";
            this.statusBarPanelMem.Width = 109;
            // 
            // timerMem
            // 
            this.timerMem.Enabled = true;
            this.timerMem.Interval = 2000;
            this.timerMem.Tick += new System.EventHandler(this.timerMem_Tick);
            // 
            // timerConnectionInfo
            // 
            this.timerConnectionInfo.Enabled = true;
            this.timerConnectionInfo.Interval = 60000;
            this.timerConnectionInfo.Tick += new System.EventHandler(this.timerConnectionInfo_Tick);
            // 
            // imageListPercentage
            // 
            this.imageListPercentage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPercentage.ImageStream")));
            this.imageListPercentage.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListPercentage.Images.SetKeyName(0, "");
            this.imageListPercentage.Images.SetKeyName(1, "");
            this.imageListPercentage.Images.SetKeyName(2, "");
            this.imageListPercentage.Images.SetKeyName(3, "");
            this.imageListPercentage.Images.SetKeyName(4, "");
            this.imageListPercentage.Images.SetKeyName(5, "");
            this.imageListPercentage.Images.SetKeyName(6, "");
            this.imageListPercentage.Images.SetKeyName(7, "");
            this.imageListPercentage.Images.SetKeyName(8, "");
            this.imageListPercentage.Images.SetKeyName(9, "");
            this.imageListPercentage.Images.SetKeyName(10, "");
            // 
            // tabPageMicroBlog
            // 
            this.tabPageMicroBlog.Controls.Add(this.tabPageMicroBlogPanel);
            this.tabPageMicroBlog.Location = new System.Drawing.Point(4, 21);
            this.tabPageMicroBlog.Name = "tabPageMicroBlog";
            this.tabPageMicroBlog.Size = new System.Drawing.Size(1007, 651);
            this.tabPageMicroBlog.TabIndex = 3;
            this.tabPageMicroBlog.Text = "Data Collection";
            this.tabPageMicroBlog.UseVisualStyleBackColor = true;
            // 
            // tabPageMicroBlogPanel
            // 
            this.tabPageMicroBlogPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPageMicroBlogPanel.Location = new System.Drawing.Point(-4, 3);
            this.tabPageMicroBlogPanel.Name = "tabPageMicroBlogPanel";
            this.tabPageMicroBlogPanel.Size = new System.Drawing.Size(1012, 681);
            this.tabPageMicroBlogPanel.TabIndex = 12;
            // 
            // tabPageSinaT
            // 
            this.tabPageSinaT.Controls.Add(this.tabPageSinaTBlogPanel);
            this.tabPageSinaT.Location = new System.Drawing.Point(4, 21);
            this.tabPageSinaT.Name = "tabPageSinaT";
            this.tabPageSinaT.Size = new System.Drawing.Size(1007, 651);
            this.tabPageSinaT.TabIndex = 2;
            this.tabPageSinaT.Text = "Community Detection";
            this.tabPageSinaT.UseVisualStyleBackColor = true;
            // 
            // tabPageSinaTBlogPanel
            // 
            this.tabPageSinaTBlogPanel.Location = new System.Drawing.Point(-4, 0);
            this.tabPageSinaTBlogPanel.Name = "tabPageSinaTBlogPanel";
            this.tabPageSinaTBlogPanel.Size = new System.Drawing.Size(1008, 677);
            this.tabPageSinaTBlogPanel.TabIndex = 0;
            // 
            // tabPageStat
            // 
            this.tabPageStat.Location = new System.Drawing.Point(4, 21);
            this.tabPageStat.Name = "tabPageStat";
            this.tabPageStat.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStat.Size = new System.Drawing.Size(1007, 651);
            this.tabPageStat.TabIndex = 1;
            this.tabPageStat.Text = "Statistical Analysis";
            this.tabPageStat.UseVisualStyleBackColor = true;
            // 
            // tabControlPanel
            // 
            this.tabControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlPanel.Controls.Add(this.tabPageMicroBlog);
            this.tabControlPanel.Controls.Add(this.tabPageStat);
            this.tabControlPanel.Controls.Add(this.tabPageSinaT);
            this.tabControlPanel.ItemSize = new System.Drawing.Size(96, 17);
            this.tabControlPanel.Location = new System.Drawing.Point(1, 38);
            this.tabControlPanel.Name = "tabControlPanel";
            this.tabControlPanel.SelectedIndex = 0;
            this.tabControlPanel.Size = new System.Drawing.Size(1015, 676);
            this.tabControlPanel.TabIndex = 3;
            this.tabControlPanel.SelectedIndexChanged += new System.EventHandler(this.tabControlPanel_SelectedIndexChanged);
            // 
            // MainGUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 736);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.tabControlPanel);
            this.Controls.Add(this.toolBarMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainGUIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JW-Web Data Crawling and Captcha Sniper System V0.5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainGUIForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelURLs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelPages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelByteCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelCPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelMem)).EndInit();
            this.tabPageMicroBlog.ResumeLayout(false);
            this.tabPageSinaT.ResumeLayout(false);
            this.tabControlPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolBar toolBarMain;
        private System.Windows.Forms.ToolBarButton toolBarBtnSystem;
        private System.Windows.Forms.ToolBarButton toolBarBtnSeg;
        private System.Windows.Forms.ToolBarButton toolBarBtnCommnity;
        private System.Windows.Forms.ToolBarButton toolBarBtnSettings;
        private System.Windows.Forms.ToolBarButton toolBarBtnStat;
        private System.Windows.Forms.ToolBarButton toolBarBtnSeg2;
        private System.Windows.Forms.ImageList imageListToolBar;
        private System.Windows.Forms.ToolBarButton toolBarBtnCrawl;
        private System.Windows.Forms.ToolBarButton toolBarBtnStart;
        private System.Windows.Forms.ToolBarButton toolBarBtnpause;
        private System.Windows.Forms.ToolBarButton toolBarBtnStop;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.StatusBarPanel statusBarPanelInfo;
        private System.Windows.Forms.StatusBarPanel statusBarPanelURLs;
        private System.Windows.Forms.StatusBarPanel statusBarPanelFiles;
        private System.Windows.Forms.StatusBarPanel statusBarPanelPages;
        private System.Windows.Forms.StatusBarPanel statusBarPanelByteCount;
        private System.Windows.Forms.StatusBarPanel statusBarPanelErrors;
        private System.Windows.Forms.StatusBarPanel statusBarPanelCPU;
        private System.Windows.Forms.StatusBarPanel statusBarPanelMem;
        private System.Windows.Forms.Timer timerMem;
        private System.Windows.Forms.Timer timerConnectionInfo;
        private System.Windows.Forms.ImageList imageListPercentage;
        private System.Windows.Forms.TabPage tabPageMicroBlog;
        private System.Windows.Forms.Panel tabPageMicroBlogPanel;
        private System.Windows.Forms.TabPage tabPageSinaT;
        private System.Windows.Forms.Panel tabPageSinaTBlogPanel;
        private System.Windows.Forms.TabPage tabPageStat;
        private System.Windows.Forms.TabControl tabControlPanel;
        private System.Windows.Forms.ToolBarButton toolBarBtnFacebook;
        private System.Windows.Forms.ToolBarButton toolBarBtnNews;
        private System.Windows.Forms.ToolBarButton toolBarBtnBlog;


    }
}

