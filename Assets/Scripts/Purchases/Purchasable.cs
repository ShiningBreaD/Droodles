using UnityEngine;
using UnityEngine.Purchasing;

public abstract class Purchasable : MonoBehaviour
{
    [SerializeField] protected string productId;
    public string ProductID
    {
        get
        {
            return productId;
        }
    }

    public abstract void OnPurchaseComplete();

    protected void OnPurchaseFailure(Product product, PurchaseFailureReason failureReason)
    {
        Debug.LogError("Purchase of product: " + product.definition.id + " failed because " + failureReason);
    }
}
