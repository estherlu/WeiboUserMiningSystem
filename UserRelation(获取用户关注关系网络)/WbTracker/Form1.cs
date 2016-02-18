using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using System.Globalization;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;




namespace WbTracker
{
    public partial class Form1 : Form
    {
        //DatabaseConnect mydb = new DatabaseConnect();
        ArrayList idlist = new ArrayList();    //存放待跟踪微博的id
        ArrayList uidlist = new ArrayList();   //存放待跟踪用户的id
        
        AccessToken atoken=new AccessToken();
        string currentuser="";
        string currentpassword = "";
        string currentapp = "";
        string currentas = "";
        string strfeixinCookie = "";

        //WebProxy myProxy = new WebProxy("127.0.0.1", 8087);

        // ///////////////////////
        Dictionary<string, string> userdic = new Dictionary<string, string>();
        Dictionary<string, int> staruserdic = new Dictionary<string, int>();
        ArrayList ridlist = new ArrayList();
        /// <summary>
        /// //////////////////////////////////
        /// </summary>

        System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
        Thread thpro;                
        
        public Form1()
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        public string ParseDateTime(string strDateTime)
        {
            string[] s = strDateTime.Split(' ');
            string strBuffer = s[5] + "-";
            switch (s[1])
            {
                case "Jan": //一月
                    strBuffer += "01-";
                    break;
                case "Feb": //二月
                    strBuffer += "02-";
                    break;
                case "Mar": //三月
                    strBuffer += "03-";
                    break;
                case "Apr": //四月
                    strBuffer += "04-";
                    break;
                case "May": //五月
                    strBuffer += "05-";
                    break;
                case "Jun": //六月
                    strBuffer += "06-";
                    break;
                case "Jul": //七月
                    strBuffer += "07-";
                    break;
                case "Aug": //八月
                    strBuffer += "08-";
                    break;
                case "Sep": //九月
                    strBuffer += "09-";
                    break;
                case "Oct": //十月
                    strBuffer += "10-";
                    break;
                case "Nov": //十一月
                    strBuffer += "11-";
                    break;
                case "Dec": //十二月
                    strBuffer += "12-";
                    break;
                default:
                    return "0001-01-01 00:00:00";
            }
            strBuffer += s[2] + " " + s[3];
            return strBuffer;
        }


        //获得种子节点
        private ArrayList GetSeeds()
        {
            ArrayList seeds=new ArrayList();
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\SINAWEIBO\WbTracker\WbTracker\bin\Debug\HotCmtRt.mdb");
            conn.Open();
            string sql = "select mid from hot_rt_weibo where retweet_count>1000";
            OleDbCommand command = new OleDbCommand(sql, conn);
            OleDbDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //Console.Write("{0} ", reader[i]);
                        seeds.Add(reader[i]);
                    }
                    //Console.WriteLine();
                }
            }
            finally
            {
                reader.Close();
                conn.Close();
                
            }
            return seeds;
        }

                       
        //获得指定微博id的转发数目 API v2.0
        private int Getretewwtnum(string idstr)
        {
            int num=0;
            try
            {

                string url = "https://api.weibo.com/2/statuses/count.json?access_token=" + atoken.access_token + "&ids=" + idstr;
                //string url = "http://api.t.sina.com.cn/statuses/counts.xml?" + tbak.Text + "&ids=" + idstr;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E)";
                //request.Headers.Set("Cookie", tbcookie.Text);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();

                StreamReader mysr = new StreamReader(receiveStream);
                string ss = mysr.ReadToEnd();
                mysr.Close();
                receiveStream.Close();

                JArray ja = (JArray)JsonConvert.DeserializeObject(ss);                
                JObject j1 = (JObject)ja[0];
                num = Convert.ToInt32(j1.SelectToken("reposts").ToString());
            }
            catch (System.Net.WebException webEx)
            {
                if (webEx.Response != null)
                {
                    using (StreamReader reader = new StreamReader(webEx.Response.GetResponseStream()))
                    {
                        string errorInfo = reader.ReadToEnd();
                        reader.Close();
                    }
                }
            }
            return num;
        }


        //获取单个信息，其中包含其用户信息 API V2.0
        private string GetoneStatuses(string idstr)
        {
            string getmessage = "";
            string url = "https://api.weibo.com/2/statuses/show.json?access_token=" + atoken.access_token + "&id=" + idstr;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.KeepAlive = true;
            request.ContentType = "multipart/form-data";
            //request.Connection = "Keep-Alive";
            request.Credentials = System.Net.CredentialCache.DefaultCredentials;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E)";
            //request.Headers.Set("Cookie", tbcookie.Text);

            try
            {
              
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                
                Stream receiveStream = response.GetResponseStream();

                StreamReader mysr = new StreamReader(receiveStream);
                string ss = mysr.ReadToEnd();
                mysr.Close();
                receiveStream.Close();
                getmessage = ss;
                return getmessage;
            }
            catch (Exception e1)
            {
                //MessageBox.Show(e1.Message);
                //e1.Message
                if (e1.Message == "远程服务器返回错误: (400) 错误的请求。")
                {
                    return "远程服务器返回错误: (400) 错误的请求。";
                }
                else
                    return "";    
            }           
        }





        private JObject GetJson(JObject jo, string path)
        {
            JObject jor =(JObject)JsonConvert.DeserializeObject(jo.SelectToken(path).ToString());
            return jor;
        }
        
        private string GetJsontext(JObject jo, string path)
        {
            string backstr = "";
            try
            {
                string[] strs = path.Split('/');

                if (strs.Length == 1)
                {
                    backstr = jo.SelectToken(path, false).ToString();
                }
                else
                {
                    JObject jor=jo;
                    for (int i = 0; i < strs.Length-1; i++)
                    {
                        jor = GetJson(jor, strs[i]); 
                    }
                    backstr = jor.SelectToken(strs[strs.Length - 1], false).ToString();
                }
                if (backstr.StartsWith("\"") && backstr.EndsWith("\""))
                {
                    backstr=backstr.Remove(0, 1);
                    backstr = backstr.Remove(backstr.Length - 1);
                }

                backstr = DatabaseConnect.ReplaceDYH(backstr);
                backstr=backstr.Replace("\\\"","\"");
                return backstr;
            }
            catch (Exception e5)
            {
                return "";
            }
        }

 
 
        
        //使用 LoginUser中的第一行首选初始化
        private void btnauth_Click(object sender, EventArgs e)
        {
            FileStream outfile = File.Open("LoginUser.txt", FileMode.Open);
            StreamReader sr = new StreamReader(outfile);
            string oneline = sr.ReadLine();
            sr.Close();
            outfile.Close();
            currentuser = oneline.Split(' ')[0];
            currentpassword = oneline.Split(' ')[1];


            outfile = File.Open("AppID.txt", FileMode.Open);
            sr = new StreamReader(outfile);
            string appline = sr.ReadLine();
            sr.Close();
            outfile.Close();
            currentapp = appline.Split(' ')[0];
            currentas = appline.Split(' ')[1];

            atoken = GetAcess_Token(currentapp, currentas, tbreduri.Text, currentuser, currentpassword);
            MessageBox.Show("获取成功！"+atoken.access_token);
        }

        //用户名和密码的自动循环
        private void refreshToken()
        {
            ArrayList userlist = new ArrayList();
            FileStream outfile = File.Open("LoginUser.txt", FileMode.Open);
            StreamReader sr = new StreamReader(outfile);

            string oneline = sr.ReadLine();
            string line1 = oneline;
            while (oneline != null && (oneline.Split(' ').Length == 2))
            {
                if (oneline.Split(' ')[0] == currentuser)
                {
                    oneline = sr.ReadLine();
                    if (oneline == null || oneline == "")
                    {
                        oneline = line1;
                        currentuser = oneline.Split(' ')[0];
                        currentpassword = oneline.Split(' ')[1];
                        break;
                    }
                    else
                    {
                        currentuser = oneline.Split(' ')[0];
                        currentpassword = oneline.Split(' ')[1];
                        break;
                    }
                }
                else
                {
                    oneline = sr.ReadLine();
                }
            }
            sr.Close();
            outfile.Close();
            atoken = GetAcess_Token(currentapp, currentas, tbreduri.Text, currentuser, currentpassword);
        }

        //APPID自动循环
        private void refreshAppID()
        {
            ArrayList userlist = new ArrayList();
            FileStream outfile = File.Open("AppID.txt", FileMode.Open);
            StreamReader sr = new StreamReader(outfile);

            string oneline = sr.ReadLine();
            string line1 = oneline;
            while (oneline != null && (oneline.Split(' ').Length == 2))
            {
                if (oneline.Split(' ')[0] == currentapp)
                {
                    oneline = sr.ReadLine();
                    if (oneline == null || oneline == "")
                    {
                        oneline = line1;
                        currentapp = oneline.Split(' ')[0];
                        currentas = oneline.Split(' ')[1];
                        break;
                    }
                    else
                    {
                        currentapp = oneline.Split(' ')[0];
                        currentas = oneline.Split(' ')[1];
                        break;
                    }
                }
                else
                {
                    oneline = sr.ReadLine();
                }
            }
            sr.Close();
            outfile.Close();
            atoken = GetAcess_Token(currentapp, currentas, tbreduri.Text, currentuser, currentpassword);
        }



        /// <summary>
        /// 通过模拟WAP2.0页面获得授权，首先获取code后获取acess_token
        /// </summary>
        /// <param name="appkey">应用AppKey</param>
        /// <param name="appsecret">应用AppSecret</param>
        /// <param name="reuri">应用回调地址</param>
        /// <param name="username">用户名</param>
        /// <param name="password">用户密码</param>
        /// <returns>获得的access_token类</returns>
        private  AccessToken GetAcess_Token(string appkey,string appsecret,string reuri,string username,string password)
        {
            AccessToken thistoken = atoken;       
            //首先获取code
            //post数据
            string postdata = "action=submit&client_id=" + appkey + "&display=wap2.0&passwd=" + password + "&redirect_uri=" + reuri + "&response_type=code&userId=" + username;
            ASCIIEncoding encodeing = new ASCIIEncoding();
            byte[] data = encodeing.GetBytes(postdata);

            try
            {

                //请求
                string url = "https://api.weibo.com/oauth2/authorize";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ProtocolVersion = HttpVersion.Version10;
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E)";
                request.AllowAutoRedirect = true;
                request.Referer = "https://api.weibo.com/oauth2/authorize?client_id=" + appkey + "&redirect_uri=" + reuri + "&display=wap2.0";
                request.KeepAlive = true;

                Stream newStream = request.GetRequestStream();
                // Send the data.
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse();
                //code在等号以后
                string code = "";
                if (myResponse.ResponseUri.ToString().Split('=').Length == 2)
                {
                    code = myResponse.ResponseUri.ToString().Split('=')[1];
                }


                myResponse.Close();
                
                
                //获取Access_Token
                //post数据
                string tokenpostdata = "client_id="+appkey+"&client_secret="+appsecret+"&grant_type=authorization_code&code="+code+"&redirect_uri="+reuri;
                string turl = "https://api.weibo.com/oauth2/access_token";
                HttpWebRequest trequest = (HttpWebRequest)WebRequest.Create(turl);
                trequest.Method = "POST";
                trequest.ServicePoint.Expect100Continue = false;
                trequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E)";
                trequest.ContentType = "application/x-www-form-urlencoded";           

                StreamWriter swrequest = new StreamWriter(trequest.GetRequestStream());
                swrequest.Write(tokenpostdata);
                swrequest.Close();
           
                HttpWebResponse tresponse = (HttpWebResponse)trequest.GetResponse();
                Stream treceiveStream = tresponse.GetResponseStream();
                StreamReader mysr = new StreamReader(treceiveStream);
                string ss = mysr.ReadToEnd();
                mysr.Close();
                treceiveStream.Close();

                JObject jo = (JObject)JsonConvert.DeserializeObject(ss);
                thistoken.access_token = GetJsontext(jo, "access_token");
                thistoken.expires_in = GetJsontext(jo, "expires_in");
                thistoken.uid = GetJsontext(jo, "uid");
            }
            catch (System.Net.WebException webEx)
            {
                if (webEx.Response != null)
                {
                    using (StreamReader reader = new StreamReader(webEx.Response.GetResponseStream()))
                    {
                        string errorInfo = reader.ReadToEnd();
                        reader.Close();
                        Sendfeixingsms(errorInfo);
                    }
                }
            }
            return thistoken;
        }

        private void btnuserstatus_Click(object sender, EventArgs e)
        {
            thpro = new Thread(crawluserrelation);
            thpro.IsBackground = true;
            thpro.Start();
            tbcustate.Text += "获取线程开始执行!";                     
        }

        private void crawluserrelation()
        {
            ArrayList seeds = new ArrayList();            
            //从access获得用户列表以及起始和终止ID
            seeds = GetUser();
            if (seeds.Count == 0)
            {
                return;
            }
            InitialDic();
            if (staruserdic.Count == 0)
            {
                return;
            }
            lbusernum.Text=seeds.Count.ToString();
            // .Text += "\r\n待抓取的用户数为" + seeds.Count.ToString();
            for (int i = 0; i < seeds.Count; i++)
            {
                //循环抓取每一个用户
                string userid = seeds[i].ToString().Split(' ')[0];

                //lbnow.Text = "处理第" + i.ToString() + "个用户，信息ID：" + userid;

                if (true)
                {
                    tbcustate.Text = DateTime.Now.ToString() + "正在处理第" + (i + 1).ToString() + "个用户，用户ID：" + userid + "\r\n";
                    GetUserRelation(userid);
                }
                else
                {
                    tbcustate.Text = "该用户的信息已抓取完全！" + "\r\n" + tbcustate.Text;
                }
            }
            Sendfeixingsms(DateTime.Now.ToString()+"：任务执行完毕！");
            MessageBox.Show("\r\n" + DateTime.Now.ToString() + "任务执行完毕！");
        }

        //获取用户列表
        private ArrayList GetUser()
        {
            ArrayList backlist = new ArrayList();

            string filename=Application.StartupPath + "\\RelationDemo\\"+tbtaskfile.Text;
            if (!File.Exists(filename))
            {
                MessageBox.Show("处理任务文件不存在！");
                return backlist;
            }

            FileStream outfile = File.Open(filename, FileMode.Open);
            StreamReader sr = new StreamReader(outfile);

            string oneline = sr.ReadLine();
            while (oneline != null&&(oneline.Split(' ').Length==3))
            {
                backlist.Add(oneline);
                oneline = sr.ReadLine();
            }
            sr.Close();
            outfile.Close();
            return backlist; 
        }

        //初始化用户词典
        private void InitialDic()
        {
            string filename = Application.StartupPath + "\\RelationDemo\\" + tballfile.Text;
            if (!File.Exists(filename))
            {
                MessageBox.Show("封闭集合文件不存在！");
                return;
            }

            FileStream outfile = File.Open(filename, FileMode.Open);
            StreamReader sr = new StreamReader(outfile);

            string oneline = sr.ReadLine();
            while (oneline != null&&(oneline.Split(' ').Length==3))
            {
                staruserdic.Add(oneline.Split(' ')[0], 0);
                oneline = sr.ReadLine();
            }
            sr.Close();
            outfile.Close();
        }


        
        //获取并存储用户消息
        private void GetUserRelation(string userid)
        {
            //int num = 0;
            ArrayList uids=new ArrayList();
            ArrayList friends = new ArrayList();
            int pagenum = 1;
            string userrelation = "";
               
            while(true)
            {               
                //循环获取，直到不返回            
                lbcrawlstate.Text = DateTime.Now.ToString() + "正在处理第" + pagenum + "页，该用户已抓取信息" + friends.Count.ToString() + "条！";
                string url = "https://api.weibo.com/2/friendships/friends/ids.json?access_token=" + atoken.access_token + "&uid=" + userid + "&page=" + pagenum + "&count=5000";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                //RefreshProxy();
                //request.Proxy = myProxy;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E)";

                try
                { 
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream receiveStream = response.GetResponseStream();

                    StreamReader mysr = new StreamReader(receiveStream);
                    string ss = mysr.ReadToEnd();
                    mysr.Close();
                    receiveStream.Close();

                    JObject jo = (JObject)JsonConvert.DeserializeObject(ss);
                    JArray ja = (JArray)JsonConvert.DeserializeObject(jo["ids"].ToString());
                    int totalnumber = Convert.ToInt32(GetJsontext(jo,"total_number"));
                    if (ja.Count != 0)
                    {
                        for (int j = 0; j < ja.Count; j++)
                        {
                            //JObject jot = (JObject)JsonConvert.DeserializeObject(ja[j].ToString());
                            string buid = ja[j].ToString();
                            if (staruserdic.ContainsKey(buid))
                            {
                                //Console.WriteLine(userid+","+buid);
                                userrelation += userid + "," + buid + "\r\n";
                                friends.Add(buid);
                            }
                            uids.Add(buid);
                            //parsemessage(ja[j].ToString(), false);
                        }
                        if (uids.Count >= totalnumber - 2)
                        {
                            
                            break;
                        }
                    }
                    else
                        break;
                    pagenum++;                    
                }
                catch (System.Net.WebException webEx)
                {
                    if (webEx.Response != null)
                    {
                        using (StreamReader reader = new StreamReader(webEx.Response.GetResponseStream()))
                        {
                            string errorInfo = reader.ReadToEnd();
                            reader.Close();
                            if (errorInfo.Contains("User requests out of rate limit!"))
                            {
                                tbcustate.Text = DateTime.Now.ToString() + "用户请求超过限制次数，系统在10秒钟以后实将自动切换用户！\r\n" + tbcustate.Text;
                                Thread.Sleep(10 * 1000);
                                refreshToken();
                                continue;
                            }
                            else if (errorInfo.Contains("IP requests out of rate limit!"))
                            {
                                tbcustate.Text = DateTime.Now.ToString() + "IP请求超过限制次数，系统在20秒钟以后实将自动切换应用！\r\n" + tbcustate.Text;
                                Thread.Sleep(20 * 1000);
                                refreshAppID();
                                continue;
                            }
                            else
                            {
                                Sendfeixingsms(DateTime.Now.ToString() + errorInfo);
                                //MessageBox.Show(DateTime.Now.ToString() + errorInfo);
                            }
                        }
                    }
                }
            }
            Writerelation(userrelation);
            tbcustate.Text = DateTime.Now.ToString() + "用户" + userid + "，共获取信息" + friends.Count.ToString() + "条" + "\r\n" + tbcustate.Text;
            //mydb.addData(@"insert into overuser (user_id, hasmessage, isover) values ('" + userid + "','" + friends.Count.ToString() + "','true')");         
        }

        private void Writerelation(string relation)
        {
            //tbcustate.Text = relation;
            relation=relation.Trim();
            FileStream fs = new FileStream(Application.StartupPath + "\\Relation.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(relation);
            sw.Close();
            fs.Close(); 
        }

        //利用飞信发短信的模块
        private void btnsendmsg_Click(object sender, EventArgs e)
        {
            this.strfeixinCookie = CookieLoader.GetUriCookieContainer(@"https://webim.feixin.10086.cn/");
            MessageBox.Show("获取Cokie" + strfeixinCookie);
        }
        //当前设置是给我发短信
        private void Sendfeixingsms(string msg)
        {
            string ssid = tbssid.Text;
            string postdata = "Message=" + msg + "&Receivers=369842708&ssid="+ssid+"&UserName=369842708";
            UTF8Encoding encodeing = new UTF8Encoding();
            byte[] data = encodeing.GetBytes(postdata);

            //请求
            string url = "https://webim.feixin.10086.cn/content/WebIM/SendSMS.aspx?Version=8";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            //request.ProtocolVersion = HttpVersion.Version10;
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E)";
            //request.AllowAutoRedirect = true;
            request.Referer = "https://webim.feixin.10086.cn/content/freeSms.htm?tabIndex=0";
            request.KeepAlive = true;
            request.Headers.Set("Cookie", strfeixinCookie);
            request.Headers.Set("x-requested-with", "XMLHttpRequest");
            request.Accept = "application/json, text/javascript, */*";

            Stream newStream = request.GetRequestStream();
            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            try
            {
                HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse();
                myResponse.Close();
            }
            catch (Exception e2)
            { }
        }

        private void RefreshProxy()
        {
            //WebProxy myProxy = new WebProxy();
            //myProxy = new WebProxy("127.0.0.1", 8087);
            //myProxy.Credentials=new NetworkCredential("lqeqe","865262411");
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sendfeixingsms(DateTime.Now.ToString() + "测试，OK！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(Application.StartupPath + "\\Relation(20121030).txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (true)
            {
                Console.WriteLine(sr.ReadLine());
            }
        }

        private void tbcustate_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbssid_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
