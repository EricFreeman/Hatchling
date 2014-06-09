using UnityEngine;

namespace Assets.Scripts
{
    public class Director : MonoBehaviour
    {
        public float MaxBombDelay = 1;
        public float CurrentBombDelay = 1;

        void Update()
        {
            UpdateBombs();
        }

        private void UpdateBombs()
        {
            CurrentBombDelay -= Time.deltaTime;
            if (CurrentBombDelay <= 0)
            {
                var p = (GameObject) Instantiate(Resources.Load("Prefabs/PurpleBomb"));
                p.transform.position += new Vector3(19, Random.Range(-9f, 9f), 0);
                CurrentBombDelay = MaxBombDelay;
            }
        }
    }
}