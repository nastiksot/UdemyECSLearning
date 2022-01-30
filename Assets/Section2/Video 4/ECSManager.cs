using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Section2.Video_4
{
    public class ECSManager : MonoBehaviour
    {
        [SerializeField] private GameObject sheepPrefab;
        [SerializeField] private int spawnSheepCount;

        private EntityManager entityManager;

        void Start()
        {
            entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
            var ecsPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(sheepPrefab, settings);

            for (int i = 0; i < spawnSheepCount; i++)
            {
                var instance = entityManager.Instantiate(ecsPrefab);
                var position = transform
                    .TransformPoint(
                        new float3(UnityEngine.Random.Range(-50, 50), 0, UnityEngine.Random.Range(-50, 50)));
                entityManager.SetComponentData(instance, new Translation { Value = position, });
                entityManager.SetComponentData(instance, new Rotation { Value = new quaternion(0,0,0,0), });
            }
        } 
    }
}