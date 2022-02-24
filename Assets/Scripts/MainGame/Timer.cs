using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float startTime;
    TextMeshProUGUI text;
    float remainingTime;
    [SerializeField] GameObject gameOverCanvas;

    private void Awake() {
        text = GetComponent<TextMeshProUGUI>();
        remainingTime = startTime;
    }

    private void Start() {
        text.text = GetTimeString();
    }

    private void Update() {
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0) {
            remainingTime = 0;
            gameOverCanvas.SetActive(true);
        }
        text.text = GetTimeString();
    }

    private string GetTimeString() {
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime - minutes * 60);
        string timerText = string.Format("{0:00}:{1:00}", minutes, seconds);
        return timerText;
    }

}
