using UnityEngine;
using TMPro;

public class CircleManager : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    private int currentPlayerIndex;
    public Player currentPlayer => PlayerManager.Instance.ReturnPlayer(currentPlayerIndex);

    private void Start()
    {
        if (PlayerManager.Instance != null)
        {
            DisplayNextPlayer(0);
        }
    }

    public void DisplayNextPlayer()
    {
        Player player = PlayerManager.Instance.ReturnPlayer(currentPlayerIndex);

        if (player.isLost)
        {
            DisplayNextPlayer();
            return;
        }

        playerName.text = player.name;
    }

    private void DisplayNextPlayer(int index)
    {
        Player player = PlayerManager.Instance.ReturnPlayer(index);
        playerName.text = player.name;
    }

    public void KickPlayer()
    {
        PlayerManager.Instance.ReturnPlayer(currentPlayerIndex).isLost = true;
    }

    public bool IsCircleEnded()
    {
        if (currentPlayerIndex == PlayerManager.Instance.ReturnLength()-1)
        {
            currentPlayerIndex = 0;
            return true;
        }

        currentPlayerIndex++;
        return false;
    }
}
