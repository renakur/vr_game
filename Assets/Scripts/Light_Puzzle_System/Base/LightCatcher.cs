using System.Collections.Generic;
using UnityEngine;

public class LightCatcher : MonoBehaviour
{
    [SerializeField] private List<LightColor> lightColors;

    public static LightCatcher Instance { get; private set; }

    [System.Serializable]
    public struct LightColor
    {
        public LightColors light;
        public PuzzleLight puzzleLight;
        public ButtonTrigger lightButton;
    }

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }
    public void TurnOnLight(LightColors color)
    {
        if (color == LightColors.none)
        {
            return;
        }

        foreach (var element in lightColors)
        {
            if (element.light == color && element.puzzleLight != null)
            {
                element.puzzleLight.LightShowcase();
                break;
            }
        }

    }
    public void ResetAllButtons()
    {
        foreach (var element in lightColors)
        {
            if (element.lightButton != null)
            {
                element.lightButton.ResetButton();
            }
        }
    }

    public bool IsButtonColorPressed(LightColors colorCheck)
    {
        foreach (var element in lightColors)
        {
            if (element.light == colorCheck && element.lightButton != null)
            {
                return element.lightButton.wasLightPressed;
            }
        }
        return false;
    }

    public bool IsAnyLightPlaying()
    {
        foreach (var element in lightColors)
        {
            if (element.puzzleLight != null && element.puzzleLight.IsPlaying)
            {
                return true; 
            }
        }
        return false; 
    }
}
