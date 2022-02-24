using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerManager : MonoBehaviour
{
    [SerializeField] float maxAnger;
    [SerializeField] float angerPerClick;
    float currentAnger;

    AngerBarController angerBar;
    PlayerController player;

    private void Awake() {
        ResetAnger();
        angerBar = FindObjectOfType<AngerBarController>();
        player = FindObjectOfType<PlayerController>();
    }

    private void Start() {
        angerBar.UpdateBar(currentAnger / maxAnger);
    }

    public void ReduceAnger(float amount) {
        currentAnger -= amount;
        if (currentAnger <= 0) { currentAnger = 0f;}
        angerBar.UpdateBar(currentAnger / maxAnger);
    }

    public void IncreaseAnger() {
        currentAnger += angerPerClick;
        if (currentAnger >= maxAnger) {
            currentAnger = maxAnger;
            player.AngryPlayer();
        }
        angerBar.UpdateBar(currentAnger / maxAnger);
    }

    public void ResetAnger() {
        currentAnger = 0f;
    }
}
