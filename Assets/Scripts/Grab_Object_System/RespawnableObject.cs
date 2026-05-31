using System.Collections;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class RespawnableObject : MonoBehaviour
{
    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private Interactable _interactable;
    private Rigidbody _rigidbody;

    [SerializeField] private float idleTimeBeforeReset = 5.0f;
    private Coroutine _resetCoroutine;

    void Start()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;

        _interactable = GetComponent<Interactable>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (_resetCoroutine != null && _interactable != null && _interactable.attachedToHand != null)
        {
            StopCoroutine(_resetCoroutine);
            _resetCoroutine = null;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Reset")
        {
            if (_resetCoroutine == null)
            {
                _resetCoroutine = StartCoroutine(WaitForReset());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Reset")
        {
            if (_resetCoroutine == null)
            {
                _resetCoroutine = StartCoroutine(WaitForReset());
            }
        }
    }

    public void ResetPosition()
    {
        if (_interactable != null && _interactable.attachedToHand != null)
        {
            _interactable.attachedToHand.DetachObject(gameObject);
        }

        if (_rigidbody != null)
        {
            _rigidbody.linearVelocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }

        transform.position = _startPosition;
        transform.rotation = _startRotation;

        _resetCoroutine = null;
    }

    public IEnumerator WaitForReset()
    {
        yield return new WaitForSeconds(5.0f);
        ResetPosition();
    }

}
