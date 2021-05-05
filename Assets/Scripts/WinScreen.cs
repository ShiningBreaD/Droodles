using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI winner;
    [SerializeField] private GameObject playerInfoUI;
    [SerializeField] private Transform parent;

    public void Show()
    {
        PlayerManager.Instance.SortByScore();
        winner.text = PlayerManager.Instance.ReturnPlayer(0).name;

        for (int i = 0; i < PlayerManager.Instance.ReturnLength(); i++)
            CreatePlayerInfoUI(PlayerManager.Instance.ReturnPlayer(i));

        animator.SetTrigger("Show");
    }

    private void CreatePlayerInfoUI(Player player)
    {
        PlayerInfoUI playerInfo = Instantiate(playerInfoUI, parent).GetComponent<PlayerInfoUI>();
        playerInfo.SetUp(player);
    }
}
