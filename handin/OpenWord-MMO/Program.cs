using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    private const int PORT = 44444;
    private const byte MAXIMUMWORDLENGTH = 20;
    private const byte WHITESPACEBYTE = 32;

    private static UdpClient? udpClient;

    private static string accumulatedText = "";  // To accumulate and remember the text


    public static void Main(string[] args)
    {
        Console.WriteLine("--------Hello From Server!");
        Console.WriteLine($"--------MMO-Word server running... Listening on port: {PORT}");

        //Initializ the UDP client and bind it to the specified port
        udpClient = new UdpClient(PORT);
            
        //Loop and send a message "accepted" when connection is established
        while (true)
        {
            Console.WriteLine("---||Server Ready and Waiting to receive...");

            //Receive data from a client and get the remote endpoint
            var (receivedBytes, remoteEndPoint) = ReceiveData();

            string receivedWordGeneral = Encoding.ASCII.GetString(receivedBytes);
            Console.WriteLine($"Number of characters of received message: {receivedWordGeneral.Length} ...");


            if (ValidateReceivedMessage(receivedBytes))
            {
                Console.WriteLine("--||Accepted!");

                string receivedWord = Encoding.ASCII.GetString(receivedBytes);
                //Console.WriteLine($"||Received word: {receivedWord}...");
                accumulatedText += " " + receivedWord;
           
                Console.WriteLine("||Received message joined with existing messages");
                SendData(accumulatedText, remoteEndPoint);

            }
        }
    }

    //Receive data from a client and get the remote endpoint
    private static (byte[], IPEndPoint) ReceiveData()
    {
        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
        byte[] receivedBytes = udpClient.Receive(ref remoteEndPoint);
        return (receivedBytes, remoteEndPoint);
    }
    


    //Send data (a response message) to a client at the provided remote endpoint
    private static void SendData(string message, IPEndPoint remoteEndPoint)
    {
        byte[] messageBytes = Encoding.ASCII.GetBytes(message);
        udpClient.Send(messageBytes, messageBytes.Length, remoteEndPoint);
    }

    //Validate the received message
    private static bool ValidateReceivedMessage(byte[] receivedBytes)
    {
        if (receivedBytes.Length == 0)
        {
            SendErrorMessage("//!//Error! Nothing was received!");
            return false;
        }

        if (receivedBytes.Length > MAXIMUMWORDLENGTH)
        {
            SendErrorMessage($"//!// Error! Sent word is too long! Please limit words to {MAXIMUMWORDLENGTH} letters!");
            return false;
        }

        if (Array.IndexOf(receivedBytes, WHITESPACEBYTE) >= 0)
        {
            SendErrorMessage("//!//Error! You are only allowed to send one word at a time. Remember that spaces are banned!");
            return false;
        }

        return true;
    }

    //Send a text error message to the client

    private static void SendErrorMessage(string errorMessage)
    {
        var errorMessageBytes = Encoding.ASCII.GetBytes(errorMessage);
        udpClient.Send(errorMessageBytes, errorMessageBytes.Length, new IPEndPoint(IPAddress.Any, 0));
        Console.WriteLine($"Denied! {errorMessage}");
    }
}