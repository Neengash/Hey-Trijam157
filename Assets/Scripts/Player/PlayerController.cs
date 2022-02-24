using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float destinationDistance;
    [SerializeField] float speed;
    Vector2 destination;
    Coroutine currentCoroutine;
    AngerManager angerManager;
    Animator animator;
    AudioSource audioSource;

    public enum PlayerMood {
        Happy = 0,
        Angry = 1
    }

    PlayerMood mood;

    private void Awake() {
        destination = new Vector2(0,0);
        mood = PlayerMood.Happy;
        angerManager = FindObjectOfType<AngerManager>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public bool CanMove() {
        return mood != PlayerMood.Angry;
    }

    public void UpdateDestination(Vector2 newDestination) {
        destination = newDestination;
        if (currentCoroutine == null) {
            currentCoroutine = StartCoroutine(Move());
        }
    }

    IEnumerator Move() {
        while (Vector2.Distance(destination, (Vector2)transform.position) > destinationDistance) {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
        currentCoroutine = null;
    }

    public void AngryPlayer() {
        mood = PlayerMood.Angry;
        animator.SetTrigger("Angry");
        audioSource.Play();
        destination = transform.position;
        StopCoroutine(currentCoroutine);
        currentCoroutine = null;
    }

    public void EndAngry() {
        mood = PlayerMood.Happy;
        angerManager.ResetAnger();
    }
}
