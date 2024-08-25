using OscJack;
using UnityEngine;

public class OscSenderBang : MonoBehaviour
{
    OscClient client;

    void Start()
    {
        // Initialize the OSC client
        client = new OscClient("127.0.0.1", 5000);
        
    }

    public void SendBang(string bangsignal)
    {
        // Send the bang message with the OSC address "/p1"
        client.Send(bangsignal);
        Debug.Log("OSC bang sent: /p1");
    }

    void OnDestroy()
    {
        // Dispose the OSC client safely if it's initialized
        if (client != null)
        {
            client.Dispose();
            client = null;
        }
    }
}
