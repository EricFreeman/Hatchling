using UnityEngine;

namespace Assets.Scripts
{
    public class Fetus : MonoBehaviour
    {
        public bool DestroyFlag = false;
        private Director _dir;

        void Start()
        {
            _dir = GameObject.Find("Director").GetComponent<Director>();
        }

        void Update()
        {
            if (DestroyFlag) DestroyImmediate(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D c)
        {
            var p = GameObject.Find("Player");
            if (p != null)
            {
                p.GetComponent<Player>().AddPart();
                _dir.AddPoints(1);
            }

            DestroyFlag = true;
        }
    }
}