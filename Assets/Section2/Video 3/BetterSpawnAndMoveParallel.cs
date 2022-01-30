using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;
using Random = UnityEngine.Random;

namespace Section2.Video_3
{
    public class BetterSpawnAndMoveParallel : MonoBehaviour
    {
        [SerializeField] private GameObject sheepPrefab;
        [SerializeField] private int spawnSheepCount;
        private Transform[] sheepTransforms;

        private MoveJob moveJob;
        private JobHandle moveHandle;
        private TransformAccessArray sheepTransformAccessArray;

        struct MoveJob : IJobParallelForTransform
        {
            public void Execute(int index, TransformAccess transform)
            {
                transform.position += 0.1f * (transform.rotation * new Vector3(0f, 0f, 1f));
                if (transform.position.z < 50) return;
                var newPosition = new Vector3(transform.position.x, transform.position.y, -50f);
                transform.position = newPosition;
            }
        }

        public void Update()
        {
            moveJob = new MoveJob() { };
            moveHandle = moveJob.Schedule(sheepTransformAccessArray);
        }

        private void LateUpdate()
        {
            moveHandle.Complete();
        }

        private void OnDestroy()
        {
            sheepTransformAccessArray.Dispose();
        }

        public void Start()
        {
            sheepTransforms = new Transform [spawnSheepCount];
            for (var i = 0; i < spawnSheepCount; i++)
            {
                var sheepPosition = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
                var instantiatedSheep = Instantiate(sheepPrefab, sheepPosition, Quaternion.identity);
                sheepTransforms[i] = instantiatedSheep.transform;
            }

            sheepTransformAccessArray = new TransformAccessArray(sheepTransforms);
        }
    }
}