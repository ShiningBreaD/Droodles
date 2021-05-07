using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private CircleManager circleManager;
    [SerializeField] private GameControl gameControl;
    [SerializeField] private TextMeshProUGUI title;
    private float timeInSeconds;
    private bool timerActive;

    private void Update()
    {
        if (!timerActive) return;

        timeInSeconds -= Time.deltaTime;
        UpdateText();
        if (timeInSeconds < 0)
        {
            gameControl.GiveUp();
            ResetTimer();
        }
    }

    public void ResetTimer()
    {
        if (PlayerManager.Instance.timeInSeconds == 0f)
        {
            print("Timer == 0");
            return;
        }

        timeInSeconds = PlayerManager.Instance.timeInSeconds;
        UpdateText();

        StartTimer();
    }

    public void UpdateText()
    {
        title.text = Mathf.RoundToInt(timeInSeconds).ToString();
    }

    private void StartTimer()
    {
        timerActive = true;
    }
}
