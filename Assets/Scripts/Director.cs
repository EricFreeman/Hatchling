using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Director : MonoBehaviour
    {
        public int Points { get; set; }
        public Transform Player;
        public int Multiplier
        {
            get { return Player.GetComponentsInChildren<Transform>().Count(); }
        }

        public List<Spawner> Spawners = new List<Spawner>(); 

        void Start()
        {
            Spawners.Add(new Spawner("Prefabs/PurpleBomb", 2, 3, this));
            Spawners.Add(new Spawner("Prefabs/Fetus", 2, 3, this));
        }

        void Update()
        {
            foreach (var spawner in Spawners)
                spawner.Update();

//            Debug.Log("Points: " + Points);
//            Debug.Log("Multip: " + Multiplier);
        }

        public GameObject Spawn(string prefab)
        {
            return (GameObject) Instantiate(Resources.Load(prefab));
        }

        public void AddPoints(int points)
        {
            Points += (points * Multiplier);
        }
    }
}