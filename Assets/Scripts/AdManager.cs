using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    public static AdManager Instance { get; set; }

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        if (Advertisement.isSupported)
            Advertisement.Initialize("4118703", false);
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
            Advertisement.Show("Interstitial_Android");
    }
}
