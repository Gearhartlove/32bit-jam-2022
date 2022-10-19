using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private const float CAMERA_Z = -10;
    private const double Y_TOP_BOUND = 0.7;
    private const double Y_BOT_BOUND = 0.3;
    private const float SMOOTH_FACTOR = 0.08f;

    [SerializeField] private GameObject TopBoundGO;
    [SerializeField] private GameObject BotBoundGO;
    [SerializeField] private Hook hook;

    void Update() {
        FollowPlayer();
    }

    /// Follow the hook on the screen
    private void FollowPlayer() {
        Vector3 hookPosition = new Vector3(0, hook.transform.position.y, CAMERA_Z);
        var vec = Camera.main.WorldToViewportPoint(hookPosition);

        if (vec.y >= Y_TOP_BOUND) {
            MoveCamera(CameraDirection.Up, hookPosition);
        }
        else if (vec.y <= Y_BOT_BOUND) {
            MoveCamera(CameraDirection.Down, hookPosition);
        }
    }

    private void MoveCamera(CameraDirection dir, Vector3 hookPosition) {
        switch (dir) {
            case CameraDirection.Up:
                transform.position = Vector3.Lerp(transform.position, TopBoundGO.transform.position, Time.deltaTime * SMOOTH_FACTOR);
                break;
            case CameraDirection.Down:
                transform.position = Vector3.Lerp(transform.position, BotBoundGO.transform.position, Time.deltaTime * SMOOTH_FACTOR); 
                break;
            case CameraDirection.None:
                break;

        }
    }
}

enum CameraDirection {
    Up,
    Down,
    None,
}
