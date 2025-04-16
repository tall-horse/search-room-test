using UnityEngine;

public class TeleportReticleOffset : MonoBehaviour
{
    [Tooltip("Offset applied to the child visual to correct for sphere cast radius.")]
    public float verticalOffset = 0.25f;

    [SerializeField] private Transform visual;

    void Awake()
    {
        if (transform.childCount > 0)
            visual = transform.GetChild(0);
    }

    void LateUpdate()
    {
        if (visual != null)
        {
            visual.localPosition = new Vector3(0f, -verticalOffset, 0f);
        }
    }
}
