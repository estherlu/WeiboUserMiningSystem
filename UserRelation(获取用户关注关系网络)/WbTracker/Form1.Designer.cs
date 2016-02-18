namespace WbTracker
{
    partial class Form1
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
            this.btnauth = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tbreduri = new System.Windows.Forms.TextBox();
            this.btnsendmsg = new System.Windows.Forms.Button();
            this.tbssid = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbusernum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbcrawlstate = new System.Windows.Forms.Label();
            this.tbcustate = new System.Windows.Forms.TextBox();
            this.btnuserstatus = new System.Windows.Forms.Button();
            this.tbrootid = new System.Windows.Forms.TabControl();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbtaskfile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tballfile = new System.Windows.Forms.TextBox();
            this.tabPage4.SuspendLayout();
            this.tbrootid.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnauth
            // 
            this.btnauth.Location = new System.Drawing.Point(9, 30);
            this.btnauth.Name = "btnauth";
            this.btnauth.Size = new System.Drawing.Size(84, 50);
            this.btnauth.TabIndex = 19;
            this.btnauth.Text = "（初始化）OAuth2.0授权获取Access_Token";
            this.btnauth.UseVisualStyleBackColor = true;
            this.btnauth.Click += new System.EventHandler(this.btnauth_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "redirect_uri";
            // 
            // tbreduri
            // 
            this.tbreduri.Location = new System.Drawing.Point(12, 119);
            this.tbreduri.Name = "tbreduri";
            this.tbreduri.Size = new System.Drawing.Size(209, 21);
            this.tbreduri.TabIndex = 21;
            this.tbreduri.Text = "https://api.weibo.com/oauth2/default.html";
            // 
            // btnsendmsg
            // 
            this.btnsendmsg.Location = new System.Drawing.Point(9, 96);
            this.btnsendmsg.Name = "btnsendmsg";
            this.btnsendmsg.Size = new System.Drawing.Size(66, 50);
            this.btnsendmsg.TabIndex = 7;
            this.btnsendmsg.Text = "加载Web飞信Cookie";
            this.btnsendmsg.UseVisualStyleBackColor = true;
            this.btnsendmsg.Click += new System.EventHandler(this.btnsendmsg_Click);
            // 
            // tbssid
            // 
            this.tbssid.Location = new System.Drawing.Point(9, 48);
            this.tbssid.Multiline = true;
            this.tbssid.Name = "tbssid";
            this.tbssid.Size = new System.Drawing.Size(189, 42);
            this.tbssid.TabIndex = 22;
            this.tbssid.Text = "369842708p3111-fbdac41f-147e-4d19-853d-1d9795d1bd70";
            this.tbssid.TextChanged += new System.EventHandler(this.tbssid_TextChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.lbusernum);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.lbcrawlstate);
            this.tabPage4.Controls.Add(this.tbcustate);
            this.tabPage4.Controls.Add(this.btnuserstatus);
            this.tabPage4.Controls.Add(this.btnauth);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(570, 304);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "用户关注关系抓取";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 21);
            this.button2.TabIndex = 20;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "实时状态";
            // 
            // lbusernum
            // 
            this.lbusernum.AutoSize = true;
            this.lbusernum.Location = new System.Drawing.Point(108, 266);
            this.lbusernum.Name = "lbusernum";
            this.lbusernum.Size = new System.Drawing.Size(23, 12);
            this.lbusernum.TabIndex = 8;
            this.lbusernum.Text = "num";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "待处理用户数";
            // 
            // lbcrawlstate
            // 
            this.lbcrawlstate.AutoSize = true;
            this.lbcrawlstate.Location = new System.Drawing.Point(108, 287);
            this.lbcrawlstate.Name = "lbcrawlstate";
            this.lbcrawlstate.Size = new System.Drawing.Size(35, 12);
            this.lbcrawlstate.TabIndex = 6;
            this.lbcrawlstate.Text = "state";
            // 
            // tbcustate
            // 
            this.tbcustate.Location = new System.Drawing.Point(105, 3);
            this.tbcustate.Multiline = true;
            this.tbcustate.Name = "tbcustate";
            this.tbcustate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbcustate.Size = new System.Drawing.Size(455, 257);
            this.tbcustate.TabIndex = 5;
            this.tbcustate.TextChanged += new System.EventHandler(this.tbcustate_TextChanged);
            // 
            // btnuserstatus
            // 
            this.btnuserstatus.Location = new System.Drawing.Point(9, 106);
            this.btnuserstatus.Name = "btnuserstatus";
            this.btnuserstatus.Size = new System.Drawing.Size(84, 57);
            this.btnuserstatus.TabIndex = 4;
            this.btnuserstatus.Text = "获取用户关系列表V2.0";
            this.btnuserstatus.UseVisualStyleBackColor = true;
            this.btnuserstatus.Click += new System.EventHandler(this.btnuserstatus_Click);
            // 
            // tbrootid
            // 
            this.tbrootid.Controls.Add(this.tabPage4);
            this.tbrootid.Location = new System.Drawing.Point(12, 143);
            this.tbrootid.Name = "tbrootid";
            this.tbrootid.SelectedIndex = 0;
            this.tbrootid.Size = new System.Drawing.Size(578, 330);
            this.tbrootid.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "本次通讯的ssid";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 50);
            this.button1.TabIndex = 25;
            this.button1.Text = "测试飞信连通性";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbssid);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnsendmsg);
            this.groupBox1.Location = new System.Drawing.Point(380, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 151);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "飞信通讯模块（个人使用）";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(365, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "（处理任务的文件名，文件需放在根目录的RelationDemo文件夹下）";
            // 
            // tbtaskfile
            // 
            this.tbtaskfile.Location = new System.Drawing.Point(16, 31);
            this.tbtaskfile.Name = "tbtaskfile";
            this.tbtaskfile.Size = new System.Drawing.Size(135, 21);
            this.tbtaskfile.TabIndex = 28;
            this.tbtaskfile.Text = "Opart0.txt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(377, 12);
            this.label5.TabIndex = 29;
            this.label5.Text = "（封闭集合用户文件名，文件需放在根目录的RelationDemo文件夹下）";
            // 
            // tballfile
            // 
            this.tballfile.Location = new System.Drawing.Point(16, 78);
            this.tballfile.Name = "tballfile";
            this.tballfile.Size = new System.Drawing.Size(135, 21);
            this.tballfile.TabIndex = 30;
            this.tballfile.Text = "Alluser.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 477);
            this.Controls.Add(this.tballfile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbtaskfile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbreduri);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbrootid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "用户关系网络获取";
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tbrootid.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnauth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbreduri;
        private System.Windows.Forms.Button btnsendmsg;
        private System.Windows.Forms.TextBox tbssid;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lbcrawlstate;
        private System.Windows.Forms.TextBox tbcustate;
        private System.Windows.Forms.Button btnuserstatus;
        private System.Windows.Forms.TabControl tbrootid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbusernum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbtaskfile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tballfile;
        private System.Windows.Forms.Button button2;
    }
}

