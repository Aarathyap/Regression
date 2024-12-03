using ChatBot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Regression.Linear
{
    public partial class DetectCyber : Form
    {
        public DetectCyber()
        {
            InitializeComponent();
        }

        private void toolStripLabel7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileInput obj = new FileInput();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileInput2 obj = new FileInput2();
            obj.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            botcheck1 obj = new botcheck1();
            obj.Show();
        }
    }
}
