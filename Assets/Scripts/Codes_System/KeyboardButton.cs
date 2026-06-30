using FMODUnity;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class KeyboardButton : MonoBehaviour
{
    public int myDigit;
    public bool isPressed = false;
    public UnityEvent<int> OnButtonClicked;

    [Header("sound")]
    public EventReference beepSound;

    public void HandleClick()
    {
        OnButtonClicked?.Invoke(myDigit);
        KeycodeValidator.Instance.AddDigit(myDigit);
        Debug.Log("DODAJE LICZBÊ" + myDigit);

        if (!beepSound.IsNull)
        {
            RuntimeManager.PlayOneShot(beepSound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Hand>())
        {
            isPressed = true;
            HandleClick();
            Debug.Log("GRACZ WSZEDL");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Hand>())
        {
            isPressed = false;
            Debug.Log("GRACZ WYSZEDL");
        }
    }

    
}
