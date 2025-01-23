using UnityEngine;

public class ButtonYHelper : MonoBehaviour
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialXPosition = initialTransform.position.x;
        initialYPosition = initialTransform.position.y;
    }

    // Update is called once per frame
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
