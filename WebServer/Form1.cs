using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebServer
{
    public partial class WebServerPage : Form
    {
        private int port = 2858;

        IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        TcpListener server = null;


        public WebServerPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ThreadPool.QueueUserWorkItem(StartServer, port);
            StartServer(port);

            MessageBox.Show("Hello! How are you?");
        }

        private void StopEnd_Click(object sender, EventArgs e)
        {
            server.Stop();
            MessageBox.Show("I'm well! Thanks for asking!! :)");
        }
        private void StartServer(int port)
        {
            server = new TcpListener(localAddr, port);
            server.Start();
        }
        public void SetForegroundData(string value)
        {
            // Is this a background thread? If so, call it's parent
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(SetForegroundData), new object[] { value });
                return;
            }
            // If parent, send the value to the parent
            //textOutput.Text = value;
        }
    }
}
