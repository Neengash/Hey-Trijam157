using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerManager : MonoBehaviour
{
    [SerializeField] float maxAnger;
    [SerializeField] float angerPerClick;
    float currentAnger;

    AngerBarController angerBar;

    private void Awake() {
        ResetAnger();
        angerBar = FindObjectOfType<AngerBarController>();
    }

    public void IncreaseAnger() {
        currentAnger += angerPerClick;
        if (currentAnger >= maxAnger) {
            currentAnger = maxAnger;
            //TODO: Player set Angry
        }
        angerBar.UpdateBar(currentAnger / maxAnger);
    }

    public void ResetAnger() {
        currentAnger = 0f;
    }
}
