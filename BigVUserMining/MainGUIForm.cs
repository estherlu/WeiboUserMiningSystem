using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Collections;
using DotNet.Framework.Common.Algorithm;
using System.Runtime.InteropServices; 
using WebYQCrawling.MicroBlog;
using System.Text.RegularExpressions;


//using WebYQCrawling.WebBlog;
//using WebYQCrawling.SinaBlog;


//  格式化代码段: VS.NET 2010是Ctrl+E然后按Ctrl+D
namespace WebYQCrawling
{
    public partial class MainGUIForm : Form
    {
        #region 成员变量与构造函数

        // Performance Counter to measure CPU usage
        private System.Diagnostics.PerformanceCounter cpuCounter;
        // Performance Counter to measure memory usage
        private System.Diagnostics.PerformanceCounter ramCounter;
        
        public MainGUIForm()
        {
            InitializeComponent();

            //状态栏相关信息
            ConnectionInfo();
            this.cpuCounter = new System.Diagnostics.PerformanceCounter();
            this.ramCounter = new System.Diagnostics.PerformanceCounter("Memory", "Available MBytes");
            this.cpuCounter.CategoryName = "Processor";
            this.cpuCounter.CounterName = "% Processor Time";
            this.cpuCounter.InstanceName = "_Total"; 

            //加载系统界面
            LoadGUI();
            //this.tabControlPanel.Region = new Region(new RectangleF(this.tabPageNews.Left, this.tabPageNews.Top, this.tabPageNews.Width, this.tabPageNews.Height));
        }
        #endregion 成员变量与构造函数


        #region 工具栏导航控制
        //点击工具栏“新闻采集”按钮
        private void toolStripBtnNewsCrawling_Click(object sender, EventArgs e)
        {
            this.tabControlPanel.SelectedIndex = 0;
        }

        //标签页切换事件
        private void tabControlPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGUI();
        }

        //加载各标签页界面
        private void LoadGUI()
        {
            //1、如果是名人堂数据采集标签页
            if (tabControlPanel.SelectedIndex == 0)
            {
                //加载微博数据采集界面
                MicroBlogCrawlerForm microBlogForm = new MicroBlogCrawlerForm();
                microBlogForm.TopLevel = false;
                microBlogForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;//设置窗体为非边框样式
                microBlogForm.Dock = System.Windows.Forms.DockStyle.Fill;//设置样式是否填充整个panel
                this.tabPageMicroBlogPanel.Controls.Add(microBlogForm);
                microBlogForm.Show();

            }//2、如果是统计分析标签页
            else if (tabControlPanel.SelectedIndex == 1)
            {
                ////加载名人堂数据统计检索界面
                //WebBlogCrawlerForm webBlogForm = new WebBlogCrawlerForm();
                //webBlogForm.TopLevel = false;
                //webBlogForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;//设置窗体为非边框样式
                //webBlogForm.Dock = System.Windows.Forms.DockStyle.Fill;//设置样式是否填充整个panel
                //this.tabPageStat.Controls.Add(webBlogForm);
                //webBlogForm.Show();


                //Statistics staForm = new Statistics();
                //staForm.TopLevel = false;
                //staForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;//设置窗体为非边框样式
                //staForm.Dock = System.Windows.Forms.DockStyle.Fill;//设置样式是否填充整个panel
                //this.tabPageStat.Controls.Add(staForm);
                //staForm.Show();
            }
            //3、如果是社区发现标签页
            else if (tabControlPanel.SelectedIndex == 2)
            {
                //加载名人社区发现界面
                //SinaBlogCrawlerMainForm sinaCnBlogForm = new SinaBlogCrawlerMainForm();
                //sinaCnBlogForm.TopLevel = false;
                //sinaCnBlogForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;//设置窗体为非边框样式
                //sinaCnBlogForm.Dock = System.Windows.Forms.DockStyle.Fill;//设置样式是否填充整个panel
                //this.tabPageSinaTBlogPanel.Controls.Add(sinaCnBlogForm);
                //sinaCnBlogForm.Show();
                CommunityDetectionForm ComDecForm = new CommunityDetectionForm();
                ComDecForm.TopLevel = false;
                ComDecForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;//设置窗体为非边框样式
                ComDecForm.Dock = System.Windows.Forms.DockStyle.Fill;//设置样式是否填充整个panel
                this.tabPageSinaTBlogPanel.Controls.Add(ComDecForm);
                ComDecForm.Show();
            }
        }

        //Main主窗体关闭事件
        private void MainGUIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
             //一一关闭掉各个TabPage中Panel上嵌入的子窗体

            //关闭掉所有线程和主线程
            Application.ExitThread();
            Application.Exit();
        }

        #endregion 工具栏导航控制           


        #region 状态栏状态信息显示

        // number of bytes downloaded
        private int nByteCount;
        private int ByteCount
        {
            get { return nByteCount; }
            set
            {
                nByteCount = value;
                this.statusBarPanelByteCount.Text = Commas(nByteCount / 1024 + 1) + " KB";
            }
        }

        // number of errors during the download process
        private int nErrorCount;
        private int ErrorCount
        {
            get { return nErrorCount; }
            set
            {
                nErrorCount = value;
                this.statusBarPanelErrors.Text = "错误：" + Commas(nErrorCount) + " 个";
            }
        }

        // number of Uri's found
        private int nURLCount;
        private int URLCount
        {
            get { return nURLCount; }
            set
            {
                nURLCount = value;
                this.statusBarPanelURLs.Text = "发现URL " + Commas(nURLCount) + " 个";
            }
        }

        string Commas(int nNum)
        {
            string str = nNum.ToString();
            int nIndex = str.Length;
            while (nIndex > 3)
            {
                str = str.Insert(nIndex - 3, ",");
                nIndex -= 3;
            }
            return str;
        }

        //可用内存 available memory
        private float nFreeMemory;
        private float FreeMemory
        {
            get { return nFreeMemory; }
            set
            {
                nFreeMemory = value;
                this.statusBarPanelMem.Text = nFreeMemory + " Mb Available";
            }
        }

        //CPU利用率 CPU usage
        private int nCPUUsage;
        private int CPUUsage
        {
            get { return nCPUUsage; }
            set
            {
                try
                {
                    //gold 临时删除,经常在爬行几个小时候获取不到CPU使用率的图片？？？
                    nCPUUsage = value;
                    this.statusBarPanelCPU.Text = "CPU Usage " + nCPUUsage + "%";
                    System.Diagnostics.Debug.WriteLine("nCPUUsage = " + nCPUUsage + "   value / 10 = " + (value / 10));

                    Icon icon = Icon.FromHandle(((Bitmap)imageListPercentage.Images[value / 10]).GetHicon());
                    this.statusBarPanelCPU.Icon = icon;
                } catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            }
        }

        //定时获取可利用的内存信息
        private void timerMem_Tick(object sender, EventArgs e)
        {
            FreeMemory = ramCounter.NextValue();
            CPUUsage = (int)cpuCounter.NextValue();
        }

        //定时监测网络连通状态
        private void timerConnectionInfo_Tick(object sender, EventArgs e)
        {
            ConnectionInfo();
        }

        //获取网络连通状态信息
        void ConnectionInfo()
        {
            try
            {
                int nState = 0;
                if (InternetGetConnectedState(ref nState, 0) == 0)
                {
                    if (nFirstTimeCheckConnection++ == 0)
                        // ask for dial up or DSL connection
                        if (InternetAutodial(1, 0) != 0)
                            // check internet connection state again
                            InternetGetConnectedState(ref nState, 0);
                }
                if ((nState & 2) == 2 || (nState & 4) == 4)
                    // reset to reask for connection agina
                    nFirstTimeCheckConnection = 0;
            } catch
            {
            }
            this.statusBarPanelInfo.Text = InternetGetConnectedStateString();
        }

        [DllImport("wininet")]
        public static extern int InternetGetConnectedState(ref int lpdwFlags, int dwReserved);
        [DllImport("wininet")]
        public static extern int InternetAutodial(int dwFlags, int hwndParent);
        int nFirstTimeCheckConnection = 0;
        string InternetGetConnectedStateString()
        {
            string strState = "";
            try
            {
                int nState = 0;
                // check internet connection state
                if (InternetGetConnectedState(ref nState, 0) == 0)
                    return "本机未连接到Internet";
                if ((nState & 1) == 1)
                    strState = "调制解调器连接";
                else if ((nState & 2) == 2)
                    strState = " 通过局域网连接互联网";
                else if ((nState & 4) == 4)
                    strState = " 通过代理连接";
                else if ((nState & 8) == 8)
                    strState = " Modem is busy with a non-Internet connection";
                else if ((nState & 0x10) == 0x10)
                    strState = " Remote Access Server is installed";
                else if ((nState & 0x20) == 0x20)
                    return " Offline-本机离线，检查网络设置。";
                else if ((nState & 0x40) == 0x40)
                    return " Internet connection is currently configured";

                // get current machine IP
                //IPHostEntry he = Dns.Resolve(Dns.GetHostName());
                //strState += ",  本机 IP地址: " + he.AddressList[0].ToString() + "。";
            } catch
            {
            }
            return strState;
        }

        #endregion  状态栏状态信息显示


        #region TW新浪微博数据采集
        /********************************************************************************************************************/
     

        /********************************************************************************************************************/
        #endregion TW新浪微博数据采集


        #region Web新闻数据采集
        /********************************************************************************************************************/

        /********************************************************************************************************************/
        #endregion Web新闻数据采集


    }
}
