using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class UdpReceiver : MonoBehaviour
{
    private UdpClient udpClient;
    private Thread receiveThread;
    private bool isReceiving = true;
    public GameObject light;
    public bool LightOn=true;

    void Start()
    {
        // Initialize and start the UDP receiver
        udpClient = new UdpClient(8000);
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
        Debug.Log("UDP Receiver started on port 8000");
        
        
    }
   
    void Update()
    {
        if (LightOn)
        {
            light.SetActive(true);
            
        }
        else
        {
            light.SetActive(false);
        }
    }

    void ReceiveData()
    {
        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 8000);

        try
        {
            while (isReceiving)
            {
                // Wait for a message to be received
                byte[] receivedBytes = udpClient.Receive(ref remoteEndPoint);
                
                // Convert the received bytes to a string
                string receivedText = Encoding.UTF8.GetString(receivedBytes);
                
                // Print the received message to the console
                Debug.Log("Received message: " + receivedText);
                LightOn=!LightOn;
                
            }
        }
        catch (SocketException ex)
        {
            Debug.LogError("SocketException: " + ex.Message);
        }
        finally
        {
            udpClient.Close();
        }
    }

    void OnDestroy()
    {
        // Stop receiving and clean up
        isReceiving = false;
        if (receiveThread != null)
        {
            receiveThread.Abort();
            receiveThread = null;
        }
        if (udpClient != null)
        {
            udpClient.Close();
            udpClient = null;
        }
        Debug.Log("UDP Receiver stopped");
    }
}
