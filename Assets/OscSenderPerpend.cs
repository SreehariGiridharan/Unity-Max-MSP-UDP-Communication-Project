using OscJack;
using UnityEngine;

public class OscSenderPerpend : MonoBehaviour
{
    OscClient client;

    void Start()
    {
        // Initialize the OSC client, sending to localhost on port 9000
        client = new OscClient("127.0.0.1", 9000);
        SendMessageToMax("/p1", 5000);
        
       
        SendMessageToMax("/p2", 3000);
       
        
        SendMessageToMax("/p3", 7000);
    }

    void Update()
    {
        
        
            
        
    }

    void SendMessageToMax(string address, int value)
    {
        // Send the OSC message with a specific address and value
        client.Send(address, value);
        Debug.Log($"OSC message sent: {address} {value}");
    }

    void OnDestroy()
    {
        // Close the OSC client when done
        client.Dispose();
    }
}
