using UnityEngine;
using Valve.VR.InteractionSystem;
using FMODUnity;

public class VRButtonSound : MonoBehaviour
{
    [Header("press sound")]
    public EventReference pressSound;

    private bool isPressed = false;

    private void OnTriggerEnter(Collider other)
    {
        
        if (!isPressed && other.GetComponent<Hand>())
        {
            isPressed = true;

            if (!pressSound.IsNull)
            {
               
                RuntimeManager.PlayOneShot(pressSound);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (isPressed && other.GetComponent<Hand>())
        {
            isPressed = false;
        }
    }
}