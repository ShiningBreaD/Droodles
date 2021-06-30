using UnityEngine;
using UnityEngine.Advertisements;


public class AdManager : MonoBehaviour
{
    public static AdManager Instance { get; set; }
    public bool IsAdsDisabled { get; set; }

    private void Awake()
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
        if (!IsAdsDisabled && Advertisement.IsReady())
            Advertisement.Show("Interstitial_Android");
    }
}
