using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UdpSender : MonoBehaviour
{
    private UdpClient udpClient;

    void Start()
    {
        try
        {
            // Initialize the UdpClient
            udpClient = new UdpClient();
            
            // Connect to the IP and port
            udpClient.Connect("127.0.0.1", 8000);
            Debug.Log("UDP Client connected to 127.0.0.1:8000");
            
            // Send the message
            SendMessage("hi");
        }
        catch (SocketException ex)
        {
            Debug.LogError("SocketException: " + ex.Message);
        }
    }

    void SendMessage(string message)
    {
        try
        {
            // Convert the message to bytes
            byte[] data = Encoding.UTF8.GetBytes(message);

            // Send the data
            udpClient.Send(data, data.Length);
            Debug.Log("Message sent: " + message);
        }
        catch (SocketException ex)
        {
            Debug.LogError("SocketException when sending message: " + ex.Message);
        }
    }

    void OnDestroy()
    {
        // Clean up
        if (udpClient != null)
        {
            udpClient.Close();
            Debug.Log("UDP Client closed");
        }
    }
}
