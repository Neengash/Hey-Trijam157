using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    PlayerController player;
    AngerManager angerManager;
    AudioSource audioSource;

    private void Awake() {
        Cursor.visible = false;
        player = FindObjectOfType<PlayerController>();
        angerManager = FindObjectOfType<AngerManager>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) {
            if (player.CanMove()) {
                angerManager.IncreaseAnger();
                audioSource.Play();
            }

            RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit) {
                player.UpdateDestination(hit.point);
            }
        }
    }

}
