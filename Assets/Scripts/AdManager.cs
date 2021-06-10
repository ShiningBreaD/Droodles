using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Purchasing;

public class AdManager : MonoBehaviour
{
    public static AdManager Instance { get; set; }
    public bool isAdsDisabled { get; set; }

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(Instance);

        if (Advertisement.isSupported)
            Advertisement.Initialize("4118703", false);
    }

    public void ShowAd()
    {
        if (!isAdsDisabled && Advertisement.IsReady())
            Advertisement.Show("Interstitial_Android");
    }

    public void OnDisableAdsFailure(Product product, PurchaseFailureReason failureReason)
    {
        Debug.LogError("Purchase of product: " + product.definition.id + " failed because " + failureReason);
    }
}
