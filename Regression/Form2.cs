using Accord.Controls;
using Regression.Linear;
using sun.rmi.transport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Regression
{
    public partial class Form2 : Form
    {
        public static string pdata = Application.StartupPath + "\\Data\\tweets.xls";
        public static string a1, a2, a3, a4, a5, a6;
        public static string con1 = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + pdata + "';" + @"Extended Properties='Excel 8.0;HDR=Yes;'";
        string connString = "Driver={Microsoft Excel Driver (*.xls)};READONLY=FALSE;DriverId=790;Dbq=" + Application.StartupPath + "\\Data\\tweets.xls";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            //OdbcDataAdapter myDataAdaptor = new OdbcDataAdapter(CMD);
            //DataSet ds = new DataSet();
            //myDataAdaptor.Fill(ds, "Sheet1");
            //DataTable dt = ds.Tables[0];
            //foreach (DataRow dr in dt.Rows)
            //{
                
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OdbcConnection conn = new OdbcConnection(connString);
            conn.Open();
            //conn.ConnectionTimeout = 500;
            OdbcCommand CMD = new OdbcCommand(Dataprocess.d1+"'"+comboBox1.SelectedItem.ToString()+"' and sentiment='positive'", conn);
            OdbcDataReader dr;
            dr = CMD.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
            }
            conn.Close();
            conn.Open();
            //conn.ConnectionTimeout = 500;
            OdbcCommand CMD1 = new OdbcCommand(Dataprocess.d1+"'" + comboBox1.SelectedItem.ToString() + "' and sentiment='negative'", conn);
            OdbcDataReader dr1;
            dr1 = CMD1.ExecuteReader();
            if (dr1.Read())
            {
                textBox2.Text = dr1[0].ToString();
            }
            conn.Close();
            conn.Open();
            //conn.ConnectionTimeout = 500;
            OdbcCommand CMD2 = new OdbcCommand(Dataprocess.d1 + "'" + comboBox1.SelectedItem.ToString() + "' and sentiment='neutral'", conn);
            OdbcDataReader dr2;
            dr2 = CMD2.ExecuteReader();
            if (dr2.Read())
            {
                textBox3.Text = dr2[0].ToString();
            }
            conn.Close();
            chart1.Titles.Clear();
            chart1.Series["Accuracy"].Points.Clear();
            fillChart();
        }
        private void fillChart()
        {
           
            chart1.ChartAreas[0].AxisY.Minimum = 30;

            chart1.ChartAreas[0].AxisY.Maximum = 2500;
            //AddXY value in chart1 in series named as Salary  
            chart1.Series["Accuracy"].Points.AddXY("POSTIVE", textBox1.Text);
            chart1.Series["Accuracy"].Points.AddXY("NEGATIVE", textBox2.Text);
            chart1.Series["Accuracy"].Points.AddXY("NEUTRAL", textBox3.Text);

            //chart title  
            chart1.Titles.Add("Analysis");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            OdbcConnection conn = new OdbcConnection(connString);
            conn.Open();
            //conn.ConnectionTimeout = 500;
            OdbcCommand CMD = new OdbcCommand(Dataprocess.d2+"'" + comboBox2.SelectedItem.ToString() + "' and airline='Virgin America'", conn);
            OdbcDataReader dr;
            dr = CMD.ExecuteReader();
            if (dr.Read())
            {
                a1= dr[0].ToString();
            }
            conn.Close();
            conn.Open();
            //conn.ConnectionTimeout = 500;
            OdbcCommand CMD1 = new OdbcCommand(Dataprocess.d2 + "'" + comboBox2.SelectedItem.ToString() + "' and airline='United'", conn);
            OdbcDataReader dr1;
            dr1 = CMD1.ExecuteReader();
            if (dr1.Read())
            {
                a2 = dr1[0].ToString();
            }
            conn.Close();
            conn.Open();
            //conn.ConnectionTimeout = 500;
            OdbcCommand CMD2 = new OdbcCommand(Dataprocess.d2 + "'" + comboBox2.SelectedItem.ToString() + "' and airline='Southwest'", conn);
            OdbcDataReader dr2;
            dr2 = CMD2.ExecuteReader();
            if (dr2.Read())
            {
                a3 = dr2[0].ToString();
            }
            conn.Close();
            conn.Open();
            //conn.ConnectionTimeout = 500;
            OdbcCommand CMD3 = new OdbcCommand(Dataprocess.d2 + "'" + comboBox2.SelectedItem.ToString() + "' and airline='Delta'", conn);
            OdbcDataReader dr3;
            dr3 = CMD3.ExecuteReader();
            if (dr3.Read())
            {
                a4 = dr3[0].ToString();
            }
            conn.Close();
            conn.Open();
            //conn.ConnectionTimeout = 500;
            OdbcCommand CMD4 = new OdbcCommand(Dataprocess.d2 + "'" + comboBox2.SelectedItem.ToString() + "' and airline='US Airways'", conn);
            OdbcDataReader dr4;
            dr4 = CMD4.ExecuteReader();
            if (dr4.Read())
            {
                a5 = dr4[0].ToString();
            }
            conn.Close();
            conn.Open();
            //conn.ConnectionTimeout = 500;
            OdbcCommand CMD5 = new OdbcCommand(Dataprocess.d2 + "'" + comboBox2.SelectedItem.ToString() + "' and airline='American'", conn);
            OdbcDataReader dr5;
            dr5 = CMD5.ExecuteReader();
            if (dr5.Read())
            {
                a6= dr5[0].ToString();
            }
            conn.Close();
            
            chart2.Titles.Clear();
            chart2.Series["Sentiment"].Points.Clear();
            fillChart1();
        }
        private void fillChart1()
        {

            chart2.ChartAreas[0].AxisY.Minimum = 30;

            chart2.ChartAreas[0].AxisY.Maximum = 2500;
            //AddXY value in chart1 in series named as Salary  
            chart2.Series["Sentiment"].Points.AddXY("Virgin America", a1);
            chart2.Series["Sentiment"].Points.AddXY("United", a2);
            chart2.Series["Sentiment"].Points.AddXY("Southwest", a3);
            chart2.Series["Sentiment"].Points.AddXY("Delta", a4);
            chart2.Series["Sentiment"].Points.AddXY("US Airways", a5);
            chart2.Series["Sentiment"].Points.AddXY("American", a6);

            //chart title  
            chart2.Titles.Add("Analysis");
        }
    }
}
        
            
                
               
                


