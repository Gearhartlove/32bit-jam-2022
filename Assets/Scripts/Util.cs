using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    public static void QuitGame() {
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
