using UnityEngine;

public class CardSlideSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCardSwipe()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
