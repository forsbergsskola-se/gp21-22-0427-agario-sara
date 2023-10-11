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
            NetworkStream stream = tcpClient.GetStream();
            //(Optional) Reading from the client
            byte[] buffer = new byte[100];
            stream.Read(buffer, 0, 100);
            //Optional: Show what the client said:
            Console.WriteLine("Client said: " + Encoding.ASCII.GetString(buffer));

            //Get the current dateTime:
            DateTime currentTime = DateTime.Now;
            string message = "-----Actual Date time:" + "\r\n";
            message+= currentTime.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
            message += "Thank you for connecting!";

            //Send the current DateTime Encoded into Bytes
            byte[] responseBuffer = Encoding.ASCII.GetBytes(message);
            stream.Write(responseBuffer, 0, responseBuffer.Length);

            //Close the Client:
            tcpClient.Close();
        }
    }
}
