using UnityEngine;

public class Key : MonoBehaviour
{
    private const string HasTurned = "HasTurned";
    private Animator animator;
    private Collider keyCollider;
    [field: SerializeField] public GameObject DoorToUnlock { get; private set; }
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        keyCollider = GetComponent<Collider>();
    }
    public void TurnKey()
    {
        animator.SetBool(HasTurned, true);
        keyCollider.enabled = false;
    }
}