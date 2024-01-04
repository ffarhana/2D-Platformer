// BossAnimationController.cs

using UnityEngine;

public class BossAnimationController : MonoBehaviour
{
    private Animator animator;
    private BossController bossController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        bossController = GetComponent<BossController>();
    }

    private void Update()
    {
        // Check if the boss is shooting to trigger the shooting animation
        if (bossController.IsShooting)
        {
            animator.SetTrigger("Shoot");
        }
    }
}
