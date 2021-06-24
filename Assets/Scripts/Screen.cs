using System.Collections;
using UnityEngine;

public class Screen : MonoBehaviour
{
    public static bool isAnimationRunning { get; private set; }

    public ExtendedCoroutine ChangeVisibilityCoroutine { get; private set; }

    [SerializeField] private Animator animator;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float speed;

    private void Start()
    {
        ChangeVisibilityCoroutine = new ExtendedCoroutine(this, ChangeVisibility);
    }

    public void ChangeAnimationState()
    {
        animator.SetBool("IsShown", !animator.GetBool("IsShown"));
        //ChangeVisibilityCoroutine.Start();
    }

    public void SetBackButtonEvent(bool shouldBeNull)
    {
        if (!shouldBeNull)
            BackButton.GoBack += ChangeAnimationState;
        else
            BackButton.SetEventNull();
    }

    private IEnumerator ChangeVisibility()
    {
        isAnimationRunning = true;

        float target = canvasGroup.alpha == 1f ? 0f : 1f;

        while (canvasGroup.alpha != target)
        {
            if (canvasGroup.alpha != target)
                canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, target, speed * Time.deltaTime);

            yield return null;
        }

        canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;

        isAnimationRunning = false;
    }
}
