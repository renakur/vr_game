using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Gun : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAction;
    public GameObject bullet;
    public Transform barrelPivot;
    public float shootingSpeed = 1f;
    public GameObject muzzleFlash;

    private Animator animator;
    private Interactable interactable;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        interactable = GetComponent<Interactable>();
        muzzleFlash.SetActive(false);
    }

    private void Update()
    {
        if(interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;

            if (fireAction[source].stateDown)
            {
                Fire();
            }
        }
    }



    private void Fire()
    {
        Rigidbody bulletrb = Instantiate(bullet, barrelPivot.position, barrelPivot.rotation).GetComponent<Rigidbody>();
        bulletrb.angularVelocity = barrelPivot.forward * shootingSpeed;
        muzzleFlash.SetActive(true);
    }
}
