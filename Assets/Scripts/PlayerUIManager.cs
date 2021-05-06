using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private GameObject playerFieldInput;
    [SerializeField] private Transform parentForPlayerFieldInput;

    private void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            CreatePlayerAndItsUI().DisableDeleteButton();
        }
    }

    public PlayerInputField CreatePlayerAndItsUI()
    {
        PlayerInputField playerUI = Instantiate(playerFieldInput, parentForPlayerFieldInput).GetComponent<PlayerInputField>();
        PlayerManager.Instance.AddPlayer(playerUI.player);
        return playerUI;
    }

    public void DeletePlayerAndItsUI(PlayerInputField playerUI)
    {
        PlayerManager.Instance.RemovePlayer(playerUI.player);
        Destroy(playerUI.gameObject);
    }
}
