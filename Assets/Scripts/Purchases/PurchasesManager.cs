using UnityEngine;
using UnityEngine.Purchasing;

public class PurchasesManager : MonoBehaviour
{
    private static CodelessIAPStoreListener iapListener;
    [SerializeField] private Purchasable[] products;

    private void Start()
    {
        iapListener = CodelessIAPStoreListener.Instance;

        for (int i = 0; i < products.Length; i++)
        {
            if (CheckPurchaseState(products[i].ProductID))
                products[i].OnPurchaseComplete();
        }
    }

    public static bool CheckPurchaseState(string id)
    {
        if (PlayerPrefs.GetString(id) == B64X.Encode("owned"))
            return true;

        Product product = iapListener.GetProduct(id);
        if (product.hasReceipt)
            return true;

        return false;
    }
}
