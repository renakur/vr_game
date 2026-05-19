using System.Collections.Generic;
using UnityEngine;

public class DoorVisuals : MonoBehaviour
{
    [SerializeField] private List<Animator> animators = new List<Animator>();

    public static DoorVisuals Instance { get; private set; }

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
        //animator.SetTrigger("OpenDoor");

        foreach (var animator in animators)
        {
            animator.SetTrigger("OpenDoor");
        }

    }
}
