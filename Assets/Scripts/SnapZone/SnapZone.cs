using UnityEngine;
using Valve.VR.InteractionSystem;

public class SnapZone : MonoBehaviour
{
    [SerializeField] private Transform snapAnchor;

    private Interactable currentOverlappingItem;
    private Interactable snappedItem;

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Interactable>(out var interactable))
        {
            if (snappedItem == null)
            {
                currentOverlappingItem = interactable;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Interactable>(out var interactable))
        {
            if (currentOverlappingItem == interactable)
            {
                currentOverlappingItem = null;
            }
        }
    }

    private void Update()
    {
        if (currentOverlappingItem != null && currentOverlappingItem.attachedToHand == null)
        {
            SnapObject(currentOverlappingItem);
        }

        if (snappedItem != null && snappedItem.attachedToHand != null)
        {
            UnsnapObject();
        }
    }

    private void SnapObject(Interactable item)
    {
        if (item.TryGetComponent<Rigidbody>(out var rb))
        {
            rb.isKinematic = true;
        }

        if (item.TryGetComponent<Collider>(out var collider))
        {
            collider.enabled = false;
        }

        item.transform.position = snapAnchor.position;
        item.transform.rotation = snapAnchor.rotation;

        item.transform.SetParent(snapAnchor);

        currentOverlappingItem = null;
    }

    private void UnsnapObject()
    {
        if (snappedItem.TryGetComponent<Rigidbody>(out var rb))
        {
            rb.isKinematic = false;
        }

        if (snappedItem.TryGetComponent<Collider>(out var collider))
        {
            collider.isTrigger = false;
        }

        snappedItem.transform.SetParent(null);

        snappedItem = null;
    }
}
