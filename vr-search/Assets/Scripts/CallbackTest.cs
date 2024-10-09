using System;
using UnityEngine;

public class CallbackTest : MonoBehaviour
{
    public Action OnGrabbed;
    public Action OnDropped;
    public void OnObjectHovered()
    {
        Debug.Log("Object hovered");
    }
    public void OnObjectUnhovered()
    {
        Debug.Log("Object not hovered");
    }
    public void OnObjectGrabbed()
    {
        OnGrabbed?.Invoke();
    }
    public void OnObjectDropped()
    {
        OnDropped?.Invoke();
    }

}
