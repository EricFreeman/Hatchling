using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public float PlayerSpeed = 10;

        public Transform Tail;

        void Update()
        {
            var xSpd = Input.GetAxisRaw("Horizontal");
            var ySpd = Input.GetAxisRaw("Vertical");
            transform.Translate(new Vector2(xSpd, ySpd) * PlayerSpeed * Time.deltaTime);
        }
    }
}