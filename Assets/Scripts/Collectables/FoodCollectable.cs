using UnityEngine;

public class FoodCollectable : PoolableObject
{
    [SerializeField] float reduceAngerValue;
    AngerManager angerManager;

    private void Awake() {
        angerManager = FindObjectOfType<AngerManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == (int)Layers.Player) {
            // TODO: Increase points
            angerManager.ReduceAnger(reduceAngerValue);
            gameObject.SetActive(false);
        }
    }
}
