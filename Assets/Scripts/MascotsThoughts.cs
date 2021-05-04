using UnityEngine;
using TMPro;

public class MascotsThoughts : MonoBehaviour
{
    public TextMeshProUGUI displayedThought;
    public string[] thoughts;

    private void Start()
    {
        SetThoughtRandomly(
            Random.Range(0, thoughts.Length));
    }

    public void SetThoughtRandomly(int range)
    {
        displayedThought.text = thoughts[range];
    }
}
