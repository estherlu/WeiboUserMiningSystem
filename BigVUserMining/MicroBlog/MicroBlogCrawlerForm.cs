using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetDimension.Weibo;
using NetDimension.Json;
using System.Threading;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace WebYQCrawling.MicroBlog
{
    public partial class MicroBlogCrawlerForm : Form
    {
        private bool blnAuthorized = false;
        private OAuth oauth = new OAuth("3776491555", "54da0e3d19e6b64dd2220873b527882e","http://apps.weibo.com/johnself");
        Dictionary<string, int> userDic = new Dictionary<string, int>();        //用户id字典  //这是个糟糕的设计，但是如果仅仅跑一个月的话数据规模不会超过字典结构的上限
        Dictionary<string, int> statusDic = new Dictionary<string, int>();      //微博id字典
        private Database db;                                                    //数据库保存实例
        string strLogFile = Application.StartupPath + "\\logs\\" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + "_comment.log";//日志文件

        //构造函数
        public MicroBlogCrawlerForm()
        {
            InitializeComponent();
            FileInfo logFile = new FileInfo(strLogFile);
            if (!logFile.Exists)
            {
                logFile.Create();
            }
            //
            this.btnPauseContinue.Enabled = false;
            //跨线程界面调用异常 临时解决办法
            CheckForIllegalCrossThreadCalls = false;                            //不进行跨线程调用检查
        }

        //主界面加载时CheckLogin()
        private void MicroBlogCrawlerForm_Load(object sender, EventArgs e)
        {
            //CheckLogin();  //界面加载时登录账户 gold 已修改
        }

        //gold 微博账户登录
        private void btnLogin_Click(object sender, EventArgs e)
        {
            CheckLogin();   //验证登录账户授权
        }

        //检查登录状态。若未登录，弹出登录框。登录后，设定机器人
        private void CheckLogin()
        {
            if (!blnAuthorized)
            {
                LoginForm login = new LoginForm(oauth);
                if (login.ShowDialog() == DialogResult.OK)
                {
                    blnAuthorized = true;
                    Client sina = new Client(oauth);
                    string userid = sina.API.Entity.Account.GetUID();
                    NetDimension.Weibo.Entities.user.Entity user = sina.API.Entity.Users.Show(userid);
                    ShowCurrentUser(user);
                }
                else
                {
                    btnGetPublicTimeLine.Enabled = false;
                    btnPauseContinue.Enabled = false;
                }
            }
        }

        //显示登录帐号用户信息  待修改
        private void ShowCurrentUser(NetDimension.Weibo.Entities.user.Entity user)
        {
            if (user != null)
            {
                lblCUserID.Text = "用户ID：" + user.ID;
                lblCName.Text = "用户昵称：" + user.ScreenName;
                if (user.Gender == "m")
                    lblCGender.Text = "性别：男";
                else
                    lblCGender.Text = "性别：女";
                if (user.Verified)
                    lblCVerified.Text = "是否认证用户：是";
                else
                    lblCVerified.Text = "是否微博认证用户：否";
                if (user.Following)
                    lblCFollowing.Text = "当前登录帐号是否关注他（她）：是";
                else
                    lblCFollowing.Text = "当前登录帐号是否关注他（她）：否";
                lblCLocation.Text = "所在地：" + user.Location;
                lblCFollowersCount.Text = "粉丝人数：" + user.FollowersCount.ToString();
                lblCFriendsCount.Text = "关注人数：" + user.FriendsCount.ToString();
                lblCStatusesCount.Text = "已发微博数：" + user.StatusesCount.ToString();
                string strCreatedAt = user.CreatedAt;
                string[] strCreatedDate = strCreatedAt.Split(' ');
                int creatMonth = MonthConvert(strCreatedDate[1]);
                lblCCreatedAt.Text = "帐号创建时间：" + strCreatedDate[5] + "年" + creatMonth.ToString() + "月" + strCreatedDate[2] + "日";
            }
            else
            {
                lblCUserID.Text = "用户ID：";
                lblCName.Text = "用户昵称：";
                lblCGender.Text = "性别：";
                lblCVerified.Text = "是否微博认证用户：";
                lblCFollowing.Text = "当前登录帐号是否关注他（她）：";
                lblCLocation.Text = "所在地：";
                lblCFollowersCount.Text = "粉丝人数：";
                lblCFriendsCount.Text = "关注人数：";
                lblCStatusesCount.Text = "已发微博数：";
                lblCCreatedAt.Text = "";
            }
        }

        //将英文月份转为数字
        private int MonthConvert(string monthStr)
        {
            int monthInt=0;
            switch (monthStr)
            {
                case "Jan":
                    monthInt=1;
                    break;
                case "Feb":
                    monthInt = 2;
                    break;
                case "Mar":
                    monthInt = 3;
                    break;
                case "Apr":
                    monthInt = 4;
                    break;
                case "May":
                    monthInt = 5;
                    break;
                case "Jun":
                    monthInt = 6;
                    break;
                case "Jul":
                    monthInt = 7;
                    break;
                case "Aug":
                    monthInt = 8;
                    break;
                case "Sept":
                    monthInt = 9;
                    break;
                case "Oct":
                    monthInt=10;
                    break;
                case "Nov":
                    monthInt = 11;
                    break;
                case "Dec":
                    monthInt = 12;
                    break;
                default:
                    break;

            }
            return monthInt;
        }

        private void btnGetPublicTimeLine_Click(object sender, EventArgs e)
        {
            if (blnAuthorized == false)
            {
                CheckLogin();
            }
            else
            {
                txtDBName.Enabled = false;
                if (txtDBName.Text != "")
                {
                    WebYQCrawling.Properties.Settings.Default.db_database = txtDBName.Text;
                }
                db = new SqlDatabase();
                if (db == null)
                {
                    MessageBox.Show("数据库错误,请正确设置数据库。", "爬虫");
                    return;
                }

                //设置按钮使能状态
                this.btnGetPublicTimeLine.Enabled = false;
                this.btnPauseContinue.Enabled = true;

                Thread GetHotTopicThread = new Thread(new ThreadStart(GetPublicTimeLine_Work));
                GetHotTopicThread.IsBackground = true;
                GetHotTopicThread.Start();
            }
        }

        //启动时间线数据采集功能
        void GetPublicTimeLine_Work()
        {
            lblPublicTimeLineMessage.Text = "开始爬行……";
            try
            {
                var sina = new Client(oauth);
                while (true)
                {
                    Thread.Sleep(30000);
                    sina.AsyncInvoke<NetDimension.Weibo.Entities.status.Collection>(() =>
                    {
                        //获取微博，接口调用，返回值是个NetDimension.Weibo.Entities.status.Collection，所以泛型T为NetDimension.Weibo.Entities.status.Collection
                        Log("发送请求来获得公共微博列表...");
                        //gold ??? 未能解析此远程名称 api.weibo.com
                        var result = sina.API.Entity.Statuses.PublicTimeline();    //gold ??? 如果网络断开就会报告异常 需加上异常处理以防止直接崩溃
                        return result;
                    },
                    (callback) =>
                    {
                        if (callback.IsSuccess)
                        {
                            //异步完成后处理结果，result就是返回的结果，类型就是泛型所指定的NetDimension.Weibo.Entities.status.Collection
                            SaveToDB(callback.Data);
                        }
                        else if (callback.Error.Message == "token过期")
                        {
                            System.Diagnostics.Debug.WriteLine("获取公共时间线数据失败，异常:{0}", callback.Error);
                            blnAuthorized = false;
                            //CheckLogin();
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("获取公共时间线数据失败，异常:{0}", callback.Error);
                            Log("获取公共时间线数据失败，异常");
                        }
                    });
                }
            }catch(Exception e){
                System.Diagnostics.Debug.WriteLine(">>>> " + e.ToString());
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void btnPauseContinue_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGetTopicStatuses_Click(object sender, EventArgs e)
        {

        }


        //gold
        #region 主界面展现爬取到的网站信息
        /// <summary>
        /// 在主界面ListView中动态展现当前抓到的网站的WEBSITE信息
        /// </summary>
        /// <param name="siteRecord"></param>
        int count = 1;    //每次采集微博用户的数量
        public void DisplayWebInfomation(MicroBlogUser oneUser)
        {
            //Thread.Sleep(500);  //暂停0.5秒
            ListViewItem item = this.lsMicroBlogUser.Items.Add((count++) + "");
            item.SubItems.AddRange(new string[] { oneUser.MicroBlogUserID,oneUser.microBlogUserName, oneUser.microBlogUserSex,oneUser.microBlogUserScreenName, oneUser.microBlogLocation, oneUser.microBlogUserDescription, 
                oneUser.MicroBlogMsgCount,oneUser.microBlogUserFriendsCount,oneUser.microBlogUserFollowerCount,oneUser.microBlogUserCreateTime });

            this.lsMicroBlogUser.HideSelection = false;//失去焦点时显示选择的项
            this.lsMicroBlogUser.HoverSelection = true;//当鼠标停留数秒时自动选择项
            this.lsMicroBlogUser.MultiSelect = false;//设置只能单选

            this.lsMicroBlogUser.Focus();
            this.lsMicroBlogUser.Items[(lsMicroBlogUser.Items.Count) - 1].Focused = true;       //取得焦点 
            this.lsMicroBlogUser.Items[(lsMicroBlogUser.Items.Count) - 1].Selected = true;      //选中该行 

            this.lsMicroBlogUser.Items[(lsMicroBlogUser.Items.Count) - 1].EnsureVisible();   //滚到该行

            this.lsMicroBlogUser.Update();
        }

        #endregion

        //存储时间线数据到数据库，并在主界面上展现
        private void SaveToDB(NetDimension.Weibo.Entities.status.Collection statuses)
        {
            Log("爬到" + statuses.Statuses.Count().ToString() + "条微博");
            //
            MicroBlogUser oneUser = new MicroBlogUser();
            //
            foreach (var status in statuses.Statuses)
            {
                try
                {
                    if (!userDic.ContainsKey(status.User.ID))
                    {
                        userDic.Add(status.User.ID, 0);

                        Hashtable htValues = new Hashtable();
                        string _update_time = "'" + DateTime.Now.ToString("u").Replace("Z", "") + "'";
                        htValues.Add("user_id", Convert.ToInt64(status.User.ID));
                        if (status.User.ScreenName != null)
                        {
                            htValues.Add("screen_name", "'" + status.User.ScreenName.Replace("'", "''") + "'");//将"'"改为"''"，在插入数据库时不会受到影响
                        }
                        if (status.User.Name != null)
                        {
                            htValues.Add("name", "'" + status.User.Name.Replace("'", "''") + "'");
                        }
                        htValues.Add("province", "'" + status.User.Province + "'");
                        htValues.Add("city", "'" + status.User.City + "'");
                        if (status.User.Location != null)
                        {
                            htValues.Add("location", "'" + status.User.Location.Replace("'", "''") + "'");
                        }
                        if (status.User.Description != null)
                        {
                            htValues.Add("description", "'" + status.User.Description.Replace("'", "''") + "'");
                        }
                        if (status.User.Url != null)
                        {
                            htValues.Add("url", "'" + status.User.Url.Replace("'", "''") + "'");
                        }
                        if (status.User.ProfileImageUrl != null)
                        {
                            htValues.Add("profile_image_url", "'" + status.User.ProfileImageUrl.Replace("'", "''") + "'");
                        }
                        if (status.User.Domain != null)
                        {
                            htValues.Add("domain", "'" + status.User.Domain.Replace("'", "''") + "'");
                        }
                        htValues.Add("gender", "'" + status.User.Gender + "'");
                        htValues.Add("followers_count", status.User.FollowersCount);
                        htValues.Add("friends_count", status.User.FriendsCount);
                        htValues.Add("statuses_count", status.User.StatusesCount);
                        htValues.Add("favourites_count", status.User.FavouritesCount);
                        htValues.Add("created_at", "'" + status.User.CreatedAt + "'");
                        if (status.User.Lang != null)
                        {
                            htValues.Add("lang", "'" + status.User.Lang.Replace("'", "''") + "'");
                        }
                        if (status.User.Remark != null)
                        {
                            htValues.Add("remark", "'" + status.User.Remark.Replace("'", "''") + "'");
                        }
                        if (status.User.VerifiedReason != null)
                        {
                            htValues.Add("verifiedreason", "'" + status.User.VerifiedReason.Replace("'", "''") + "'");
                        }
                        if (status.User.VerifiedType != null)
                        {
                            htValues.Add("verifiedtype", "'" + status.User.VerifiedType.Replace("'", "''") + "'");
                        }
                        if (status.User.Weihao != null)
                        {
                            htValues.Add("weihao", "'" + status.User.Weihao.Replace("'", "''") + "'");
                        }
                        htValues.Add("bifollowerscount", status.User.BIFollowersCount);
                        if (status.User.AvatarLarge != null)
                        {
                            htValues.Add("avatarlarge", "'" + status.User.AvatarLarge.Replace("'", "''") + "'");
                        }
                        if (status.User.Following)
                            htValues.Add("following", 1);
                        else
                            htValues.Add("following", 0);
                        if (status.User.Verified)
                            htValues.Add("verified", 1);
                        else
                            htValues.Add("verified", 0);
                        if (status.User.AllowAllActMsg)
                            htValues.Add("allow_all_act_msg", 1);
                        else
                            htValues.Add("allow_all_act_msg", 0);
                        if (status.User.GEOEnabled)
                            htValues.Add("geo_enabled", 1);
                        else
                            htValues.Add("geo_enabled", 0);
                        if (status.User.AllowAllComment)
                            htValues.Add("allowallcomment", 1);
                        else
                            htValues.Add("allowallcomment", 0);
                        htValues.Add("iteration", 0);
                        htValues.Add("update_time", _update_time);

                        bool userInsert=  true;//db.Insert("users", htValues);
                        //展现到界面上并记录日志
                        if (userInsert)
                        {
                            Log("将用户" + status.User.ID + "：“" + status.User.Name + "” 存入数据库...");
                            //构建BlogUser对象
                            oneUser.MicroBlogUserID = status.User.ID;
                            oneUser.MicroBlogUserName = status.User.Name;
                            oneUser.microBlogUserScreenName = status.User.ScreenName;
                            oneUser.microBlogLocation = status.User.Location;
                            oneUser.microBlogUserDescription = status.User.Description;
                            oneUser.microBlogUserCreateTime = status.User.CreatedAt;
                            oneUser.microBlogUserFollowerCount = status.User.FollowersCount.ToString();
                            oneUser.microBlogUserFriendsCount = status.User.FriendsCount.ToString();
                            oneUser.microBlogMsgCount = status.User.FavouritesCount.ToString();
                            if(status.User.Gender=="m") oneUser.microBlogUserSex = "男";
                            else if (status.User.Gender == "f") oneUser.microBlogUserSex = "女";
                            else oneUser.microBlogUserSex = "未知";
                            //基于ListView动态展现数据
                            DisplayWebInfomation(oneUser);
                        }
                    }
                    else
                    {
                        userDic[status.User.ID]++;//该用户的出现次数加1
                    }
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    return; 
                }
                try 
                {
                    if (!statusDic.ContainsKey(status.ID))
                    {
                        statusDic.Add(status.ID, 0);

                        Hashtable htValues = new Hashtable();
                        string _update_time = "'" + DateTime.Now.ToString("u").Replace("Z", "") + "'";
                        htValues.Add("status_id", Convert.ToInt64(status.ID));
                        if (status.CreatedAt != null)
                        {
                            htValues.Add("created_at", "'" + status.CreatedAt.Replace("'", "''") + "'");
                        }
                        if (status.Text != null)
                        {
                            htValues.Add("content", "'" + status.Text.Replace("'", "''") + "'");
                        }
                        if (status.Source != null)
                        {
                            htValues.Add("source_url", "'" + status.Source.Replace("'", "''") + "'");
                        }
                        //htValues.Add("source_name", "'" + _source_name + "'");
                        if (status.Favorited)
                            htValues.Add("favorited", 1);
                        else
                            htValues.Add("favorited", 0);
                        if (status.Truncated)
                            htValues.Add("truncated", 1);
                        else
                            htValues.Add("truncated", 0);
                        //htValues.Add("geo", "'" + _geo.Replace("'", "''") + "'");
                        htValues.Add("in_reply_to_status_id", "'" + status.InReplyToStuatusID + "'");
                        htValues.Add("in_reply_to_user_id", "'" + status.InReplyToUserID + "'");
                        if (status.InReplyToScreenName != null)
                        {
                            htValues.Add("in_reply_to_screen_name", "'" + status.InReplyToScreenName.Replace("'", "''") + "'");
                        }
                        if (status.ThumbnailPictureUrl != null)
                        {
                            htValues.Add("thumbnail_pic", "'" + status.ThumbnailPictureUrl.Replace("'", "''") + "'");
                        }
                        if (status.MiddleSizePictureUrl != null)
                        {
                            htValues.Add("bmiddle_pic", "'" + status.MiddleSizePictureUrl.Replace("'", "''") + "'");
                        }
                        if (status.OriginalPictureUrl != null)
                        {
                            htValues.Add("original_pic", "'" + status.OriginalPictureUrl.Replace("'", "''") + "'");
                        }
                        htValues.Add("user_id", Convert.ToInt64(status.User.ID));
                        if (status.RetweetedStatus != null)
                            htValues.Add("retweeted_status_id", Convert.ToInt64(status.RetweetedStatus.ID));
                        else
                            htValues.Add("retweeted_status_id", 0);
                        //htValues.Add("iteration", 0);
                        htValues.Add("update_time", _update_time);
                        htValues.Add("commentscount", status.CommentsCount);
                        htValues.Add("reportscount", status.RepostsCount);
                        htValues.Add("mid", "'" + status.MID + "'");

                        bool statusInsert=db.Insert("statuses", htValues);
                        if (statusInsert)
                        {
                            Log("将微博" + status.ID + "存入数据库...");
                        }
                    }
                    else
                    {
                        statusDic[status.ID]++;//该用户的出现次数加1
                    }
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    return; 
                }
            }   
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="strLog">日志内容</param>
        protected void Log(string strLog)
        {
            //System.Diagnostics.Debug.WriteLine("日志》》 " + strLog);
            //string strLogMessage = DateTime.Now.ToString() + "  " + strLog;
            //StreamWriter swComment = File.AppendText(strLogFile);
            //swComment.WriteLine(strLogMessage);
            //swComment.Close();
            this.lblPublicTimeLineMessage.Text = strLog;
        }

        private void grpCurrentUser_Enter(object sender, EventArgs e)
        {
            r
        }

        private void lblDBName_Click(object sender, EventArgs e)
        {
            r
        }

    }
}
