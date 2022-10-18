using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private const float CAMERA_Z = -10;
    [SerializeField] private Hook hook;
    
    void Update() {
        // Follow the hook on the screen
        Vector3 newPosition = new Vector3(0, hook.transform.position.y, CAMERA_Z);
        gameObject.transform.position = newPosition;
    }
}
