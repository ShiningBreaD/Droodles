using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class DeckSelectionManager : MonoBehaviour
{
    public static DeckSelectionManager Instance { get; set; }
    public Deck SelectedDeck => avaliableDecks[currentDeckIndex];

    [SerializeField] private List<Deck> avaliableDecks;
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

    private void Start()
    {
        if (avaliableDecks.Count > 1)
            nextButton.enabled = true;
    }

    public void AddDeck(Deck deck)
    {
        avaliableDecks.Add(deck);

        if (!nextButton.enabled)
            nextButton.enabled = true;
    }

    public void ShowNextDeck()
    {
        if (!previousButton.enabled)
            previousButton.enabled = true;

        Deck deck = avaliableDecks[++currentDeckIndex];
        deckName.text = deck.name;
        deckIcon.sprite = deck.icon;

        if (currentDeckIndex == avaliableDecks.Count - 1)
            nextButton.enabled = false;
    }

    public void ShowPreviousDeck()
    {
        if (!nextButton.enabled)
            nextButton.enabled = true;

        Deck deck = avaliableDecks[--currentDeckIndex];
        deckName.text = deck.name;
        deckIcon.sprite = deck.icon;

        if (currentDeckIndex == 0)
            previousButton.enabled = false;
    }
}
