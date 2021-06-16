using UnityEngine;

public class BuyDeck : Purchasable
{
    [SerializeField] private Deck buyableDeck;

    public override void OnPurchaseComplete()
    {
        DeckSelectionManager.Instance.AddDeck(buyableDeck);

        SecuredPlayerPrefs.SetString(productId, "owned");
        Destroy(gameObject);
    }
}
