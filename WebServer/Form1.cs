using System;
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
        private bool _isRunning;
        static readonly object _isRunningLock = new object();
        // setting up get and set
        private bool IsRunning
        {
            get
            {
                // Thread safe get & set
                lock (_isRunningLock)
                {
                    return this._isRunning;
                }
            }
            set
            {
                lock (_isRunningLock)
                {
                    this._isRunning = value;
                    Start.Enabled = !value;
                    StopEnd.Enabled = value;
                }
            }
            
        }

        IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        TcpListener server = null;


        public WebServerPage()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            _isRunning = true;
            ThreadPool.QueueUserWorkItem(StartServer, this._isRunning);

        }

        private void StopEnd_Click(object sender, EventArgs e)
        {
            // stopping server
            _isRunning = false;
        }
        private void StartServer(object isRun)
        {
            int port = 2858;
            server = new TcpListener(localAddr, port);
            server.Start();
            bool isRunning = (bool) isRun;
            // while the server is running
            while (isRunning)
            {
                    try
                    {
                        TcpClient client = server.AcceptTcpClient();
                        ThreadPool.QueueUserWorkItem(GetRequestedItem, client);
                        string header = CreateHeader(@"Http/1.0", @"text/html", "200 OK");
                        client.Client.Send(Encoding.ASCII.GetBytes(header));

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error in web server: " + e.Message);
                    }
            }
        }
        public string CreateHeader(string sHTTPVersion, string sMIMEHeader, string sStatus)
        {
            string sBuffer = "";

            sBuffer = sBuffer + sHTTPVersion + sStatus + "\r\n";
            sBuffer = sBuffer + "Content-Type: " + sMIMEHeader + "\r\n";

            return sBuffer;
        }
        public void GetRequestedItem (object client)
        {
            TcpClient c = (TcpClient) client;
            // Some sort of get Call to recieve the request

        }
        /*
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
        */
    }
}
