using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

    private void Awake() {
        Cursor.visible = false;
    }

    void Update() {
        transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown() {
        //TODO: Increase Anger
        //TODO: Update players movement position
    }
}
