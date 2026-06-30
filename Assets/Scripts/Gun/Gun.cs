using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using FMODUnity;

public class Gun : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAction;
    public GameObject bullet;
    public Transform barrelPivot;
    public float shootingSpeed = 40f;
    public GameObject muzzleFlash;

    [Header("gunshot sound FMOD")]
    public EventReference fireSound;

    private Interactable interactable;
    private Collider gunCollider;
    private int lastFiredFrame = -1;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        gunCollider = GetComponent<Collider>();

        if (muzzleFlash != null) muzzleFlash.SetActive(false);
    }

    private void Update()
    {
        if(interactable != null && interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;

            if (fireAction != null && fireAction.GetStateDown(source))
            {
                if (Time.frameCount == lastFiredFrame) return;

                lastFiredFrame = Time.frameCount;
                Fire();
            }
        }
    }

    private void Fire()
    {
        if (bullet == null || barrelPivot == null) return;

        GameObject spawnedBullet = Instantiate(bullet, barrelPivot.position, barrelPivot.rotation);
        Rigidbody bulletrb = spawnedBullet.GetComponent<Rigidbody>();
        Collider bulletCollider = spawnedBullet.GetComponent<Collider>();

        if (gunCollider != null && bulletCollider != null)
        {
            Physics.IgnoreCollision(gunCollider, bulletCollider);
        }

        if (bulletrb != null)
        {
            
            bulletrb.linearVelocity = barrelPivot.forward * shootingSpeed;
        }

        if (!fireSound.IsNull)
        {
            
            RuntimeManager.PlayOneShot(fireSound, barrelPivot.position);
        }

        if (muzzleFlash != null)
        {
            muzzleFlash.SetActive(true);
            CancelInvoke("HideMuzzleFlash");
            Invoke("HideMuzzleFlash", 0.05f);
        }

        if (muzzleFlash != null)
        {
            muzzleFlash.SetActive(true);
            CancelInvoke("HideMuzzleFlash");
            Invoke("HideMuzzleFlash", 0.05f);
        }
    }

    private void HideMuzzleFlash()
    {
        if (muzzleFlash != null) muzzleFlash.SetActive(false);
    }
}
