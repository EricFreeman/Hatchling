using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public float PlayerSpeed = 10;
        public Transform Tail;

        private List<string> _parts;
        private Dictionary<string, Vector3> _pos = new Dictionary<string, Vector3>(); 

        void Start()
        {
            _parts = new List<string>
            {
                "Head", "Neck", "Neck2", "Neck3", "Chest", 
                "Shoulder", "Chest2", "Body1", "Body2", "Tail1"
            };

            foreach (var part in _parts)
            {
                var p = GameObject.Find(part);
                if (p != null)
                    _pos.Add(part, p.transform.localPosition);
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
            for (var i = _parts.Count - 1; i >= 0; i--)
            {
                var obj = GameObject.Find(_parts[i]);
                if (obj != null)
                {
                    if (obj.transform.parent == null && obj.name != "Head")
                    {
                        var parent = GameObject.Find(_parts[i - 1]);
                        if (parent != null)
                        {
                            obj.transform.parent = parent.transform;
                            Destroy(obj.rigidbody2D);
                            obj.transform.position = parent.transform.position - _pos[_parts[i]];
                        }
                    }
                }
            }
        }
    }
}