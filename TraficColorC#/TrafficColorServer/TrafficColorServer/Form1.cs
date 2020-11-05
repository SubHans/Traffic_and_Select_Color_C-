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

namespace TrafficColorServer
{

    public partial class Form1 : Form
    {
        public static string alamatIPServer;
        public static int port;
        public static string terimapesandiserver = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void listenSocket()
        {
            port = Int16.Parse(txtPort.Text);
            alamatIPServer = txtIpAddress.Text;
            StartListening();
        }

        private void timerServer_Tick(object sender, EventArgs e)
        {

            if (terimapesandiserver.Length > 1)
            {
                txtKet.Clear();
                string[] data = terimapesandiserver.Trim().Split(',');
                StringBuilder sb = new StringBuilder();
                sb.Append("Lampu ").Append(data[0]).Append(" ").Append(data[1]);
                changer(data);
                txtKet.Text = sb.ToString();
            }
        }

        private void changer(string[] tmp)
        {
            Color color = Color.Black;
            if (tmp[1].Equals("Hidup"))
            {
                color = chooserColor(tmp[0]);
            }
            switch (tmp[0])
            {
                case "Merah":
                    panelMerah.BackColor = color;
                    break;
                case "Kuning":
                    PanelKuning.BackColor = color;
                    break;
                case "Hijau":
                    PanelHijau.BackColor = color;
                    break;
            }
        }

        private Color chooserColor(String choose)
        {
            switch (choose)
            {
                case "Merah":
                    return Color.Red;
                case "Kuning":
                    return Color.Yellow;
                case "Hijau":
                    return Color.Green;
                default:
                    return Color.Black;
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            Thread thr = new Thread(listenSocket);
            if (txtIpAddress.Text != "")
            {
                thr.Start();
                btnListen.Enabled = false;
            }
            else
            {
                MessageBox.Show("Lengkapi alamat IP terlebih dahulu !!!");
            }
        }



        //Server
        class StateObject
        {
            public Socket workSocket = null;
            public const int BufferSize = 256;
            public byte[] buffer = new byte[BufferSize];
            public StringBuilder sb = new StringBuilder();
        }

        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public static void StartListening()
        {
            IPAddress ipAddress = IPAddress.Parse(alamatIPServer);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
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
                    terimapesandiserver = terimaPesan;
                   
                }
            }
        }
    }
}
