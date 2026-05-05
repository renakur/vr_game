using UnityEngine;
using UnityEngine.Events;

public class KeyboardButton : MonoBehaviour
{
    public int myDigit;
    public bool isPressed = false;
    public UnityEvent<int> OnButtonClicked;

    public void HandleClick()
    {
        OnButtonClicked?.Invoke(myDigit);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            isPressed = true;
            HandleClick();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayersHand"))
        {
            isPressed = false;
        }
    }

    
}
