using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public float JumpHeight = 500;

        void Update()
        {
            if (InputManager.IsKeyDownOrTouch(KeyCode.Space))
            {
                transform.rigidbody2D.velocity = Vector2.zero;
                transform.rigidbody2D.AddForce(new Vector2(0, JumpHeight));
            }
        }
    }
}