using UnityEngine;

public class KeyActivator : MonoBehaviour
{
    public void RemoveKey()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
