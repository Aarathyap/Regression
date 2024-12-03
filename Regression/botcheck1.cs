using ChatBot;
using Regression.Linear;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Regression
{
    public partial class botcheck1 : Form
    {
        BaseConnection con = new BaseConnection();
        public static string ans = "";
        static Regression.Linear.ChatBot bot;
        public static string outtt = "";
        public botcheck1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bot = new Regression.Linear.ChatBot();
            outtt = bot.getOutput(textBox2.Text);
            


            // backgroundWorker1.Dispose();
            
            string ss = test(textBox2.Text);
            richTextBox1.AppendText("\n");
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.AppendText("QUESTIONS: "+textBox2.Text+" \n");
            
            
            
            pictureBox1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
            richTextBox1.SelectionColor = Color.Green;
            richTextBox1.AppendText("BOTS Says: "+outtt+"\n");
           
            textBox2.Text = "";
        }
        public static string test(string text)
        {
            // Replace any character that is not a letter, digit, space, underscore, or hyphen with an empty string
            return Regex.Replace(text, "[^0-9A-Za-z _-]", "");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = -3;    // -10...10

            synthesizer.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.Adult);
            synthesizer.Speak(outtt);
            pictureBox1.Visible = false;
        }

        private void botcheck1_Load(object sender, EventArgs e)
        {
           
            string data = "Hai user I am a chatbot. I can try and answer some of your questions ? How can i help you";
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = -3;    // -10...10

            synthesizer.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.Adult);
            synthesizer.Speak(data);
            pictureBox1.Visible = false;
            richTextBox1.AppendText(data+"\n");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
