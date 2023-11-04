using AsyncTCPServerLib;
using DRSRadaApi;
using InvokersLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TCPClient;

namespace TCPClientServerC_Api
{
    public partial class Form1 : Form, ITCPClient, IAsyncTCPServer
    {
        TCPClient m_client;
        AsyncTCPServer m_tcpServer;

        public Form1()
        {
            InitializeComponent();
            m_client = new TCPClient("127.0.0.1", 7003, this);
            m_tcpServer = new AsyncTCPServer(this);

            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_running = false;
            m_tcpServer?.Close();
            m_client?.Dispose();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

            if (m_tcpServer.CreateServer(7002, out string outMessage) == false)
            {
                MessageBox.Show("Failed to create server on port 7002");
                return;
            }
            LogMessage("Server created and start lisetning");

            var t = new Thread(ClientConnectThread);
            t.Start();

        }
        void LogMessage(string msg)
        {
            INVOKERS.InvokeControlAppendText2(txtServerMessages, msg);
        }

        bool m_running = true;
        void ClientConnectThread()
        {
            LogMessage("Attempting to connect to server at port 7003");
            while (m_running)
            {
                
                INVOKERS.InvokeControlForeColor(btnConnect, Color.Black);
                if (m_client.Connect() == false)
                {
                    INVOKERS.InvokeControlForeColor(btnConnect, Color.Red);
                    Thread.Sleep(300);
                    continue;
                }
                INVOKERS.InvokeControlForeColor(btnConnect, Color.Green);
                LogMessage("Client connnected to server ok!");
                break;
            }
        }
         

        TRACK_VERSION1 m_trackVersion1 = new TRACK_VERSION1();
        private void btnSendTrackVersion1_Click(object sender, EventArgs e)
        {
            bool b = float.TryParse(txtPositionX.Text, out float posX);
            if (b == false)
            {
                MessageBox.Show("Position X is not set");
                return;
            }

            b = float.TryParse(txtPositionY.Text, out float posY);
            if (b == false)
            {
                MessageBox.Show("Position Y is not set");
                return;
            }

            b = float.TryParse(txtPositionZ.Text, out float posZ);
            if (b == false)
            {
                MessageBox.Show("Position Z is not set");
                return;
            }

            m_trackVersion1.header.messageCounter = 50000;
            m_trackVersion1.header.messageOpcode = 7;
            m_trackVersion1.positionX = posX;
            m_trackVersion1.positionY = posY;
            m_trackVersion1.positionZ = posZ;

            byte[] buffer = Utils.StructToByteArray(m_trackVersion1);
            m_client.Send(buffer);
        }

        private void btnDiconnect_Click(object sender, EventArgs e)
        {
            m_running = false;
            m_client.Dispose();
            m_client = null;
            m_tcpServer?.Close();
            btnConnect.ForeColor = Color.Black;
        }

        public void NotifyClientConnected(Socket ep)
        {
            INVOKERS.InvokeControlAppendText2(txtServerMessages, "Client Connected");
        }

        public void NotifyClientClose(Socket ep)
        {
            INVOKERS.InvokeControlAppendText2(txtServerMessages, "Client Closed");
        }

        public void NotifyServerClose()
        {
            INVOKERS.InvokeControlAppendText2(txtServerMessages, "Server closed");
        }

        public void NotifyTCPServerReceive(byte[] data, int sizeRecv)
        {
            DRSRadaHeader h = Utils.StructFromByteArray<DRSRadaHeader>(data);
            if (h.messageOpcode == 1)
            {
                MODE_REQUEST mr = Utils.StructFromByteArray<MODE_REQUEST>(data);
                INVOKERS.InvokeControlAppendText2(txtServerMessages, "Got Mode request");
                INVOKERS.InvokeControlAppendText2(txtServerMessages, "Mode request:" + mr.mode);
            }
        }

        public void NotifyTCPClientData(byte[] data, int size)
        {
            throw new NotImplementedException();
        }
    }
}
