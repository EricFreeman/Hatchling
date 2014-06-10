using UnityEngine;

namespace Assets.Scripts
{
    public class Spawner
    {
        public string Prefab;
        public float MinSpawnDelay;
        public float MaxSpawnDelay;
        public Director Director;

        public float CurrentSpawnDelay;

        public Spawner(string prefab, float min, float max, Director director)
        {
            Prefab = prefab;
            MinSpawnDelay = min;
            MaxSpawnDelay = max;
            CurrentSpawnDelay = Random.Range(MinSpawnDelay, MaxSpawnDelay);
            Director = director;
        }

        public void Update()
        {
            CurrentSpawnDelay -= Time.deltaTime;
            if (CurrentSpawnDelay <= 0)
            {
                var p = Director.Spawn(Prefab);
                p.transform.position += new Vector3(19, Random.Range(-9f, 9f), 0);
                CurrentSpawnDelay = Random.Range(MinSpawnDelay, MaxSpawnDelay);
            }
        }
    }
}