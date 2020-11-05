using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace PickColorServer
{
    public partial class Form1 : Form
    {
        public static string IPServer;
        public static int Port;
        public static string WarnaServer;
        public Form1()
        {
            InitializeComponent();
        }

        private void listenSocket()
        {
            Port = Int16.Parse(txtPort.Text);
            IPServer = txtIp.Text;
            StartListening();
        }


        private void timerServer_Tick(object sender, EventArgs e)
        {
            if (WarnaServer != null)
            {
                string[] receiver = WarnaServer.Split(',');

                
                txtRed.Text = receiver[0];
                txtGreen.Text = receiver[1];
                txtBlue.Text = receiver[2];
                
                panelServer.BackColor = Color.FromArgb(int.Parse(receiver[0]), int.Parse(receiver[1]), int.Parse(receiver[2]));
            }
        }


        class StateObject
        {
            public Socket workSocket = null;
            public const int BufferSize = 256;
            public byte[] buffer = new byte[BufferSize];
            public StringBuilder sb = new StringBuilder();
        }

        // SOCKET SERVER
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public static void StartListening()
        {
            IPAddress ipAddress = IPAddress.Parse(IPServer);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, Port);
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    allDone.Reset();
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            String terimaPesan = String.Empty;

            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                terimaPesan = state.sb.ToString();
                if (terimaPesan != "")
                {
                    WarnaServer = terimaPesan;
                }
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(listenSocket);
            if (txtIp.Text != "")
            {
                thread.Start();
                btnListen.Enabled = false;
            }
            else
                MessageBox.Show("Lengkapi IP Server terlebih dahulu");
        }
    }
}

