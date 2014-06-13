using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class SwayMovement : MonoBehaviour
    {
        public float maxUpDown = .01f;
        public float angle = 2.5f;
        public float speed = 10;
        public float toDegrees = 0.5235988f;    // 30 degrees in radians

        void Update()
        {
            angle += speed * Time.deltaTime;
            if (angle > 360) angle -= 360;
            transform.position += new Vector3(0, maxUpDown * Mathf.Sin(angle * toDegrees), 0);
        }
    }
}