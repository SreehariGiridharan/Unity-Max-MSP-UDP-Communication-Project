using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public MonoBehaviour scriptToEnable; // Reference to the script you want to enable
    public string targetTag = "Player";  // Tag of the object you want to detect triggers with
    public GameObject Sender;
    private void Start()
    {
        // Ensure the script is disabled at the start
        // scriptToEnable.enabled = false;

       
    // Osc = GetComponent<OscSenderBang>();
    
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Trigger");
        // Check if the object we're triggering with has the correct tag
        if (other.CompareTag(targetTag) )
        {
            OscSenderBang Osc = Sender.GetComponent<OscSenderBang>();
            // Send a bang message using OscSenderBang script
            Osc.SendBang("/p1");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Disable the script when the trigger ends
        if (other.CompareTag(targetTag))
        {
            OscSenderBang Osc = Sender.GetComponent<OscSenderBang>();
            Osc.SendBang("/p1");
        }
    }
}
