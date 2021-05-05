using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    [SerializeField] private CircleManager circle;
    [SerializeField] private Animator Animator;
    [SerializeField] private Image CardUI;
    [SerializeField] private Sprite[] Cards;
    public int currentCardIndex = -1;

    private void Start()
    {
        Cards = Resources.LoadAll<Sprite>("StandardDeck");
        SetCardUI();
    }

    public void Count()
    {
        circle.currentPlayer.score++;

        if (circle.IsCircleEnded())
            ChangeCard();
        circle.DisplayNextPlayer();
    }

    public void GiveUp()
    {
        circle.KickPlayer();

        if (circle.IsCircleEnded())
            ChangeCard();
        circle.DisplayNextPlayer();
    }

    private void ChangeCard()
    {
        Animator.SetTrigger("Change");

        //SetCardUI is called after that line in animation
    }

    public void SetCardUI()
    {
        if (currentCardIndex < Cards.Length - 1)
            currentCardIndex++;
        else
            currentCardIndex = 0;

        Sprite nextCard = Cards[currentCardIndex];

        CardUI.sprite = nextCard;
    }
}
