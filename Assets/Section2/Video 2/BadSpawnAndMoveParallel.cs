using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

namespace Section2.Video_2
{
    public class BadSpawnAndMoveParallel : MonoBehaviour
    {
        [SerializeField] private GameObject sheepPrefab;
        [SerializeField] private int spawnSheepCount;
        private List<GameObject> instantiatedSheeps = new List<GameObject>();

        void Start()
        {
            for (var i = 0; i < spawnSheepCount; i++)
            {
                var sheepPosition = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
                var instantiatedSheep = Instantiate(sheepPrefab, sheepPosition, Quaternion.identity);
                instantiatedSheeps.Add(instantiatedSheep);
            }
        }

        void Update()
        {
            foreach (var instantiatedSheep in instantiatedSheeps)
            {
                instantiatedSheep.transform.Translate(0f, 0f, 0.1f);
                if (instantiatedSheep.transform.position.z < 50) continue; 
                var sheepPosition = instantiatedSheep.transform.position;
                var newPosition = new Vector3(sheepPosition.x, sheepPosition.y, -50f);

                sheepPosition = newPosition;
                instantiatedSheep.transform.position = sheepPosition;
            }
        }
    }
}