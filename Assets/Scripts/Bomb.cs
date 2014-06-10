﻿using UnityEngine;

namespace Assets.Scripts
{
    public class Bomb : MonoBehaviour
    {
        public float BombDamage = 1;
        public float ExplosionSpeed = 450;

        public bool DestroyFlag = false;

        void Update()
        {
            if(DestroyFlag) DestroyImmediate(gameObject);
        }

        void OnTriggerEnter2D(Collider2D c)
        {
            DestroyFlag = true;
            Explode(c.transform);
        }

        private void Explode(Transform t)
        {
            t.parent = null;
            if(t.GetComponent<Rigidbody2D>() == null)
                t.gameObject.AddComponent<Rigidbody2D>();

            t.rigidbody2D.AddForce(new Vector2(
                Random.Range(-ExplosionSpeed, ExplosionSpeed),
                Random.Range(0, ExplosionSpeed)));

            foreach (Transform child in t)
            {
                Explode(child);
            }
        }
    }
}