using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Threading;

namespace WebYQCrawling
{
    public partial class CommunityDetectionForm : Form
    {
        public CommunityDetectionForm()
        {
            InitializeComponent();
        }

        private void btnopenlist_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            tblist.Text = openFileDialog1.FileName;
        }

        private void btnnetwork_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            tbnetwork.Text = openFileDialog2.FileName;
        }

        private void btnpronetwork_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> userdic = new Dictionary<string, int>();   //用户列表
            Dictionary<string, int> mydic = new Dictionary<string, int>();        
            ArrayList al = new ArrayList();                                   //用于存储结果

            FileStream ufs = File.Open(tblist.Text, FileMode.Open);           //
            StreamReader usr = new StreamReader(ufs);
           
            //从文件中读入用户列表
            string oneline;
            while ((oneline = usr.ReadLine()) != null)
            {
                if (!userdic.ContainsKey(oneline))
                {
                    userdic.Add(oneline, 1);
                }
            }
            usr.Close();
            ufs.Close();

            //读入完整网络文件
            FileStream nfs = File.Open(tbnetwork.Text, FileMode.Open);
            StreamReader nsr = new StreamReader(nfs);

            string line;
            while ((line = nsr.ReadLine()) != null)
            {
                if (line == "")
                {
                    continue;
                }
                if (!line.StartsWith("#")) 
                {
                    string[] part = line.Split(',');
                    string test = part[0];
                    if (userdic.ContainsKey(part[0]) && userdic.ContainsKey(part[1]))        //该边的两个节点都处于用户列表中
                    {
                        string reonline = part[1] + "," + part[0];                          //边反置
                        if (!mydic.ContainsKey(line))
                        {
                            mydic.Add(line, 1);
                            //sw2.WriteLine(oneline);
                            if (mydic.ContainsKey(reonline))
                            {
                                al.Add(line);
                            }
                        }
                    }
                } 
            }

            FileStream fs1 = File.Open(tbresult.Text, FileMode.OpenOrCreate);
            StreamWriter wr = new StreamWriter(fs1);
            for (int i = 0; i < al.Count; i++)
            {
                wr.WriteLine(al[i].ToString());
            }
            wr.Close();
            fs1.Close();
            MessageBox.Show(al.Count.ToString());
        }

        private void btnprocom_Click(object sender, EventArgs e)
        {
            Process.Start("MySNAP.exe",tbresult.Text+" "+tbcom.Text);
            Thread.Sleep(2000);
            Process[] processes = Process.GetProcesses();

            while (true)
            {
                bool a = false;
                foreach (Process process in processes)
                {
                    if (process.ProcessName == "MySNAP.exe")
                    {
                        a = true;
                    }
                    else
                    {
                        continue;
                        //没找到
                    }
                }
                if (a == false)
                    break;
                else
                    continue;
            }
            Process.Start("notepad.exe", tbcom.Text);
       

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
