using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        PressButton();
    }
    public void PressButton()
    {
        if (DoorVisuals.Instance != null)
        {
            DoorVisuals.Instance.StartAnimation();
        }
        else
        {
            Debug.LogError("[QUEST] null");
        }


    }



}
