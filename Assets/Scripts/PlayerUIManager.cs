using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private GameObject playerFieldInput;
    [SerializeField] private Transform parentForPlayerFieldInput;

    public void CreatePlayerAndItsUI()
    {
        Player player = Instantiate(playerFieldInput, parentForPlayerFieldInput).GetComponent<PlayerInputField>().player;
        PlayerManager.Instance.AddPlayer(player);
    }

    public void DeletePlayerAndItsUI(PlayerInputField playerUI)
    {
        PlayerManager.Instance.RemovePlayer(playerUI.player);
        Destroy(playerUI.gameObject);
    }
}
