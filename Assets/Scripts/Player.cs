﻿using System.Collections.Generic;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public float PlayerSpeed = 10;
        public Transform Tail;
        private Director _dir;

        private List<DragonPart> _parts = new List<DragonPart>();

        void Start()
        {
            _dir = GameObject.Find("Director").GetComponent<Director>();

            var part = GameObject.Find("Head").transform;
            foreach (Transform child in part.GetComponentsInChildren<Transform>())
            {
                _parts.Add(new DragonPart
                {
                    Part = child,
                    Parent = child.parent,
                    StartPosition = new Vector3(child.localPosition.x, child.localPosition.y * -1, 0)
                });
            }
        }

        void Update()
        {
            var xSpd = Input.GetAxisRaw("Horizontal");
            var ySpd = Input.GetAxisRaw("Vertical");
            transform.Translate(new Vector2(xSpd, ySpd) * PlayerSpeed * Time.deltaTime);
        }

        public void AddPart()
        {
            foreach (var part in _parts)
            {
                var obj = part.Part;
                if (obj.parent == null && obj.name != "Head")
                {
                    obj.transform.parent = part.Parent;
                    Destroy(obj.rigidbody2D);
                    obj.transform.position = part.Parent.position - part.StartPosition;
                    break;
                }
            }
        }
    }
}