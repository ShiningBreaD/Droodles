using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerSlider : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Slider slider;

    public void UpdateText()
    {
        float value = slider.value;

        if (value != 9)
            title.text = "Время на ход - " + value.ToString();
        else
            title.text = "Время на ход - нет";
    }
}
