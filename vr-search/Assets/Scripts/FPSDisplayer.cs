using TMPro;
using UnityEngine;

public class FPSDisplayer : MonoBehaviour
{
    private TextMeshProUGUI fpsText;
    private float deltaTime = 0.0f;

    void Start()
    {
        Unity.XR.Oculus.Performance.TrySetDisplayRefreshRate(120f);
        // Get the TextMeshProUGUI component attached to this game object
        fpsText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Calculate the frame time
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        // Calculate frames per second
        int fps = Mathf.RoundToInt(1.0f / deltaTime);

        // Update the text display with current fps
        fpsText.text = "FPS: " + fps.ToString();
    }
}
