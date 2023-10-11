using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RequestServerTime : MonoBehaviour
{
    public TextMeshProUGUI dateTimeOutputText;
    public string serverIp = "127.0.0.1";
    public int serverPort = 44444;

    public void SendRequest()
    {
        try
        {
            //Opening the stream
            TcpClient client = new TcpClient(serverIp, serverPort);
            NetworkStream stream = client.GetStream();
            //Reading a first information (welcome) from server 
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string welcomeMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            dateTimeOutputText.text = welcomeMessage;
            //Read dateTime from server
            bytesRead = stream.Read(buffer, 0, buffer.Length);
            //Convert to String and assign to TMPro text to display in UI (dateTimeOutputText)
            string dateTime = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            dateTimeOutputText.text = dateTime;
            
        }
        catch (Exception ex)
        {
            Debug.LogError("An error occurred: " + ex.Message);
        }
    }
}