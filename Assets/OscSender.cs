using OscJack;
using UnityEngine;

public class OscSender : MonoBehaviour
{
    OscClient client;

    // Public variable to hold the text message to be sent
    public string messageToSend = "hi";

    void Start()
    {
        // Initialize the OSC client
        client = new OscClient("127.0.0.1", 7000);
    }

    void Update()
    {
        // Check if the "S" key is pressed
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Send the OSC message when "S" is pressed
            SendOscMessage("", messageToSend);
        }
    }

    void SendOscMessage(string address, string message)
    {
        // Send the message with a specific OSC address
        client.Send(address, message);
        Debug.Log("OSC message sent: " + address + " " + message);
    }

    void OnDestroy()
    {
        // Close the OSC client when done
        client.Dispose();
    }
}
