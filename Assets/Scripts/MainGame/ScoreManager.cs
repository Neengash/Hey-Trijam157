using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    TextMeshProUGUI text;

    int score;

    private void Awake() {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start() {
        score = 0;
        UpdateScoreValue();
    }

    public void IncreaseScore(int amount) {
        score += amount;
        UpdateScoreValue();
    }

    private void UpdateScoreValue() {
        text.text = string.Format("{0:0000}", score);
    }
}
