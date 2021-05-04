using UnityEngine;
using TMPro;

public class MascotsThoughts : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayedThought;
    [SerializeField] private string[] thoughts;

    private void Start()
    {
        if (thoughts.Length == 0) return;
        displayedThought.text = thoughts[Random.Range(0, thoughts.Length)];
    }
}
