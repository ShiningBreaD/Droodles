using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputField : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button deleteButton;
    private PlayerUIManager playerUIManager;
    public Player player = new Player();

    private void Start()
    {
        playerUIManager = GetComponentInParent<PlayerUIManager>();
    }

    public void SetName(string name)
    {
        inputField.SetTextWithoutNotify(name);
        player.name = name;
    }

    public void SetName()
    {
        if (inputField.text == "")
            inputField.SetTextWithoutNotify(player.name);
        else
            player.name = inputField.text;
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
