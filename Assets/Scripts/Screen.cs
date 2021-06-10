using UnityEngine;

public class Screen : MonoBehaviour
{
    [SerializeField] private Animator Animator;

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }

    public void ChangeAnimationState()
    {
        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
            Animator.SetBool("IsShown", true);
        }
        else
            Animator.SetBool("IsShown", false);

        BackButton.OnGoback = ChangeAnimationState;
    }
}
