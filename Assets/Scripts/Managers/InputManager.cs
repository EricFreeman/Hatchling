using UnityEngine;

namespace Assets.Scripts
{
    public static class InputManager
    {
        public static bool IsKeyDownOrTouch(KeyCode key, int finger = 0)
        {
            return Input.GetKeyDown(key) ||
                   (Input.touchCount == 1 && Input.GetTouch(finger).phase == TouchPhase.Began);
        }
    }
}
