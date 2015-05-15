using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteLoginTest
{
    public partial class Form1 : Form
    {
        private bool _IsReports = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://portal.comparethemarket.com/Account/LogOn?ReturnUrl=%2f");
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        

        }

        void webBrowser1_DocumentCompleted (object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string s = webBrowser1.DocumentText;
            btnLogin.Enabled = true;
            Thread.Sleep(2000);

            if(_IsReports)
            {
             HtmlElement ele = webBrowser1.Document.GetElementById("ReportViewer1_ctl04_ctl11_ddValue");
                if (ele != null)
                    ele.SetAttribute("Value", "1");

                ele = webBrowser1.Document.GetElementById("ReportViewer1_ctl04_ctl13_ddValue");
                if (ele != null)
                    ele.SetAttribute("Value", "3");
                ele = webBrowser1.Document.GetElementById("ReportViewer1_ctl04_ctl05_ddValue");
                if (ele != null)
                    ele.SetAttribute("Value", "1");


                ele = webBrowser1.Document.GetElementById("ReportViewer1_ctl04_ctl07_txtValue");
                if (ele != null)
                {
                    ele.InnerText = "01/04/15";
                }


                ele = webBrowser1.Document.GetElementById("ReportViewer1_ctl04_ctl09_txtValue");
                if (ele != null)
                {
                    ele.InnerText = "01/04/15";
                }


                ele = webBrowser1.Document.GetElementById("ReportViewer1_ctl04_ctl00");

                if (ele != null)
                {
                    ele.InvokeMember("click");
                }
                else
                {
                    MessageBox.Show("Button not found");
                }

                _IsReports = false;
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            AutoResetEvent _resetevent = new AutoResetEvent(false);

            HtmlElement ele = webBrowser1.Document.GetElementById("UserName");
            if (ele != null)
                ele.InnerText = "CTM_THA01";
            ele = webBrowser1.Document.GetElementById("Password");
            if (ele != null)
                ele.InnerText = "daxa7Ast";
            ele = webBrowser1.Document.GetElementById("ButtonAuthenticate");
            if (ele != null)
            {
                ele.InvokeMember("click");
                _IsReports = true;
                Thread.Sleep(1000);
                webBrowser1.Navigate("https://portal.comparethemarket.com/Home/Reports");
                webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
               
            }
           // EventWaitHandle.WaitAll(new AutoResetEvent[] { _resetevent });

          
                   

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }
    }
}
