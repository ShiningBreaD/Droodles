using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputText;
    public new string name;
    public int score;

    public void DeletePlayer()
    {
        PlayerManager.Instance.RemovePlayer(this);
        Destroy(gameObject);
    }

    public void SetName()
    {
        name = inputText.text;
    }

    public void IncreaseScore()
    {
        score++;
    }
}
