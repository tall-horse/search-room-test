using UnityEngine;

public class Key : MonoBehaviour
{
    private const string HasTurned = "HasTurned";
    private Animator animator;
    private Collider keyCollider;
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