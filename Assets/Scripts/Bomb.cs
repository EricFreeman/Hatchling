using System.Security.Cryptography;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bomb : MonoBehaviour
    {
        public float BombDamage = 1;
        public float BombSpeed = 3;

        public bool DestroyFlag = false;

        void Update()
        {
            transform.Translate(Vector3.left * BombSpeed * Time.deltaTime);

            if(DestroyFlag) DestroyImmediate(gameObject);
        }

        void OnTriggerEnter2D()
        {
            DestroyFlag = true;
        }
    }
}