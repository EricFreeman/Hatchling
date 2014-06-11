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

        void Start()
        {
            _parts = new List<string>
            {
                "Head", "Neck", "Neck2", "Neck3", "Chest", 
                "Shoulder", "Chest2", "Body1", "Body2", "Tail1"
            };
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
                    Debug.Log("Found obj");
                    if (obj.transform.parent == null)
                    {
                        var parent = GameObject.Find(_parts[i - 1]);
                        if (parent != null)
                        {
                            obj.transform.parent = parent.transform;
                            Destroy(obj.rigidbody2D);

                            //TODO: Store position of prefab items before dragon is destroyed.  Then place them correctly here!
                            obj.transform.position = parent.transform.position;
                        }
                    }
                }
            }
        }
    }
}