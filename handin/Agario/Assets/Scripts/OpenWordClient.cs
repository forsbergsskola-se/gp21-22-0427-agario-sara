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

    private const int serverPort = 44444;

    void Start()
    {
        udpClient = new UdpClient();
        serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), serverPort);
    }

    public void SendWord()
    {
        string word = wordInputField.text;
        Debug.Log("Word collected:"+word);

        // Validate the input word.(is local)
        if (string.IsNullOrEmpty(word) || word.Length > 20 || word.Contains(" "))
        {
            responseText.text = "Invalid word. Please enter a single word (less than 20 characters).";
            return;
        }
        //Prepare collectedWord
        byte[] wordCollectedBytes = Encoding.ASCII.GetBytes(word);

        try
        {
            udpClient.Send(wordCollectedBytes, wordCollectedBytes.Length, serverEndPoint);
            //byte[] responseBytes = udpClient.Receive(ref serverEndPoint);
            string response = Encoding.ASCII.GetString(udpClient.Receive(ref serverEndPoint));
            responseText.text = response;
            //Debug.Log(response);
        }
        catch (Exception e)
        {
            responseText.text = "Error!: " + e.Message;
        }
    }
}