using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class DoorVisuals : MonoBehaviour
{
    [SerializeField] private List<Animator> animators = new List<Animator>();

    public static DoorVisuals Instance { get; private set; }
    public EventReference doorOpenSound;
    public Transform soundPoint;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    public void StartAnimation()
    {
        
        foreach (var animator in animators)
        {
            if (animator != null)
            {
                

                animator.SetTrigger("OpenDoor");

                RuntimeManager.PlayOneShotAttached(doorOpenSound, soundPoint.gameObject);
            }
            else
            {
                Debug.LogWarning("[DoorVisuals]  (null)!");
            }
        }
    }
}
