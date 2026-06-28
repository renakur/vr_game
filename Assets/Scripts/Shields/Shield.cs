using System;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Action OnShieldDestroyed;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        
        animator.Play("ShieldAppear");
    }

    void OnDestroy()
    {
        OnShieldDestroyed?.Invoke();
    }
}
