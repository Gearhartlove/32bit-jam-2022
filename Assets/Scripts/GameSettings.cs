using System;
using UnityEngine;

public class GameSettings : MonoBehaviour {
    private void Awake() {
        if (USING_MOUSE && USING_STICK) {
            Debug.LogError("player cannot use both mouse and stick controls at the same time.");
            Util.QuitGame();
        }
    }

    public const Boolean USING_STICK = false;
    public const Boolean USING_MOUSE = true;
}
