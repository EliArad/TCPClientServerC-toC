using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTCPServerLib
{
    public interface IAsyncTCPServer
    {
        void NotifyClientConnected(Socket ep);
        void NotifyClientClose(Socket ep);
        void NotifyServerClose();
        void NotifyTCPServerReceive(byte [] data, int sizeRecv);
    }
    public class AsyncTCPServer
    {
        Socket m_server = null;
        IAsyncTCPServer pIAsyncTCPServer;
        const int MAX_SIZE = 1024;
        byte[] data = new byte[MAX_SIZE];
    
        public AsyncTCPServer(IAsyncTCPServer p)
        {
            pIAsyncTCPServer = p;
        }
        public void Close()
        {
             
            if (m_server != null)
                m_server.Close();
            m_server = null;
            m_serverInitialize = false;
        }

        public bool IsServerInitialize
        {
            get
            {
                return m_serverInitialize;
            }
        }

        bool m_serverInitialize = false;
        public bool CreateServer(string serverAddress , int port , out string outMessage)
        {
            outMessage = string.Empty;
            try
            {
                if (m_serverInitialize == true)
                {
                    outMessage = "Server already initialized";
                    return true;
                }
                m_server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(serverAddress), port);
                m_server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                m_server.Bind(iep);
                m_server.Listen(5);
                m_server.BeginAccept(new AsyncCallback(AcceptConn), m_server);
                m_serverInitialize = true;
                return true;
            }
            catch (Exception err)
            {
                m_serverInitialize = false;
                outMessage = err.Message;
                return false;
            }
        }

        public bool CreateServer(int port, out string outMessage)
        {
            outMessage = string.Empty;
            try
            {
                if (m_serverInitialize == true)
                {
                    outMessage = "Server already initialized";
                    return true;
                }
                m_server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint iep = new IPEndPoint(IPAddress.Any, port); // Bind to any available network interface
                m_server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                m_server.Bind(iep);
                m_server.Listen(5);
                m_server.BeginAccept(new AsyncCallback(AcceptConn), m_server);
                m_serverInitialize = true;
                return true;
            }
            catch (Exception err)
            {
                m_serverInitialize = false;
                outMessage = err.Message;
                return false;
            }
        }


        void AcceptConn(IAsyncResult iar)
        {
            try
            {
                Socket oldserver = (Socket)iar.AsyncState;
                Socket client = oldserver.EndAccept(iar);
                 
                pIAsyncTCPServer.NotifyClientConnected(client);
                
                client.BeginReceive(data, 0, MAX_SIZE, SocketFlags.None, new AsyncCallback(ReceiveData), client);
                m_server.BeginAccept(new AsyncCallback(AcceptConn), m_server);
            }
            catch (Exception err)
            {

            }

        }

        void SendDataCallback(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            int sent = client.EndSend(iar);           
        }

        public bool Send(Socket client, int id , byte [] buffer, int size)
        {
            try
            {
                client.BeginSend(buffer, 0, size, SocketFlags.None,
                       new AsyncCallback(SendDataCallback), client);
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        void ReceiveData(IAsyncResult iar)
        {
            
            try
            {

                Socket client = (Socket)iar.AsyncState;
                int sizeRecv = client.EndReceive(iar);
                if (sizeRecv == 0)
                {                     
                    pIAsyncTCPServer.NotifyClientClose(client);
                    client.Close();
                    return;
                }
                pIAsyncTCPServer.NotifyTCPServerReceive(data, sizeRecv);

                client.BeginReceive(data, 0, MAX_SIZE, SocketFlags.None,
                     new AsyncCallback(ReceiveData), client);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }            
        }       
    }
}
