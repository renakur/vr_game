using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public void ApplyDamage()
    {
        Transform rootTarget = transform;
        while (rootTarget.parent != null && rootTarget.parent.GetComponent<ShieldSpawner>() == null)
        {
            rootTarget = rootTarget.parent;
        }

        Destroy(rootTarget.gameObject);
    }
}
