using UnityEngine;

namespace Assets.Scripts
{
    public class Bomb : MonoBehaviour
    {
        public float BombDamage = 1;
        public float ExplosionSpeed = 450;
        public bool DestroyFlag = false;
        public Director _dir;
        public Player _player;

        void Start()
        {
            _dir = GameObject.Find("Director").GetComponent<Director>();
            _player = GameObject.Find("Player").GetComponent<Player>();
        }

        void Update()
        {
            if(DestroyFlag) DestroyImmediate(gameObject);
        }

        void OnTriggerEnter2D(Collider2D c)
        {
            if (!DestroyFlag)
            {
                DestroyFlag = true;
                _player.Explode(c.transform, 450);
            }
        }
    }
}