using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class SwayMovement : MonoBehaviour
    {
        public float maxUpDown = .01f;
        public float angle = 2.5f;
        public float speed = 10;
        public float toDegrees = 0.5235988f;    // 30 degrees in radians

        public float startOffset { get; set; }

        public Vector3 swayOffset { get; set; }

        void Start()
        {
            startOffset = transform.position.x;
        }

        void Update()
        {
            angle += speed * Time.deltaTime;
            if (angle > 360) angle -= 360;
            var offset = new Vector3(0, maxUpDown*Mathf.Sin(angle*toDegrees + startOffset), 0);
            transform.position += offset;
            swayOffset += offset;
        }
    }
}