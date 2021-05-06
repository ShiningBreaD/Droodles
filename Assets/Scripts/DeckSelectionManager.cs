using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeckSelectionManager : MonoBehaviour
{
    public static DeckSelectionManager Instance { get; set; }
    public Deck SelectedDeck => avaliableDecks[currentDeckIndex];

    public Deck[] avaliableDecks;
    private int currentDeckIndex;

    [SerializeField] private TextMeshProUGUI deckName;
    [SerializeField] private Image deckIcon;
    [SerializeField] private Image nextButton;
    [SerializeField] private Image previousButton;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(Instance);
    }

    public void ShowNextDeck()
    {
        if (previousButton.enabled == false)
            previousButton.enabled = true;

        Deck deck = avaliableDecks[++currentDeckIndex];
        deckName.text = deck.name;
        deckIcon.sprite = deck.icon;

        if (currentDeckIndex == avaliableDecks.Length - 1)
            nextButton.enabled = false;
    }

    public void ShowPreviousDeck()
    {
        if (nextButton.enabled == false)
            nextButton.enabled = true;

        Deck deck = avaliableDecks[--currentDeckIndex];
        deckName.text = deck.name;
        deckIcon.sprite = deck.icon;

        if (currentDeckIndex == 0)
            previousButton.enabled = false;
    }
}
