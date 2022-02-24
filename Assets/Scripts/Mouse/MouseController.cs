using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    PlayerController player;

    private void Awake() {
        Cursor.visible = false;
        player = FindObjectOfType<PlayerController>();
    }

    void Update() {
        transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) {
            player.UpdateDestination(transform.position);
        }
    }

}
