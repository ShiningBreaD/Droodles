using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AnimatorPP : MonoBehaviour
{
    public ExtendedCoroutine extendedCoroutine { get; private set; }

    [SerializeField] private bool loopAnimation;

    [SerializeField] private float speed;
    private float delay;

    private Sprite[] sprites;
    [SerializeField] private Image image;
    [SerializeField] private string pathToResources;

    private void Start()
    {
        SetDelay(speed);

        LoadSpritesFromResources(pathToResources);

        extendedCoroutine = new ExtendedCoroutine(this, Animate);
        extendedCoroutine.Start();

        if (loopAnimation)
            extendedCoroutine.OnFinished += extendedCoroutine.Start;
    }

    private IEnumerator Animate()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            image.sprite = sprites[i];

            yield return new WaitForSeconds(delay);
        }
    }

    private void SetDelay(float speed)
    {
        if (speed <= 0)
            throw new ArgumentOutOfRangeException("Animation speed");

        delay = speed / (speed * speed);
    }

    private void LoadSpritesFromResources(string path)
    {
        if (path == "" || path == null)
            throw new ArgumentOutOfRangeException("Path to resources");

        sprites = Resources.LoadAll<Sprite>(path);
    }
}
