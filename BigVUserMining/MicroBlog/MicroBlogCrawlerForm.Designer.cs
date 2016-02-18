namespace WebYQCrawling.MicroBlog
{
    partial class MicroBlogCrawlerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MicroBlogCrawlerForm));
            this.btnGetPublicTimeLine = new System.Windows.Forms.Button();
            this.grpCurrentUser = new System.Windows.Forms.GroupBox();
            this.lblDBName = new System.Windows.Forms.Label();
            this.lblCVerified = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.lblCFollowing = new System.Windows.Forms.Label();
            this.lblCStatusesCount = new System.Windows.Forms.Label();
            this.lblCCreatedAt = new System.Windows.Forms.Label();
            this.lblCFriendsCount = new System.Windows.Forms.Label();
            this.lblCFollowersCount = new System.Windows.Forms.Label();
            this.lblCGender = new System.Windows.Forms.Label();
            this.lblCLocation = new System.Windows.Forms.Label();
            this.lblCName = new System.Windows.Forms.Label();
            this.lblCUserID = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnPauseContinue = new System.Windows.Forms.Button();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.lsMicroBlogUser = new System.Windows.Forms.ListView();
            this.colHeaderUserCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadSex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadScreenName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadBlogCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadFriendCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadFanCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadCreatedIime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblPublicTimeLineMessage = new System.Windows.Forms.Label();
            this.lblPublicTimeLineTitle = new System.Windows.Forms.Label();
            this.grpCurrentUser.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetPublicTimeLine
            // 
            this.btnGetPublicTimeLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetPublicTimeLine.Location = new System.Drawing.Point(813, 62);
            this.btnGetPublicTimeLine.Name = "btnGetPublicTimeLine";
            this.btnGetPublicTimeLine.Size = new System.Drawing.Size(89, 36);
            this.btnGetPublicTimeLine.TabIndex = 0;
            this.btnGetPublicTimeLine.Text = "微博数据采集";
            this.btnGetPublicTimeLine.UseVisualStyleBackColor = true;
            this.btnGetPublicTimeLine.Click += new System.EventHandler(this.btnGetPublicTimeLine_Click);
            // 
            // grpCurrentUser
            // 
            this.grpCurrentUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCurrentUser.Controls.Add(this.lblDBName);
            this.grpCurrentUser.Controls.Add(this.lblCVerified);
            this.grpCurrentUser.Controls.Add(this.txtDBName);
            this.grpCurrentUser.Controls.Add(this.lblCFollowing);
            this.grpCurrentUser.Controls.Add(this.lblCStatusesCount);
            this.grpCurrentUser.Controls.Add(this.lblCCreatedAt);
            this.grpCurrentUser.Controls.Add(this.lblCFriendsCount);
            this.grpCurrentUser.Controls.Add(this.lblCFollowersCount);
            this.grpCurrentUser.Controls.Add(this.lblCGender);
            this.grpCurrentUser.Controls.Add(this.lblCLocation);
            this.grpCurrentUser.Controls.Add(this.lblCName);
            this.grpCurrentUser.Controls.Add(this.lblCUserID);
            this.grpCurrentUser.Location = new System.Drawing.Point(4, 9);
            this.grpCurrentUser.Name = "grpCurrentUser";
            this.grpCurrentUser.Size = new System.Drawing.Size(780, 88);
            this.grpCurrentUser.TabIndex = 10;
            this.grpCurrentUser.TabStop = false;
            this.grpCurrentUser.Text = "Settings";
            this.grpCurrentUser.Enter += new System.EventHandler(this.grpCurrentUser_Enter);
            // 
            // lblDBName
            // 
            this.lblDBName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDBName.AutoSize = true;
            this.lblDBName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDBName.Location = new System.Drawing.Point(514, 23);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(95, 12);
            this.lblDBName.TabIndex = 22;
            this.lblDBName.Text = "Local Database:";
            this.lblDBName.Click += new System.EventHandler(this.lblDBName_Click);
            // 
            // lblCVerified
            // 
            this.lblCVerified.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCVerified.AutoSize = true;
            this.lblCVerified.Location = new System.Drawing.Point(368, 26);
            this.lblCVerified.Name = "lblCVerified";
            this.lblCVerified.Size = new System.Drawing.Size(59, 12);
            this.lblCVerified.TabIndex = 9;
            this.lblCVerified.Text = "Verified:";
            // 
            // txtDBName
            // 
            this.txtDBName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDBName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDBName.Location = new System.Drawing.Point(626, 20);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(143, 21);
            this.txtDBName.TabIndex = 21;
            this.txtDBName.Text = "SinaTimeLine201211";
            // 
            // lblCFollowing
            // 
            this.lblCFollowing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCFollowing.AutoSize = true;
            this.lblCFollowing.Location = new System.Drawing.Point(514, 53);
            this.lblCFollowing.Name = "lblCFollowing";
            this.lblCFollowing.Size = new System.Drawing.Size(113, 12);
            this.lblCFollowing.TabIndex = 8;
            this.lblCFollowing.Text = "Friend of Current:";
            this.lblCFollowing.Visible = false;
            // 
            // lblCStatusesCount
            // 
            this.lblCStatusesCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCStatusesCount.AutoSize = true;
            this.lblCStatusesCount.Location = new System.Drawing.Point(368, 59);
            this.lblCStatusesCount.Name = "lblCStatusesCount";
            this.lblCStatusesCount.Size = new System.Drawing.Size(41, 12);
            this.lblCStatusesCount.TabIndex = 7;
            this.lblCStatusesCount.Text = "Posts:";
            // 
            // lblCCreatedAt
            // 
            this.lblCCreatedAt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCCreatedAt.AutoSize = true;
            this.lblCCreatedAt.Location = new System.Drawing.Point(514, 73);
            this.lblCCreatedAt.Name = "lblCCreatedAt";
            this.lblCCreatedAt.Size = new System.Drawing.Size(77, 12);
            this.lblCCreatedAt.TabIndex = 6;
            this.lblCCreatedAt.Text = "Creation at:";
            // 
            // lblCFriendsCount
            // 
            this.lblCFriendsCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCFriendsCount.AutoSize = true;
            this.lblCFriendsCount.Location = new System.Drawing.Point(257, 59);
            this.lblCFriendsCount.Name = "lblCFriendsCount";
            this.lblCFriendsCount.Size = new System.Drawing.Size(53, 12);
            this.lblCFriendsCount.TabIndex = 5;
            this.lblCFriendsCount.Text = "Friends:";
            // 
            // lblCFollowersCount
            // 
            this.lblCFollowersCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCFollowersCount.AutoSize = true;
            this.lblCFollowersCount.Location = new System.Drawing.Point(141, 59);
            this.lblCFollowersCount.Name = "lblCFollowersCount";
            this.lblCFollowersCount.Size = new System.Drawing.Size(65, 12);
            this.lblCFollowersCount.TabIndex = 4;
            this.lblCFollowersCount.Text = "Followers:";
            // 
            // lblCGender
            // 
            this.lblCGender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCGender.AutoSize = true;
            this.lblCGender.Location = new System.Drawing.Point(280, 26);
            this.lblCGender.Name = "lblCGender";
            this.lblCGender.Size = new System.Drawing.Size(47, 12);
            this.lblCGender.TabIndex = 3;
            this.lblCGender.Text = "Gender:";
            // 
            // lblCLocation
            // 
            this.lblCLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCLocation.AutoSize = true;
            this.lblCLocation.Location = new System.Drawing.Point(11, 59);
            this.lblCLocation.Name = "lblCLocation";
            this.lblCLocation.Size = new System.Drawing.Size(59, 12);
            this.lblCLocation.TabIndex = 2;
            this.lblCLocation.Text = "Location:";
            // 
            // lblCName
            // 
            this.lblCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCName.AutoSize = true;
            this.lblCName.Location = new System.Drawing.Point(141, 26);
            this.lblCName.Name = "lblCName";
            this.lblCName.Size = new System.Drawing.Size(59, 12);
            this.lblCName.TabIndex = 1;
            this.lblCName.Text = "Nickname:";
            // 
            // lblCUserID
            // 
            this.lblCUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCUserID.AutoSize = true;
            this.lblCUserID.Location = new System.Drawing.Point(11, 26);
            this.lblCUserID.Name = "lblCUserID";
            this.lblCUserID.Size = new System.Drawing.Size(47, 12);
            this.lblCUserID.TabIndex = 0;
            this.lblCUserID.Text = "UserID:";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.Location = new System.Drawing.Point(813, 14);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(89, 36);
            this.btnLogin.TabIndex = 23;
            this.btnLogin.Text = "用户登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnPauseContinue
            // 
            this.btnPauseContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPauseContinue.Enabled = false;
            this.btnPauseContinue.Location = new System.Drawing.Point(931, 62);
            this.btnPauseContinue.Name = "btnPauseContinue";
            this.btnPauseContinue.Size = new System.Drawing.Size(74, 36);
            this.btnPauseContinue.TabIndex = 20;
            this.btnPauseContinue.Text = "暂停/继续";
            this.btnPauseContinue.UseVisualStyleBackColor = true;
            this.btnPauseContinue.Click += new System.EventHandler(this.btnPauseContinue_Click);
            // 
            // grpStatus
            // 
            this.grpStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStatus.Controls.Add(this.lsMicroBlogUser);
            this.grpStatus.Controls.Add(this.lblPublicTimeLineMessage);
            this.grpStatus.Controls.Add(this.lblPublicTimeLineTitle);
            this.grpStatus.Location = new System.Drawing.Point(4, 106);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(1016, 421);
            this.grpStatus.TabIndex = 18;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Supervision";
            // 
            // lsMicroBlogUser
            // 
            this.lsMicroBlogUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsMicroBlogUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderUserCount,
            this.colHeadID,
            this.colHeadName,
            this.colHeadSex,
            this.colHeadScreenName,
            this.colHeadLocation,
            this.colHeadDescription,
            this.colHeadBlogCount,
            this.colHeadFriendCount,
            this.colHeadFanCount,
            this.colHeadCreatedIime});
            this.lsMicroBlogUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.lsMicroBlogUser.GridLines = true;
            this.lsMicroBlogUser.HoverSelection = true;
            this.lsMicroBlogUser.Location = new System.Drawing.Point(6, 53);
            this.lsMicroBlogUser.Name = "lsMicroBlogUser";
            this.lsMicroBlogUser.Size = new System.Drawing.Size(1004, 362);
            this.lsMicroBlogUser.TabIndex = 18;
            this.lsMicroBlogUser.UseCompatibleStateImageBehavior = false;
            this.lsMicroBlogUser.View = System.Windows.Forms.View.Details;
            // 
            // colHeaderUserCount
            // 
            this.colHeaderUserCount.Text = "序号";
            this.colHeaderUserCount.Width = 50;
            // 
            // colHeadID
            // 
            this.colHeadID.Text = "用户ID";
            this.colHeadID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHeadID.Width = 100;
            // 
            // colHeadName
            // 
            this.colHeadName.Text = "用户姓名";
            this.colHeadName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHeadName.Width = 90;
            // 
            // colHeadSex
            // 
            this.colHeadSex.Text = "性别";
            this.colHeadSex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHeadSex.Width = 40;
            // 
            // colHeadScreenName
            // 
            this.colHeadScreenName.Text = "用户昵称";
            this.colHeadScreenName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHeadScreenName.Width = 90;
            // 
            // colHeadLocation
            // 
            this.colHeadLocation.Text = "地理位置";
            this.colHeadLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHeadLocation.Width = 110;
            // 
            // colHeadDescription
            // 
            this.colHeadDescription.Text = "个人描述";
            this.colHeadDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHeadDescription.Width = 185;
            // 
            // colHeadBlogCount
            // 
            this.colHeadBlogCount.Text = "微博数";
            this.colHeadBlogCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHeadBlogCount.Width = 55;
            // 
            // colHeadFriendCount
            // 
            this.colHeadFriendCount.Text = "好友数";
            this.colHeadFriendCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHeadFriendCount.Width = 55;
            // 
            // colHeadFanCount
            // 
            this.colHeadFanCount.Text = "粉丝数";
            this.colHeadFanCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHeadFanCount.Width = 55;
            // 
            // colHeadCreatedIime
            // 
            this.colHeadCreatedIime.Text = "创建时间";
            this.colHeadCreatedIime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHeadCreatedIime.Width = 165;
            // 
            // lblPublicTimeLineMessage
            // 
            this.lblPublicTimeLineMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPublicTimeLineMessage.AutoSize = true;
            this.lblPublicTimeLineMessage.Location = new System.Drawing.Point(162, 28);
            this.lblPublicTimeLineMessage.Name = "lblPublicTimeLineMessage";
            this.lblPublicTimeLineMessage.Size = new System.Drawing.Size(35, 12);
            this.lblPublicTimeLineMessage.TabIndex = 17;
            this.lblPublicTimeLineMessage.Text = "stop.";
            this.lblPublicTimeLineMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPublicTimeLineTitle
            // 
            this.lblPublicTimeLineTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPublicTimeLineTitle.AutoSize = true;
            this.lblPublicTimeLineTitle.Location = new System.Drawing.Point(9, 28);
            this.lblPublicTimeLineTitle.Name = "lblPublicTimeLineTitle";
            this.lblPublicTimeLineTitle.Size = new System.Drawing.Size(47, 12);
            this.lblPublicTimeLineTitle.TabIndex = 16;
            this.lblPublicTimeLineTitle.Text = "Status:";
            this.lblPublicTimeLineTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MicroBlogCrawlerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 562);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnGetPublicTimeLine);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.grpCurrentUser);
            this.Controls.Add(this.btnPauseContinue);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MicroBlogCrawlerForm";
            this.Text = "Sina Weibo Data Collection V1.0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.MicroBlogCrawlerForm_Load);
            this.grpCurrentUser.ResumeLayout(false);
            this.grpCurrentUser.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetPublicTimeLine;
        private System.Windows.Forms.GroupBox grpCurrentUser;
        private System.Windows.Forms.Label lblCVerified;
        private System.Windows.Forms.Label lblCFollowing;
        private System.Windows.Forms.Label lblCStatusesCount;
        private System.Windows.Forms.Label lblCCreatedAt;
        private System.Windows.Forms.Label lblCFriendsCount;
        private System.Windows.Forms.Label lblCFollowersCount;
        private System.Windows.Forms.Label lblCGender;
        private System.Windows.Forms.Label lblCLocation;
        private System.Windows.Forms.Label lblCName;
        private System.Windows.Forms.Label lblCUserID;
        private System.Windows.Forms.Button btnPauseContinue;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.Label lblPublicTimeLineMessage;
        private System.Windows.Forms.Label lblPublicTimeLineTitle;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.ListView lsMicroBlogUser;
        private System.Windows.Forms.ColumnHeader colHeadID;
        private System.Windows.Forms.ColumnHeader colHeadName;
        private System.Windows.Forms.ColumnHeader colHeadSex;
        private System.Windows.Forms.ColumnHeader colHeadScreenName;
        private System.Windows.Forms.ColumnHeader colHeadLocation;
        private System.Windows.Forms.ColumnHeader colHeadDescription;
        private System.Windows.Forms.ColumnHeader colHeadBlogCount;
        private System.Windows.Forms.ColumnHeader colHeadFriendCount;
        private System.Windows.Forms.ColumnHeader colHeadFanCount;
        private System.Windows.Forms.ColumnHeader colHeadCreatedIime;
        private System.Windows.Forms.ColumnHeader colHeaderUserCount;
        private System.Windows.Forms.Button btnLogin;
    }
}

