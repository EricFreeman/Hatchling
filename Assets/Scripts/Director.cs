using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Director : MonoBehaviour
    {
        public float MaxBombDelay = 1;
        public float CurrentBombDelay = 1;

        public float MaxFetusDelay = 5;
        public float CurrentFetusDelay = 5;

        public List<Spawner> Spawners = new List<Spawner>(); 

        void Start()
        {
            Spawners.Add(new Spawner("Prefabs/PurpleBomb", .8f, 1.2f, this));
            Spawners.Add(new Spawner("Prefabs/Fetus", 5, 10, this));
        }

        void Update()
        {
            foreach (var spawner in Spawners)
            {
                spawner.Update();
            }
        }

        public GameObject Spawn(string prefab)
        {
            return (GameObject) Instantiate(Resources.Load(prefab));
        }
    }
}