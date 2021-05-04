using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private GameObject playerFieldInput;
    [SerializeField] private Transform parentForPlayerFieldInput;

    public void CreatePlayerAndItsUI()
    {
        Player player = Instantiate(playerFieldInput, parentForPlayerFieldInput).GetComponent<Player>();
        PlayerManager.Instance.AddPlayer(player);
    }
}
