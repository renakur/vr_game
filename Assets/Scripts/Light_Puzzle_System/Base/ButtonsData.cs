using System;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ButtonsData : MonoBehaviour
{
    [SerializeField] private List<LightsButtons> lightsButtons;
    [SerializeField] private List<PuzzleLights> lightsScripts;

    public static ButtonsData Instance { get; private set; }

    [System.Serializable]
    public struct LightsButtons
    {
        public string name;
        public GameObject lightButton;
    }

    [System.Serializable]
    public struct PuzzleLights
    {
        public string name;
        public PuzzleLight script;

        internal void LightShowcase()
        {
            throw new NotImplementedException();
        }
    }

    public void Awake()
    {
        if(Instance == null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void LightShowcase(ButtonsData data)
    {
        PuzzleLight light = new PuzzleLight();

        light.LightShowcase();
    }
}
