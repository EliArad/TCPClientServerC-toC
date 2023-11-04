using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class TCPClient : IDisposable
{
    private TcpClient client;
    private NetworkStream stream;
    private Thread receiveThread;
    ITCPClient piTCPClient;

    public interface ITCPClient
    {
        void NotifyTCPClientData(byte[] data, int size);
    }

    string m_serverIp;
    int m_serverPort;
    public TCPClient(string serverIP, int serverPort, ITCPClient p)
    {
        client = new TcpClient();
        m_serverIp = serverIP;
        m_serverPort = serverPort;
        piTCPClient = p;
    }

    public bool Connect()
    {
        try
        {
            client.Connect(m_serverIp, m_serverPort);
            stream = client.GetStream();
        }
        catch (Exception err)
        {
            return false;
        }

        receiveThread = new Thread(ReceiveData);
        receiveThread.Start();
        return true;
    }

    public void Send(byte[] data, int size)
    {
        stream.Write(data, 0, size);
    }

    public void Send(byte[] data, int index, int size)
    {
        stream.Write(data, index, size);
    }

    public void Send(byte[] data)
    {
        stream.Write(data, 0, data.Length);
    }


    private void ReceiveData()
    {
        byte[] data = new byte[1024];
        try
        {
            while (true)
            {
               
                int bytesRead = stream.Read(data, 0, data.Length);
                if (bytesRead > 0)
                {
                    string response = Encoding.ASCII.GetString(data, 0, bytesRead);
                    Console.WriteLine("Received: " + response);
                    piTCPClient.NotifyTCPClientData(data, bytesRead);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error in receive thread: " + e.Message);
        }
    }

    public void Dispose()
    {
        receiveThread.Abort(); // Terminate the receive thread
        client.Close();
    }
}
