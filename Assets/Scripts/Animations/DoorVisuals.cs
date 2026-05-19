using System.Collections.Generic;
using UnityEngine;

public class DoorVisuals : MonoBehaviour
{
    [SerializeField] private List<Animator> animators = new List<Animator>();

    
    public void StartAnimation()
    {
        //animator.SetTrigger("OpenDoor");

        foreach (var animator in animators)
        {
            animator.SetTrigger("OpenDoor");
        }

    }
}
