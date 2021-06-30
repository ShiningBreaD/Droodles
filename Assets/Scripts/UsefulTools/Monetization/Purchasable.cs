using UnityEngine;
using UnityEngine.Purchasing;

public abstract class Purchasable : MonoBehaviour
{
    protected string productId;
    public string ProductID
    {
        get
        {
            if (productId == default)
                productId = GetComponent<IAPButton>().productId;

            return productId;
        }
    }

    public abstract void OnPurchaseComplete();

    public void OnPurchaseFailure(Product product, PurchaseFailureReason failureReason)
    {
        Debug.LogError("Purchase of product: " + product.definition.id + " failed because " + failureReason);
    }
}
