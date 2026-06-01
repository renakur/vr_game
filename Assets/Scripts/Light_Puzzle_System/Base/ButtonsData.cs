using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ButtonsData : MonoBehaviour
{
    [SerializeField] private List<LightsButtons> lightsButtons;

    [System.Serializable]
    public struct LightsButtons
    {
        public string name;
        public GameObject lightButton;
    }
}
