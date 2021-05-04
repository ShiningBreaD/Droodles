using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    [SerializeField] private List<Player> players;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        players.Remove(player);
    }
}
