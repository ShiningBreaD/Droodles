using UnityEngine;
using UnityEngine.Purchasing;

public class PurchasesManager : MonoBehaviour
{
    private static CodelessIAPStoreListener iapListener;
    [SerializeField] private Purchasable[] products;
    private bool hasPurchasesRestored;

    private void Awake()
    {
        iapListener = CodelessIAPStoreListener.Instance;
    }

    private void Update()
    {
        if (!hasPurchasesRestored && CodelessIAPStoreListener.initializationComplete)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (CheckPurchaseState(products[i].ProductID))
                    products[i].OnPurchaseComplete();
            }

            hasPurchasesRestored = true;
        }
    }

    public static bool CheckPurchaseState(string id)
    {
        Debug.Log("Checking purshase state of " + id);

        if (SecuredPlayerPrefs.GetString(id) == B64X.Encode("owned"))
        {
            Debug.Log("Product " + id + " purchase state : true (PlayerPrefs)");
            return true;
        }

        if (iapListener == null)
        {
            Debug.Log("ERROR : iapListener is equals null");
            return false;
        }

        if (iapListener.StoreController == null)
        {
            Debug.Log("ERROR : StoreController is equals null");
            return false;
        }

        if (iapListener.StoreController.products == null)
        {
            Debug.Log("ERROR : There are no products");
            return false;
        }

        Product product = iapListener.GetProduct(id);

        if (product == null)
        {
            Debug.Log("ERROR : product " + id + " is equals null");
        }

        if (product.hasReceipt)
        {
            Debug.Log("Product " + id + " HAVE receipt");
            return true;
        }

        Debug.Log("Product " + id + " HAVE NOT receipt");
        return false;
    }
}
