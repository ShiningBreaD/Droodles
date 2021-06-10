using UnityEngine;
using UnityEngine.Purchasing;

public class PurchasesManager : MonoBehaviour
{
    private static CodelessIAPStoreListener iapListener;

    private void Start()
    {
        iapListener = CodelessIAPStoreListener.Instance;
    }

    public static bool CheckPurchaseState(string id)
    {
        Debug.Log("Checking purchase state of " + id);
        if (iapListener == null)
        {
            Debug.LogError("StoreController is equals null");
            return false;
        }

        Product product = iapListener.GetProduct(id);
        if (product == null)
        {
            Debug.LogError("Product " + id + " is equals null");
            return false;
        }

        if (product.hasReceipt)
        {
            Debug.Log("Product " + id + "have receipt");
            return true;
        }
        else
        {
            Debug.Log("Product " + id + "have NOT receipt");
            return false;
        }
    }
}
