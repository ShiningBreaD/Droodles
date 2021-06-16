using UnityEngine;
using TMPro;

public class EmptyStoreHandler : MonoBehaviour
{
    [SerializeField] private Transform products;
    [SerializeField] private GameObject mascot;
    [SerializeField] private TextMeshProUGUI displayedThought;

    private void Update()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            products.gameObject.SetActive(false);
            ShowMascot("Нет подключения к интернету!");
        }
        else if (!products.gameObject.activeSelf)
            HideMascot();

        CheckProducts();
    }

    public void CheckProducts()
    {
        if (products.childCount == 0)
            ShowMascot("Спасибо, что купили всё!");
    }

    private void ShowMascot(string thought)
    {
        displayedThought.text = thought;
        mascot.SetActive(true);
    }

    private void HideMascot()
    {
        mascot.SetActive(false);
        products.gameObject.SetActive(true);
    }
}
