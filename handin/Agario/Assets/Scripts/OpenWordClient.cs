using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;


public class OpenWordClient : MonoBehaviour
{
    public TMP_InputField wordInputField;
    public TextMeshProUGUI responseText;

    private UdpClient udpClient;
    private IPEndPoint serverEndPoint;

    private const int serverPort = 44444;  // Use the appropriate port for your Open Word MMO server.

    void Start()
    {
        udpClient = new UdpClient();
        serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), serverPort); // Set the server's IP address.

        // Hook up the Send Button's onClick event to your SendWord method.
        Button sendButton = GetComponent<Button>();
        sendButton.onClick.AddListener(SendWord);
    }

    public void SendWord()
    {
        string word = wordInputField.text;

        // Validate the input word.
        if (string.IsNullOrEmpty(word) || word.Length > 20 || word.Contains(" "))
        {
            responseText.text = "Invalid word. Please enter a single word (less than 20 characters).";
            return;
        }

        byte[] wordBytes = Encoding.ASCII.GetBytes(word);

        try
        {
            udpClient.Send(wordBytes, wordBytes.Length, serverEndPoint);
            //byte[] responseBytes = udpClient.Receive(ref serverEndPoint);
            string response = Encoding.ASCII.GetString(udpClient.Receive(ref serverEndPoint));
            responseText.text = response;
            Debug.Log(response);
        }
        catch (Exception e)
        {
            responseText.text = "Error: " + e.Message;
        }
    }
}