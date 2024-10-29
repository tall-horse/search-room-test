using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SafeLock : MonoBehaviour
{
    private enum NextTurnDirection
    {
        ANY,
        LEFT, RIGHT
    }
    public UnityEvent OnSafeUnlocked;
    private XRGrabInteractable interactable;
    private AudioSource audioSource;
    [SerializeField] private int[] password;
    private bool isLocked = true;
    private bool isTurning = false;
    private int previousPosition = 0;
    private int currentPosition = 0;
    private int numberOfSteps;
    private int currentStep = 0;
    private NextTurnDirection intendedTurnDirection = NextTurnDirection.ANY;
    private void Awake() {
        interactable = GetComponent<XRGrabInteractable>();
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numberOfSteps = password.Length;
    }
    private void OnEnable()
    {
        interactable.selectEntered.AddListener(OnGrab);
        interactable.selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnGrab);
        interactable.selectExited.RemoveListener(OnRelease);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTurning == false || isLocked == false)
            return;

        currentPosition = Mathf.FloorToInt(transform.rotation.eulerAngles.x / 6);

        if (currentPosition == previousPosition)
            return;
        else
        {
            previousPosition = currentPosition;
            audioSource.Play();
        }

        if (intendedTurnDirection != NextTurnDirection.ANY)
        {
            int difference = currentPosition - previousPosition;
            bool turnDirectionCheck = CheckTurnDirection(difference);
            if(turnDirectionCheck == false)
            {
                ResetLock();
            }
        }
        if (currentPosition == password[currentStep])
        {
            int difference = currentPosition - previousPosition;
            SetTurnDirection(difference);
            if (currentStep + 1 == numberOfSteps)
            {
                isLocked = false;
                OnSafeUnlocked?.Invoke();
            }
            currentStep++;
        }
    }

    private void SetTurnDirection(int difference)
    {
        if (difference > 0)
        {
            intendedTurnDirection = NextTurnDirection.LEFT;
        }
        else
        {
            intendedTurnDirection = NextTurnDirection.RIGHT;
        }
    }

    private bool CheckTurnDirection(int diff)
    {
        if (intendedTurnDirection == NextTurnDirection.ANY)
            return true;
        if (diff > 0 & intendedTurnDirection == NextTurnDirection.RIGHT || diff < 0 & intendedTurnDirection == NextTurnDirection.LEFT)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void ResetLock()
    {
        previousPosition = 0;
        currentPosition = 0;
        currentStep = 0;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void OnGrab(SelectEnterEventArgs arg0)
    {
        isTurning = true;
    }
    private void OnRelease(SelectExitEventArgs arg0)
    {
        isTurning = false;
    }
}
