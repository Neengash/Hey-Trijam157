using UnityEngine;

public class FoodCollectable : PoolableObject
{
    [SerializeField] float reduceAngerValue;
    [SerializeField] int scorePoints;
    AngerManager angerManager;
    ScoreManager score;

    private void Awake() {
        angerManager = FindObjectOfType<AngerManager>();
        score = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == (int)Layers.Player) {
            score.IncreaseScore(scorePoints);
            angerManager.ReduceAnger(reduceAngerValue);
            gameObject.SetActive(false);
        }
    }
}
