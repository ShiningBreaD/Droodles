using UnityEngine;
using UnityEngine.Purchasing;

public class DisableAd : MonoBehaviour
{
    private void Start()
    {
        if (PurchasesManager.CheckPurchaseState("remove_ads"))
            OnPurchaseComplete();
    }

    public void OnPurchaseComplete()
    {
        AdManager.Instance.isAdsDisabled = true;
        gameObject.SetActive(false);
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureReason failureReason)
    {
        Debug.LogError("Purchase of product: " + product.definition.id + " failed because " + failureReason);
    }
}
