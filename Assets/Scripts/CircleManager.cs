using UnityEngine;
using TMPro;

public class CircleManager : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    public TextMeshProUGUI playerName;
    private int currentPlayerIndex;
    public Player currentPlayer => PlayerManager.Instance.ReturnPlayer(currentPlayerIndex);
    public int playersInGame;

    private void Start()
    {
        if (PlayerManager.Instance != null)
        {
            DisplayNextPlayer(0);
            playersInGame = PlayerManager.Instance.ReturnLength();
        }
    }

    public void DisplayNextPlayer()
    {
        Player player = PlayerManager.Instance.ReturnPlayer(currentPlayerIndex);

        if (player.isLost)
        {
            IsCircleEnded();
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
        currentPlayer.isLost = true;
        
        playersInGame--;
        if (playersInGame == 1)
        {
            currentPlayer.score++;
            winScreen.SetActive(true);
            winScreen.GetComponent<WinScreen>().Show();
        }
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
