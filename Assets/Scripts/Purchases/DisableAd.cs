using UnityEngine;

public class DisableAd : Purchasable
{
    public override void OnPurchaseComplete()
    {
        AdManager.Instance.isAdsDisabled = true;

        SecuredPlayerPrefs.SetString(productId, "owned");
        Destroy(gameObject);
    }
}
