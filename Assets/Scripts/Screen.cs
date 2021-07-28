using System.Collections;
using UnityEngine;

public class Screen : MonoBehaviour
{
    public static bool isAnimationRunning { get; private set; }

    public ExtendedCoroutine ChangeVisibilityCoroutine { get; private set; }

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float speed;

    private void Awake()
    {
        ChangeVisibilityCoroutine = new ExtendedCoroutine(this, ChangeVisibility);
    }

    public void ChangeAnimationState()
    {
        ChangeVisibilityCoroutine.Start();
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

        bool isVisible = canvasGroup.alpha == 1f;
        float target = isVisible ? 0f : 1f;
        
        Vector2 targetScale = isVisible ? canvasGroup.transform.localScale * 1.2f : canvasGroup.transform.localScale / 1.2f;

        while (canvasGroup.alpha != target)
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, target, speed * Time.deltaTime);
            canvasGroup.transform.localScale = Vector2.MoveTowards(canvasGroup.transform.localScale, targetScale, speed / 2 * Time.deltaTime);

            yield return null;
        }

        canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;

        isAnimationRunning = false;
    }
}
