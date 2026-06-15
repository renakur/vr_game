using UnityEngine;

public class Popup : MonoBehaviour
{
    public static Popup Instance { get; private set; }

    public GameObject infoPopupCanvas;

    public void Awake()
    {
        if (Instance == null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    public void ClosePopup()
    {
        if (infoPopupCanvas != null)
        {
            infoPopupCanvas.SetActive(false); 
        }

    }
}
