using UnityEngine;

namespace Assets.Scripts
{
    public class DestroyAfterX : MonoBehaviour
    {
        public float X;

        void Update()
        {
            if(transform.position.x <= X)
                DestroyImmediate(gameObject);
        }
    }
}
