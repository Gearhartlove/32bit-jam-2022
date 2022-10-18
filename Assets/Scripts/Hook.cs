using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hook : MonoBehaviour {

    [SerializeField] private float HookSpeed = 10f;
    Direction direction = Direction.None;
    
    private Rigidbody rigidBody;

    public void Start() {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void Update() { }

    public void FixedUpdate() {
        MoveHook();
    }

    public void OnMouseMovement(InputValue movement) {
        if (GameSettings.USING_MOUSE) {
            var vec = movement.Get<Vector2>();

            vec = Camera.main.ScreenToWorldPoint(vec);
            var diff = vec.x - transform.position.x;
            
            direction = GetDirection(diff);
        }
    }

    public void OnStickMovement(InputValue movement) {
        if (GameSettings.USING_STICK) {
            var vec = movement.Get<Vector2>();
            direction = GetDirection(vec.x);
        }
    }

    private Direction GetDirection(float x) {
            if (x < 0) {
                return Direction.Left;
            }
            else if (x > 0) {
                return Direction.Right;
            }
            else {
                return Direction.None;
            }
    }

    public void MoveHook() {
        switch (direction) {
            case Direction.Left:
                rigidBody.AddForce(new Vector3 (-HookSpeed, 0, 0), ForceMode.Force);
                break;
            case Direction.Right:
                rigidBody.AddForce(new Vector3 (HookSpeed, 0, 0), ForceMode.Force);
                break;
            case Direction.None:
                break;
        }
    }
}

enum Direction {
    Left,
    Right,
    None,
}
