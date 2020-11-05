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

namespace TrafficColorClient
{
    
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        public static string IPServer;
        public static int Port;
        public static string terimapesandariserver;

        private void btnMerahHidup_CheckedChanged(object sender, EventArgs e)
        {
            if (txtIPAddress.Text.Equals(""))
            {
                MessageBox.Show("Alamat IP Tujuan belum di set");
                btnMerahHidup.Checked = false;
            }
            else
            {
                IPServer = txtIPAddress.Text;
                Port = Int16.Parse(txtPort.Text);
                StartClient("Merah,Hidup");
            }
        }

        private void btnMerahMati_CheckedChanged(object sender, EventArgs e)
        {
            if (txtIPAddress.Text.Equals(""))
            {
                MessageBox.Show("Alamat IP Tujuan belum di set");
                btnMerahHidup.Checked = false;
            }
            else
            {
                IPServer = txtIPAddress.Text;
                Port = Int16.Parse(txtPort.Text);
                StartClient("Merah,Mati");
            }
        }

        private void btnKuningHidup_CheckedChanged(object sender, EventArgs e)
        {
            if (txtIPAddress.Text.Equals(""))
            {
                MessageBox.Show("Alamat IP Tujuan belum di set");
                btnMerahHidup.Checked = false;
            }
            else
            {
                IPServer = txtIPAddress.Text;
                Port = Int16.Parse(txtPort.Text);
                StartClient("Kuning,Hidup");
            }
        }

        private void btnKuningMati_CheckedChanged(object sender, EventArgs e)
        {
            if (txtIPAddress.Text.Equals(""))
            {
                MessageBox.Show("Alamat IP Tujuan belum di set");
                btnMerahHidup.Checked = false;
            }
            else
            {
                IPServer = txtIPAddress.Text;
                Port = Int16.Parse(txtPort.Text);
                StartClient("Kuning,Mati");
            }
        }

        private void btnHijauHidup_CheckedChanged(object sender, EventArgs e)
        {
            if (txtIPAddress.Text.Equals(""))
            {
                MessageBox.Show("Alamat IP Tujuan belum di set");
                btnMerahHidup.Checked = false;
            }
            else
            {
                IPServer = txtIPAddress.Text;
                Port = Int16.Parse(txtPort.Text);
                StartClient("Hijau,Hidup");
            }
        }
        private void btnHijauMati_CheckedChanged(object sender, EventArgs e)
        {
            if (txtIPAddress.Text.Equals(""))
            {
                MessageBox.Show("Alamat IP Tujuan belum di set");
                btnMerahHidup.Checked = false;
            }
            else
            {
                IPServer = txtIPAddress.Text;
                Port = Int16.Parse(txtPort.Text);
                StartClient("Hijau,Mati");
            }
        }
        


        class StateObject
        {
            public Socket workSocket = null;
            public const int BufferSize = 256;
            public byte[] buffer = new byte[BufferSize];
            public StringBuilder sb = new StringBuilder();
        }

        public static ManualResetEvent connectDone = new ManualResetEvent(false);
        public static ManualResetEvent sendDone = new ManualResetEvent(false);
        public static ManualResetEvent receiveDone = new ManualResetEvent(false);
        public static String response = String.Empty;

        // SOCKET CLIENT

        public static void StartClient(string pesan)
        {
            IPAddress ip = IPAddress.Parse(IPServer);
            IPEndPoint remoteEP = new IPEndPoint(ip, Port);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            var result = client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
            result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
            Thread.Sleep(10);

            if (client.Connected)
            {
                Send(client, pesan);
                Thread.Sleep(500);
                sendDone.WaitOne();

                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }

        public static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar);
                connectDone.Set();
            }
            catch
            {
                // pass
            }
        }

        public static void Send(Socket client, String data)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
        }

        public static void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                int byteSent = client.EndSend(ar);
                sendDone.Set();
            }
            catch
            {
                // pass
            }
        }

        public static void Receive(Socket client)
        {
            StateObject state = new StateObject();
            state.workSocket = client;
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
        }

        public static void ReceiveCallback(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            Socket client = state.workSocket;
            int bytesRead = client.EndReceive(ar);

            if (bytesRead > 0)
            {
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            else
            {
                if (state.sb.Length > 1)
                {
                    response = state.sb.ToString();
                    terimapesandariserver = response;
                }
                receiveDone.Set();
            }
        }

        
    }
}
