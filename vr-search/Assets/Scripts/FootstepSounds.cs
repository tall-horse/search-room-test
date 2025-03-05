using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;

public class FootstepSoundsVR : MonoBehaviour
{
    public AudioClip[] footstepSounds; // Array to hold the different footstep sound clips
    public float stepInterval = 0.5f; // How often to play footsteps (in seconds)
    public float minPitch = 0.9f; // Minimum random pitch
    public float maxPitch = 1.1f; // Maximum random pitch
    public float minVolume = 0.3f; // Minimum volume
    public float maxVolume = 0.6f; // Maximum volume

    private AudioSource audioSource; // AudioSource component
    private XROrigin xrOrigin; // Reference to the XR Origin (player body)
    private Vector3 lastPosition; // Position of the XR Origin in the last frame
    private float lastStepTime = 0f; // Time since the last footstep sound
    private float velocityThreshold = 0.05f; // Minimum movement speed to trigger footsteps

    void Start()
    {
        // Get required components
        audioSource = GetComponent<AudioSource>();
        xrOrigin = GetComponentInParent<XROrigin>();
        lastPosition = xrOrigin.transform.position;
    }

    void Update()
    {
        // Calculate the distance moved by the XR Origin (player body)
        float distanceMoved = Vector3.Distance(xrOrigin.transform.position, lastPosition);

        // Only trigger footsteps if the player is moving
        if (distanceMoved > velocityThreshold)
        {
            // Time interval between footsteps
            if (Time.time - lastStepTime >= stepInterval)
            {
                PlayFootstepSound();
                lastStepTime = Time.time;
            }
        }

        // Update the last position
        lastPosition = xrOrigin.transform.position;
    }

    void PlayFootstepSound()
    {
        // Randomly choose a footstep sound from the array
        AudioClip randomFootstep = footstepSounds[Random.Range(0, footstepSounds.Length)];

        // Randomize the pitch and volume to make the footsteps feel more varied
        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.volume = Random.Range(minVolume, maxVolume);

        // Play the random footstep sound
        audioSource.PlayOneShot(randomFootstep);
    }
}
