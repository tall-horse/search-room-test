using UnityEngine;

// [ExecuteInEditMode]
public class VerticalBillboard : MonoBehaviour
{
    private Camera target;
    private void Awake()
    {
        target = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform, Vector3.up);
    }
}
