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


    }
}
