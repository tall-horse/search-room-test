using UnityEngine;
[ExecuteInEditMode]
public class TwoPointsLine : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    private LineRenderer line;
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }
    void Start()
    {
        line.positionCount = 2;
    }
    void Update()
    {
        line.SetPosition(0, pointA.position);
        line.SetPosition(1, pointB.position);
    }
}
