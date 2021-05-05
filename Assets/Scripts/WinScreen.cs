using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI winner;
    [SerializeField] private GameObject playerInfoUI;
    [SerializeField] private Transform parent;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Show()
    {
        int length = PlayerManager.Instance.ReturnLength();

        PlayerManager.Instance.SortByScore();
        winner.text = PlayerManager.Instance.ReturnPlayer(length - 1).name;

        for (int i = length - 1; i > -1; i--)
            CreatePlayerInfoUI(PlayerManager.Instance.ReturnPlayer(i));

        animator.SetTrigger("Show");
    }

    private void CreatePlayerInfoUI(Player player)
    {
        PlayerInfoUI playerInfo = Instantiate(playerInfoUI, parent).GetComponent<PlayerInfoUI>();
        playerInfo.SetUp(player);
    }
}
