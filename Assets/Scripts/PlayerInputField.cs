using TMPro;
using UnityEngine;

public class PlayerInputField : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputText;
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
}
