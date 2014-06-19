using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models;
using Assets.Scripts.Movement;
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
            foreach (Transform child in transform.GetComponentsInChildren<Transform>().Skip(1))
            {
                Debug.Log("Adding: " + child.name);
                _parts.Add(new DragonPart
                {
                    Part = child,
                    Parent = child.parent,
                    StartPosition = new Vector3(child.localPosition.x, child.localPosition.y, 0)
                });
            }
        }

        void Update()
        {
            var xSpd = Input.GetAxisRaw("Horizontal");
            var ySpd = Input.GetAxisRaw("Vertical");
            transform.Translate(new Vector2(xSpd, ySpd) * PlayerSpeed * Time.deltaTime);

            if(transform.position.y > 6) transform.position -= new Vector3(0, transform.position.y - 6, 0);
            if(transform.position.y < -6) transform.position += new Vector3(0, -1 * transform.position.y - 6, 0);

            if (transform.position.x > 16) transform.position -= new Vector3(transform.position.x - 16, 0, 0);
            if (transform.position.x < -9) transform.position += new Vector3(-1 * transform.position.x - 9, 0, 0);
        }

        public void Explode(Transform t, float explosionSpeed)
        {
            bool startExploding = false;

            foreach (var child in _parts)
            {
                Debug.Log("Looking: " + child.Part.name);

                if (child.Part == t) startExploding = true;

                if (startExploding)
                {
                    Debug.Log("Exploding: " + child.Part.name);

                    child.Part.parent = null;
                    if (child.Part.GetComponent<Rigidbody2D>() == null)
                        child.Part.gameObject.AddComponent<Rigidbody2D>();

                    child.Part.rigidbody2D.AddForce(new Vector2(
                        Random.Range(-explosionSpeed, explosionSpeed),
                        Random.Range(0, explosionSpeed)));
                }
            }
        }

        public void AddPart()
        {
            foreach (var part in _parts)
            {
                var obj = part.Part;
                if (obj.parent == null && obj.name != "Head")
                {
                    Destroy(obj.rigidbody2D);
                    obj.transform.parent = part.Parent;

                    var sway = part.Part.GetComponent<SwayMovement>();
                    var swayOffset = sway != null ? sway.swayOffset : Vector3.zero;
                    Debug.Log(part.StartPosition);
                    Debug.Log(swayOffset);
                    obj.transform.localPosition = part.StartPosition + swayOffset;
                    break;
                }
            }
        }
    }
}