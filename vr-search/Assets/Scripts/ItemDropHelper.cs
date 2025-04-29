using UnityEngine;

public class ItemDropHelper : MonoBehaviour
{
    private Transform originalTransform;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Rigidbody itemRigidbody;
    private void Awake()
    {
        originalTransform = GetComponent<Transform>();
        itemRigidbody = GetComponent<Rigidbody>();
        originalPosition = originalTransform.position;
        originalRotation = originalTransform.rotation;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<DroppedItemArea>() == true)
        {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
            itemRigidbody.linearVelocity = Vector3.zero;
            itemRigidbody.angularVelocity = Vector3.zero;
        }
    }

}
