using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StatisticsApp
{
    public partial class Statistics : Form
    {
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.HotHallUsers_cjnConnectionString"].ToString();
        public Statistics()
        {
            InitializeComponent();
        }
        private DataSet  LoadDataSet(string strSel)
        {
            DataSet ds = new DataSet();
            SqlConnection mycon = new SqlConnection(strCon);
            try
            {
                mycon.Open();
                SqlDataAdapter da = new SqlDataAdapter(strSel, mycon);
                da.Fill(ds);
                mycon.Close();
                return ds;

            }
            catch (Exception ex)
            {
                mycon.Close();
                ex.ToString();
                return null;
 
            }

 
        }

        
        private void button1_Click(object sender, EventArgs e)
        {

            switch (this.comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        CRfriends_count CRfriends = new CRfriends_count();
                        DataSet ds = LoadDataSet("select Top(1000) * from users order by friends_count desc");
                        if (ds != null)
                        {
                            CRfriends.SetDataSource(ds.Tables [0]);
                            this.crystalReportViewer1.ReportSource = CRfriends;
                        }
                        else
                        {
                            MessageBox.Show("数据库加载错误，请检查数据连接是否正常!");
                        }
                        break;

                    }
                case 1:
                    {
                        CRfollowers_count CRfollowers = new CRfollowers_count();
                        DataSet ds = new DataSet();
                        ds = LoadDataSet("select * from users where followers_count>10000000 order by followers_count desc ");
                        if (ds != null)
                        {
                            CRfollowers.SetDataSource(ds.Tables [0]);
                            this.crystalReportViewer1.ReportSource = CRfollowers;
                            //this.crystalReportViewer1.RefreshReport();
                        }
                        else
                        {
                            MessageBox.Show("数据库加载错误，请检查数据连接是否正常!");
                        }
                        break;

                    }
                case 2:
                    {
                        CRlocation CRloc = new CRlocation();
                        DataSet ds = new DataSet();
                        ds = LoadDataSet("select * from users where location!='' and location is not null ");
                        if (ds != null)
                        {
                            CRloc.SetDataSource(ds.Tables[0]);
                            this.crystalReportViewer1.ReportSource = CRloc;
                            //this.crystalReportViewer1.RefreshReport();
                        }
                        else
                        {
                            MessageBox.Show("数据库加载错误，请检查数据连接是否正常!");
                        }
                        break;
                    }
                case 3:
                    {
                        CRstatuses_count CRstatuses = new CRstatuses_count();
                        DataSet ds = new DataSet();
                        ds = LoadDataSet("select * from users where statuses_count>50000 order by statuses_count desc ");
                        if (ds != null)
                        {
                            CRstatuses.SetDataSource(ds.Tables[0]);
                            this.crystalReportViewer1.ReportSource = CRstatuses;
                            //this.crystalReportViewer1.RefreshReport();
                        }
                        else
                        {
                            MessageBox.Show("数据库加载错误，请检查数据连接是否正常!");
                        }
                        break;

                    }
                case 4:
                    {
                        CRTime CRtime = new CRTime();
                        DataSet ds = new DataSet();
                        ds = LoadDataSet("select  * from users  ");
                        if (ds != null)
                        {
                            CRtime.SetDataSource(ds.Tables[0]);
                            this.crystalReportViewer1.ReportSource = CRtime;
                            //this.crystalReportViewer1.RefreshReport();
                        }
                        else
                        {
                            MessageBox.Show("数据库加载错误，请检查数据连接是否正常!");
                        }
                        break;
                    }
                default:
                    break;
            }

        }

        private void Statistics_Load(object sender, EventArgs e)
        {

        }
    }
}
