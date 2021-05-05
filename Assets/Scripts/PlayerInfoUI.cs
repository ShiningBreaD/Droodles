using UnityEngine;
using TMPro;

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField] new private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI score;

    public void SetUp(Player player)
    {
        name.text = player.name;
        score.text = player.score.ToString();
    }
}
