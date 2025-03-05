using UnityEngine;

public class LightStateController : MonoBehaviour
{
    public bool isOn;
    [SerializeField] private Light refLight;
    private void Start()
    {
        refLight.enabled = isOn;
    }
    public void SwitchLightOn()
    {
        isOn = true;
        refLight.enabled = isOn;
    }
    public void SwitchLightOff()
    {
        isOn = false;
        refLight.enabled = isOn;
    }
    public void SwitchLight()
    {
        isOn = !isOn;
        refLight.enabled = isOn;
    }
}
