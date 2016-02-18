using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using NetDimension.Weibo;
using System.Threading;
using System.Diagnostics;

namespace WebYQCrawling.MicroBlog
{
    public partial class LoginForm : Form
    {
        //private SinaApiService _api;
        private OAuth oauth;

        public LoginForm(OAuth oauth)
        {
            InitializeComponent();
            this.oauth = oauth;
        }

        //微博账户登录
        private void btnLogin_Click(object sender, EventArgs e)
        {
            txtUserID.Enabled = false;
            txtPWD.Enabled = false;
            btnLogin.Text = "登录中...";
            btnLogin.Enabled = false;
            btnCancel.Enabled = false;
            string strUserID = txtUserID.Text;
            string strPWD = txtPWD.Text;
            //oauth.ClientLogin(strUserID, strPWD);

            var authUrl = oauth.GetAuthorizeURL();
            webBrowser1.Navigate(authUrl);  //webBrowser1.Navigate("https://www.facebook.com");
            //gold 能否自动设置应用登录的用户名、密码并登录
            //webBrowser1.FindForm().

            //if (oauth.VerifierAccessToken() != TokenResult.Success)
            //{
            //    MessageBox.Show("授权失败。请重试。", "微博爬虫");
            //    txtUserID.Enabled = true;
            //    txtPWD.Enabled = true;
            //    btnLogin.Enabled = true;
            //    btnCancel.Enabled = true;
            //    btnLogin.Text = "登录";
            //    return;
            //}
            //else
            //    this.DialogResult = DialogResult.OK;
        }

        //TODO:
        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        //用用授权后点击（在登录Dialog确认后）
        private void button1_Click(object sender, EventArgs e)
        {
            string code = webBrowser1.Url.ToString();
            int index = code.IndexOf("=");
            code = code.Substring(index+1);
            var accessToken = oauth.GetAccessTokenByAuthorizationCode(code);
            if (oauth.VerifierAccessToken() != TokenResult.Success)
            {
                MessageBox.Show("授权失败。请重试。", "微博爬虫");
                txtUserID.Enabled = true;
                txtPWD.Enabled = true;
                btnLogin.Enabled = true;
                btnCancel.Enabled = true;
                btnLogin.Text = "登录";
                return;
            }
            else
                this.DialogResult = DialogResult.OK;
        }

        //第一次加载标识
        private bool firstLoad = true;
        //用户登录账户成功后自动提交表单登录应用
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                //测试Facebook自动登录
                //HtmlElement userID = webBrowser1.Document.All["email"];
                //if (userID != null)
                //    userID.SetAttribute("value", "wondergoldff@gmail.com");
                //HtmlElement passWord = webBrowser1.Document.All["pass"];
                //if (passWord != null)
                //    passWord.SetAttribute("value", "1314520ff");
                //HtmlElement formLogin = webBrowser1.Document.All["login_form"];
                //formLogin.InvokeMember("submit");    //   "submit"  "cancel" 

                //webBrowser1.Navigate("javascript: (function(){alert('hello, world');})();");
                if (firstLoad)
                {
                    firstLoad = false;
                    HtmlElement formLogin = webBrowser1.Document.All["AuthZForm"];  //HtmlElement formLogin = webBrowser1.Document.Forms["AuthZForm"];

                    HtmlElement userID = webBrowser1.Document.All["userId"];
                    if (userID != null)
                        userID.SetAttribute("value", "john51200@126.com");
                    HtmlElement passWord = webBrowser1.Document.All["passwd"];
                    if (passWord != null)
                        passWord.SetAttribute("value", "1987051200");

                    //HtmlElement btnLogin = webBrowser1.Document.All["submit"];
                    //btnLogin.InvokeMember("click");
                    
                    //formLogin.InvokeMember("submit");    //   "submit"  "cancel"    
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
