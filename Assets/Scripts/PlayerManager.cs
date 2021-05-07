using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; set; }
    public Slider timer;
    public int timeInSeconds;
    private List<Player> players = new List<Player>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(Instance);
    }

    public void SortByScore()
    {
        players.Sort();
    }

    public void LoadGame()
    {
        timeInSeconds = Mathf.RoundToInt(timer.value);
        SceneManager.LoadScene(1);
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void AddPlayer(int index)
    {
        Player player = players[index];
        players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        players.Remove(player);
    }

    public void RemovePlayer(int index)
    {
        Player player = players[index];
        players.Remove(player);
    }

    public Player ReturnPlayer(int index)
    {
        return players[index];
    }

    public int ReturnLength()
    {
        return players.Count;
    }
}
