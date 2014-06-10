using UnityEngine;

namespace Assets.Scripts
{
    public class Fetus : MonoBehaviour
    {
        public bool DestroyFlag = false;

        void Update()
        {
            if (DestroyFlag) DestroyImmediate(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D c)
        {
            DestroyFlag = true;
        }
    }
}
