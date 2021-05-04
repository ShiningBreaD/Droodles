using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    [SerializeField] private Animator Animator;
    [SerializeField] private Sprite[] Cards;
    [SerializeField] private Image CardUI;
    private int LastIndex;

    public void ChangeCard()
    {
        Animator.SetTrigger("Change");
    }

    public void SetCardUI() // called only at animation at editor
    {
        Sprite nextCard = Cards[LastIndex];
        
        if (LastIndex < Cards.Length)
            LastIndex++;

        CardUI.sprite = nextCard;
    }
}
