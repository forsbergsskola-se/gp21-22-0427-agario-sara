using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public static class Program
{
    static void Main()
    {
        //Opening the socket
        int port = 44444;
        //IPEndpoint like in the sample TCP server, called it instead of assignment of address abd port ti TcpListener
        IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, port);
        TcpListener tcpListener = new TcpListener(endpoint);
        tcpListener.Start();
        Console.WriteLine("--------Hello From Server!");
        Console.WriteLine($"--------Time server running... Listening on port: {port}");

        //As long as we want the server to run
        while (true)
        {
            //Accept new client that tries to connect
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            byte[] buffer = new byte[100];
            NetworkStream stream = tcpClient.GetStream();
            stream.Read(buffer, 0, 100);
            Console.WriteLine("Client said: " + Encoding.ASCII.GetString(buffer));




            

        }
    }
}
