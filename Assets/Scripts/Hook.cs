using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hook : MonoBehaviour {

    [SerializeField] float HOOK_SPEED = 20;
    [SerializeField] float JITTER_GUARD = 0.1f;
    [SerializeField] private float POW = 0.5f;
    [SerializeField] private float GRAVITY = 2.0f;
    [SerializeField] private float SWAY = 1.0f;
    
    private Rigidbody rigidBody;
    
    private Vector3 oldVelocity;
    private Vector3 oldAcceleration;
    private Vector3 oldPosition;
    // old position

    public void Start() {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate() {
        Debug.Log("old " + oldVelocity);
        Debug.Log("new " + rigidBody.velocity);
        MoveHook();
        
        oldVelocity = rigidBody.velocity;
    }

    public void MoveHook() {
        if (GameSettings.USING_MOUSE) {
            Vector2 mouse = GetMousePosition();
            Vector2 hook = transform.position;
            
            var xdiff = mouse.x - hook.x;
            var ydiff = mouse.y - hook.y; 

            //var totalDistance = Math.Sqrt(xdiff * xdiff + ydiff * ydiff);
            var totalDistance = Math.Pow(xdiff * xdiff + ydiff * ydiff, POW);

            if (totalDistance > JITTER_GUARD) {
                float xForce = (float) (HOOK_SPEED * (xdiff/totalDistance));
                float yForce = (float) (HOOK_SPEED * (ydiff/totalDistance));

                if (yForce < 0f) {
                    rigidBody.AddForce(new Vector3(xForce, yForce * GRAVITY, 0), ForceMode.Force);
                }
                else {
                    rigidBody.AddForce(new Vector3(xForce * SWAY, yForce, 0), ForceMode.Force);
                }
            }
            
        }
    }

    private Vector2 GetMousePosition() {
        Vector2 vec = Camera.main.ScreenToWorldPoint(new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), 0));
        return vec;
    }

    // public void OnStickMovement(InputValue movement) {
    //     if (GameSettings.USING_STICK) {
    //         var vec = movement.Get<Vector2>();
    //         xDirection = xGetDirection(vec.x);
    //         yDirection = yGetDirection(vec.y);
    //     }
    // }

    private Direction xGetDirection(float x) {
        // Prevent Jitter
        if (Math.Abs(x) < 0.1) {
            return Direction.None;
        }
        
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

    private Direction yGetDirection(float y) {
        // Prevent Jitter
        if (Math.Abs(y) < 0.1) {
            return Direction.None;
        }
        
        if (y < 0) {
            return Direction.Down;
        }
        else if (y > 0) {
            return Direction.Up;
        }
        else {
            return Direction.None;
        }
    }

    // TODO: make the controls feel more snappy when switch from right to left
    // public void MoveHookHorizontal() {
    //     switch (xDirection) {
    //         case Direction.Left:
    //             rigidBody.AddForce(new Vector3 (-xHookSpeed, 0, 0), ForceMode.Force);
    //             break;
    //         case Direction.Right:
    //             rigidBody.AddForce(new Vector3 (xHookSpeed, 0, 0), ForceMode.Force);
    //             break;
    //         case Direction.None: 
    //         case Direction.Down:
    //         case Direction.Up:
    //             break;
    //     }
    // }

    // public void MoveHookVertical() {
    //     switch (yDirection) {
    //         case Direction.Up:
    //             rigidBody.AddForce(new Vector3 (0, yHookSpeed, 0), ForceMode.Force);
    //             break;
    //         case Direction.Down:
    //             rigidBody.AddForce(new Vector3 (0, -yHookSpeed, 0), ForceMode.Force);
    //             break;
    //         case Direction.Left:
    //         case Direction.Right:
    //         case Direction.None:
    //             break;
    //     }
    // }
}

enum Direction {
    Left,
    Right,
    Up,
    Down,
    None,
}
