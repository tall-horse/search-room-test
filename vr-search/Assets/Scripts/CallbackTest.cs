using UnityEngine;

public class CallbackTest : MonoBehaviour
{
    public void OnObjectHovered()
    {
        Debug.Log("Object hovered");
    }
    public void OnObjectUnhovered()
    {
        Debug.Log("Object not hovered");
    }
    public void OnObjectPicked()
    {
        Debug.Log("Object picked up");
    }

    public void OnObjectDropped()
    {
        Debug.Log("Object dropped");
    }
}
