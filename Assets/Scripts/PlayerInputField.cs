using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputField : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputText;
    [SerializeField] private Button deleteButton;
    private PlayerUIManager playerUIManager;
    public Player player = new Player();

    private void Start()
    {
        playerUIManager = GetComponentInParent<PlayerUIManager>();
    }

    public void SetName()
    {
        player.name = inputText.text;
    }

    public void DeletePlayer()
    {
        playerUIManager.DeletePlayerAndItsUI(this);
    }

    public void DisableDeleteButton()
    {
        deleteButton.interactable = false;
    }
}
