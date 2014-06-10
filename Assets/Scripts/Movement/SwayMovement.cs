using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class SwayMovement : MonoBehaviour
    {
        void Update()
        {
            transform.Translate(new Vector2(0, .01f * Mathf.Cos(Time.time)));
        }
    }
}