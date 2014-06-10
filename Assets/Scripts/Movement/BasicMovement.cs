using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class BasicMovement : MonoBehaviour
    {
        public float MoveSpeed;

        void Update()
        {
            transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
        }
    }
}