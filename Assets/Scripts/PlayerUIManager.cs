using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private GameObject playerFieldInput;
    [SerializeField] private Transform parentForPlayerFieldInput;

    private void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            PlayerInputField playerUI = Instantiate(playerFieldInput, parentForPlayerFieldInput).GetComponent<PlayerInputField>();
            playerUI.SetName("Игрок " + (PlayerManager.Instance.ReturnLength() + 1).ToString());
            playerUI.DisableDeleteButton();
            PlayerManager.Instance.AddPlayer(playerUI.player);
        }
    }

    public void CreatePlayerAndItsUI()
    {
        PlayerInputField playerUI = Instantiate(playerFieldInput, parentForPlayerFieldInput).GetComponent<PlayerInputField>();
        playerUI.SetName("Игрок " + (PlayerManager.Instance.ReturnLength() + 1).ToString());
        PlayerManager.Instance.AddPlayer(playerUI.player);
    }

    public void DeletePlayerAndItsUI(PlayerInputField playerUI)
    {
        PlayerManager.Instance.RemovePlayer(playerUI.player);
        Destroy(playerUI.gameObject);
    }
}
