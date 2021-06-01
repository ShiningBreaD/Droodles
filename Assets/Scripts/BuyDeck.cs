using UnityEngine;
using UnityEngine.Purchasing;

public class BuyDeck : MonoBehaviour
{
    public Deck buyableDeck;

    public void OnPurchaseComplete()
    {
        DeckSelectionManager.Instance.AddDeck(buyableDeck);
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureReason failureReason)
    {
        Debug.LogError("Purchase of product: " + product.definition.id + " failed because " + failureReason);
    }
}
