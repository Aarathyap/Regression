using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using Regression.Linear;

namespace Regression
{
    public partial class FileInput2 : Form
    {
        int count = 0;
        public FileInput2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = Program.dpath11;
            string text1 = File.ReadAllText(Application.StartupPath + path);
            string column = text1;
            string[] columnnames = Regex.Split(column.Trim(), "\n");
            for (int i = 0; i < columnnames.Count(); i++)
            {
                string[] columntext = columnnames[i].Split(',');

                if (columntext[3].Trim().Contains(textBox1.Text.Trim()))
                {
                    count++;
                    if (columntext[0].ToString().Replace("\r", "").ToString()== "positive")
                    {
                        textBox2.Text = "Positive  !!! " + columntext[1].ToString()+ " Airlines:";
                        break;
                    }
                    if (columntext[0].ToString().Replace("\r", "").ToString() == "negative")
                    {
                        textBox2.Text = "Negative  !!!" + columntext[1].ToString() + " Airlines:"; ;
                        break;
                    }
                    if (columntext[0].ToString().Replace("\r", "").ToString() == "neutral")
                    {
                        textBox2.Text = "Neutral !!! " + columntext[1].ToString() + " Airlines:"; ;
                        break;
                    }



                }
               
            }
            if (count == 0)
            {
                textBox2.Text = "Not Matching with Models !!!";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
