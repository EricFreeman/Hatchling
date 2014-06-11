using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class SwayMovement : MonoBehaviour
    {
        void Update()
        {
            // TODO: Fix this to make it not suck
            transform.Translate(new Vector2(0, .01f * Mathf.Cos(Time.time)));
        }
    }
}