using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

public class CircleManagerTests
{
    PlayerManager playerManager;
    CircleManager circleManager;
    
    [SetUp]
    public void SetUp()
    {
        playerManager = Object.Instantiate(new GameObject()).AddComponent<PlayerManager>();
        circleManager = Object.Instantiate(new GameObject()).AddComponent<CircleManager>();
        circleManager.playerName = circleManager.gameObject.AddComponent<TextMeshProUGUI>();

        for (int i = 0; i < 3; i++)
        {
            Player player = Object.Instantiate(new GameObject()).AddComponent<PlayerInputField>().player;
            player.name = "Player " + i.ToString();
            playerManager.AddPlayer(player);
        }
    }

    [UnityTest]
    [TestCase()]
    public void CircleManagerTest()
    {
        circleManager.DisplayNextPlayer();
        Assert.That(circleManager.playerName.text, Is.EqualTo(circleManager.currentPlayer.name));

        circleManager.KickPlayer();
        circleManager.DisplayNextPlayer();
        Assert.That(circleManager.playerName.text, Is.EqualTo(circleManager.currentPlayer.name));
    }
}
