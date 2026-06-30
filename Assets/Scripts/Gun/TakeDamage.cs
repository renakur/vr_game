using UnityEngine;
using FMODUnity;

public class TakeDamage : MonoBehaviour

{
    [Header("hit sound")]
    public EventReference hitSound;
    public void ApplyDamage()
    {

        if (!hitSound.IsNull)
        {
            RuntimeManager.PlayOneShot(hitSound, transform.position);
        }

        Transform rootTarget = transform;
        while (rootTarget.parent != null && rootTarget.parent.GetComponent<ShieldSpawner>() == null)
        {
            rootTarget = rootTarget.parent;
        }

        Destroy(rootTarget.gameObject);
    }
}
