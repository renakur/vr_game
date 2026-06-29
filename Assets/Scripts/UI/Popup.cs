using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static LightCatcher;

public class Popup : MonoBehaviour
{
    public static Popup Instance { get; private set; }
    public Button button;
    public GameObject popup;
    //[SerializeField] private List<Popups> popupsList;
    public bool _startMinigame  = false;

    [System.Serializable]
    public struct Popups
    {
        public string popupName;
        public GameObject popup;
       
    }

    public void Awake()
    {
        if (Instance == null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        _startMinigame = false;
    }

    public void ShowPopup()
    {
        if (popup != null)
        {
           popup.SetActive(true); 
        }

    }


    public void HidePopup()
    {
        if (popup != null)
        {
            popup.SetActive(false);
        }
    }

    public void StartMinigame()
    {
        button.onClick.AddListener(HidePopup);

        _startMinigame = true;
    }

}
