using UnityEngine;

public class AdjustCenterOfMass : MonoBehaviour
{
    [SerializeField] private Transform centerOfMass;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        rb.centerOfMass = new Vector3(centerOfMass.position.x, centerOfMass.position.y, centerOfMass.position.z);
    }
}
