using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

//各单项功能类引用
using System.Net;
using System.IO;
using System.Text;
//using WebYQCrawling.WebBlog;

namespace WebYQCrawling
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //集成多Tab界面
            Application.Run(new MainGUIForm());  //新的统一集成框架程序


            //测试各单项功能界面
            //Application.Run(new WebNewsCrawlerForm());  //原来新浪微博时间线数据采集程序
            //Application.Run(new MicroBlogCrawlerForm());  //原来新浪微博时间线数据采集程序

            //Application.Run(new TestForm());  //
            
        }

        //Test
        private static void GetWebPic(string url2)
        {
            string url = "http://www.dotblogs.com.tw/CaptchaImage.ashx?spec=FK24gKoudcATljUbyX1ZLuv8srpCWveu0bI3akKGhCXywzmHfidSKWY1e2Pv4Xsn";

            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream reader = response.GetResponseStream();
                FileStream writer = new FileStream("E:\\pic.jpg", FileMode.OpenOrCreate, FileAccess.Write);
                byte[] buff = new byte[512];
                int c = 0; //实际读取的字节数 
                while ((c = reader.Read(buff, 0, buff.Length)) > 0)
                {
                    writer.Write(buff, 0, c);
                }
                writer.Close();
                writer.Dispose();
                reader.Close();
                reader.Dispose();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
