using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    AngerManager angerManager;

    private void Awake() {
        Cursor.visible = false;
        angerManager = FindObjectOfType<AngerManager>();
    }

    void Update() {
        transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) {
            // This sould move to player --> to depend on current player status
            angerManager.IncreaseAnger();
            //TODO: Update players movement position
        }
    }

}
