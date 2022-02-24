using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] float minTime, maxTime;
    [SerializeField] float minPositionX, maxPositionX;
    [SerializeField] float minPositionY, maxPositionY;
    ObjectPool pool;
    float spawnTimer;

    private void Awake() {
        pool = GetComponent<ObjectPool>();
    }

    private void Start() {
        spawnTimer = Random.Range(minTime, maxTime);
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine() {
        while (spawnTimer > 0) {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0) {
                SpawnFood();
                spawnTimer = Random.Range(minTime, maxTime);
            }
            yield return null;
        }
    }

    private void SpawnFood() {
        FoodCollectable food = (FoodCollectable)pool.GetNext();
        float posx = Random.Range(minPositionX, maxPositionX);
        float posy = Random.Range(minPositionY, maxPositionY);
        food.transform.position = new Vector2(posx, posy);
        food.gameObject.SetActive(true);
    }

}
