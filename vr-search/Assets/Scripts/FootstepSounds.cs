using Unity.XR.CoreUtils;
using UnityEngine;

public class FootstepSoundsVR : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    public float stepInterval = 0.5f;
    public float minPitch = 0.9f;
    public float maxPitch = 1.1f;
    public float minVolume = 0.3f;
    public float maxVolume = 0.6f;

    private AudioSource audioSource;
    private XROrigin xrOrigin;
    private Vector3 lastPosition;
    private float lastStepTime = 0f;
    private float velocityThreshold = 0.02f;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        xrOrigin = GetComponentInParent<XROrigin>();
        lastPosition = xrOrigin.transform.position;
    }

    void Update()
    {
        float distanceMoved = Vector3.Distance(xrOrigin.transform.position, lastPosition);

        if (distanceMoved > velocityThreshold)
        {
            if (Time.time - lastStepTime >= stepInterval)
            {
                PlayFootstepSound();
                lastStepTime = Time.time;
            }
        }
        lastPosition = xrOrigin.transform.position;
    }

    void PlayFootstepSound()
    {
        AudioClip randomFootstep = footstepSounds[Random.Range(0, footstepSounds.Length)];

        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.volume = Random.Range(minVolume, maxVolume);

        audioSource.PlayOneShot(randomFootstep);
    }
}
