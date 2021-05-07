using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    [SerializeField] private CircleManager circle;
    [SerializeField] private Animator Animator;
    [SerializeField] private Image CardUI;
    [SerializeField] private Sprite[] cards;
    [SerializeField] private Image[] cardShirts;
    [SerializeField] private Image header;
    [SerializeField] private TextMeshProUGUI headerTitle;
    [SerializeField] private TextMeshProUGUI headerPlayerName;
    public int currentCardIndex = -1;

    private void Start()
    {

        Deck deck = DeckSelectionManager.Instance.SelectedDeck;

        header.color = deck.headerColor;
        headerTitle.color = deck.titleColor;
        headerPlayerName.color = deck.titleColor;

        for (int i = 0; i < cardShirts.Length; i++)
            cardShirts[i].sprite = deck.icon;
        
        cards = Resources.LoadAll<Sprite>(deck.cardsSpritesPath);
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
        if (currentCardIndex < cards.Length - 1)
            currentCardIndex++;
        else
            currentCardIndex = 0;

        Sprite nextCard = cards[currentCardIndex];

        CardUI.sprite = nextCard;
    }
}
