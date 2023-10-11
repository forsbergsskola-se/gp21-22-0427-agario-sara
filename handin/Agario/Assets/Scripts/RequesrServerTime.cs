using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine;

public class RequestServerTime : MonoBehaviour
{
    public TextMeshProUGUI timeOutputTextMeshPro;

    //Connection settings
    public string serverIp = "127.0.0.1"; 
    public int serverPort = 44444;
    public int clientPort = 44446;

    public void SendRequest()
    {
        // Create a new TCP client and connect to the server
        IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, serverPort);
        IPEndPoint clientEndpoint = new IPEndPoint(IPAddress.Loopback, clientPort);

        // Start a client end point
        TcpClient tcpClient = new TcpClient(clientEndpoint);

        // Connect to the server's end point
        tcpClient.Connect(serverEndpoint);

        // Receive a message from the server
        NetworkStream stream = tcpClient.GetStream();
        byte[] buffer = new byte[100];
        stream.Read(buffer, 0, 100);
        string message = Encoding.ASCII.GetString(buffer);
        timeOutputTextMeshPro.text = "The Server said: " + message;

        // Close the client
        tcpClient.Close();
    }
}
