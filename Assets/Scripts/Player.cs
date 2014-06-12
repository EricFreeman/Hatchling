using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public float PlayerSpeed = 10;
        public Transform Tail;

        private List<DragonPart> _parts = new List<DragonPart>();

        void Start()
        {
            LoadParts(GameObject.Find("Head").transform);
        }

        private void LoadParts(Transform part)
        {
           _parts.Add(new DragonPart
           {
               Part = part,
               Parent = part.parent,
               StartPosition = part.localPosition
           });

           foreach (Transform child in part.GetComponentsInChildren<Transform>().ToList().Skip(1))
               LoadParts(child);
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
                if (obj.transform.parent == null && obj.name != "Head")
                {
                    obj.transform.parent = part.Parent;
                    Destroy(obj.rigidbody2D);
                    obj.transform.position = part.Parent.transform.position 
                                            - part.StartPosition 
                                            + new Vector3(0, part.Parent.transform.localPosition.y, 0);
                    break;
                }
            }
        }
    }
}