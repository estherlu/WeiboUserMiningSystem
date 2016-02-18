using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Runtime.InteropServices;
using System.Collections.Specialized;

namespace WbTracker
{
    public class CookieLoader
    {
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref int pcchCookieData, int dwFlags, IntPtr lpReserved);
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int InternetSetCookieEx(string lpszURL, string lpszCookieName, string lpszCookieData, int dwFlags, IntPtr dwReserved);
        //const int INTERNET_COOKIE_THIRD_PARTY = 0x10;
        const int INTERNET_COOKIE_HTTPONLY = 0x00002000;

        // 基于系统函数获得Cookie（需IE8版本），参考 http://blog.csdn.net/cryeyes/archive/2010/12/19/6084781.aspx
        public static string GetUriCookieContainer(string uri)
        {
            //CookieContainer cookies = null;	// Determine the size of the cookie
            int datasize = 256;
            StringBuilder cookieData = new StringBuilder(256);
            if (!InternetGetCookieEx(uri, null, cookieData, ref datasize, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero))
            {
                if (datasize < 0)
                    return null;
                // Allocate stringbuilder large enough to hold the cookie	
                cookieData = new StringBuilder(datasize);
                if (!InternetGetCookieEx(uri, null, cookieData, ref datasize, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero))
                    return null;
            }
            //if (cookieData.Length > 0)
            //{
            //    cookies = new CookieContainer();
            //    cookies.SetCookies(new Uri(uri), cookieData.ToString().Replace(';', ','));
            //}
            return cookieData.ToString();
        }

        // 基于反射对请求头进行设置，参考 http://hi.baidu.com/iceser/blog/item/3006a559e02d3e272834f058.html
        public static void SetHeaderValue(WebHeaderCollection header, string name, string value)
        {
            System.Reflection.PropertyInfo property = typeof(WebHeaderCollection).GetProperty("InnerCollection",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (property != null)
            {
                NameValueCollection collection = property.GetValue(header, null) as NameValueCollection;
                collection[name] = value;
            }
        }
    }
}
