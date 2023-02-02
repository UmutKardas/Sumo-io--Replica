using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;


    public void SetPlayerDance()
    {
        playerAnimator.SetBool("Dance", true);
    }
}
