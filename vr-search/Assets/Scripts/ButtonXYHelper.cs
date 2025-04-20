using UnityEngine;

public class ButtonXYHelper : MonoBehaviour
{
    private Transform initialTransform;
    private float initialXPosition;
    private float initialYPosition;
    private Rigidbody doorRb;
    private void Awake()
    {
        initialTransform = GetComponent<Transform>();
        doorRb = GetComponentInParent<HingeJoint>().gameObject.GetComponent<Rigidbody>();
    }
    void Start()
    {
        initialXPosition = initialTransform.position.x;
        initialYPosition = initialTransform.position.y;
    }
    void Update()
    {
        if (doorRb.isKinematic == false)
            return;
        if (transform.position.y != initialYPosition || transform.position.x != initialXPosition)
        {
            transform.position = new Vector3(initialXPosition, initialYPosition, transform.position.z);
        }
    }
}
