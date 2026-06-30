using UnityEngine;
using Valve.VR.InteractionSystem;
using FMODUnity; 


[RequireComponent(typeof(Interactable))]
public class GrabSound : MonoBehaviour
{
    [Header("Звук при взятии")]
    public EventReference pickupSound;

    
    protected virtual void OnAttachedToHand(Hand hand)
    {
        if (!pickupSound.IsNull)
        {
            
            RuntimeManager.PlayOneShot(pickupSound, transform.position);

          
        }
    }

   
    protected virtual void OnDetachedFromHand(Hand hand)
    {
        
    }
    
}