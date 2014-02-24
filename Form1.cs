//*************************************
//c-_wifi_hotspot_build240214.V1*******
//Alpaslan Gökcen-2014*****************
//*************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace wifi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void kod()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe"; //Sets the FileName property of myProcessInfo to %SystemRoot%\System32\cmd.exe
            p.StartInfo.Arguments = "/c netsh wlan set hostednetwork mode=allow ssid=" + textBox1.Text + " key=" + textBox2.Text + " keyUsage=persistent " ; //Setting Wlan SSID From Textbox
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;//Hiding Cmd Command
            p.StartInfo.CreateNoWindow = true;//hiding Windows
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();//start Process
            string output = p.StandardOutput.ReadToEnd();//Result Of Process
            richTextBox1.Text = output;//Returning Value to Textbox
        }
        public void baslat()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe"; //Sets the FileName property of myProcessInfo to %SystemRoot%\System32\cmd.exe
            p.StartInfo.Arguments = "/c netsh wlan start hostednetwork "; //file içerisine gönderilecek arguments
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;//Komut çalıstıgında Cmd penceresinin açılmasını engeller
            p.StartInfo.CreateNoWindow = true;//Pencere Açılmasını engeller
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();//process Çalıstırılır
            string output = p.StandardOutput.ReadToEnd();//Çalısan Processin sonucu
            richTextBox1.Text = output;//Sonuç textboxa yazılır
        }
        public void dur()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe"; //Sets the FileName property of myProcessInfo to %SystemRoot%\System32\cmd.exe
            p.StartInfo.Arguments = "/c netsh wlan stop hostednetwork "; //file içerisine gönderilecek arguments
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;//Komut çalıstıgında Cmd penceresinin açılmasını engelledik
            p.StartInfo.CreateNoWindow = true;//Pencere Açılmasını engeller
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();//process Çalıstırılır
            string output = p.StandardOutput.ReadToEnd();//Çalısan Processin sonucu
            richTextBox1.Text = output;//Sonuç textboxa yazılır
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baslat();
            button3.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = true;//System.Diagnostics.Process.Start("CMD.EXE",@"netsh wlan set hostednetwork mode=allow ssid="+textBox1.Text+" key="+textBox2.Text+" keyUsage=persistent");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dur();
            button3.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = false; textBox1.Enabled = true; textBox2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kod();
            MessageBox.Show("Successfully applied!");
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            button1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false; button2.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label3.Text = textBox2.Text;
            }
            else
            {
                label3.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe"; //Sets the FileName property of myProcessInfo to %SystemRoot%\System32\cmd.exe
            p.StartInfo.Arguments = "/c netsh wlan show all "; //file içerisine gönderilecek arguments
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;//Komut çalıstıgında Cmd penceresinin açılmasını engeller
            p.StartInfo.CreateNoWindow = true;//Pencere Açılmasını engeller
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();//process Çalıstırılır
            string output = p.StandardOutput.ReadToEnd();//Çalısan Processin sonucu
            richTextBox1.Text = output;//Sonuç textboxa yazılır
            //netsh wlan show hostednetwork
        }
    }
}
