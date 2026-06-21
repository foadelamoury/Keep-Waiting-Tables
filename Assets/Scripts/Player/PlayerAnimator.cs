using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;


    [SerializeField] PlayerController playerController;

    const string IS_WALKING = "IsWalking";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {

        animator.SetBool(IS_WALKING, playerController.IsWalking());
    }
}
