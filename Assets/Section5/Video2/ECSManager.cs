using Section5.Video1.ECSObjectData;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Section5.Video2
{
    public class ECSManager : MonoBehaviour
    {
        [SerializeField] private GameObject tankPrefab;
        [SerializeField] private GameObject sheepPrefab;
        [SerializeField] private int spawnCount = 500;

        EntityManager entityManager;

        public void Start()
        {
            entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
            var tankECSPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(tankPrefab, settings);
            var sheepECSPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(sheepPrefab, settings);

            for (var i = 0; i < spawnCount; i++)
            {

                float x = UnityEngine.Random.Range(-100, 100);
                float z = UnityEngine.Random.Range(-100, 100);
                var position = transform.TransformPoint(new float3(x, 0, z));
                
                var instantiatedTank = entityManager.Instantiate(tankECSPrefab);
                entityManager.SetComponentData(instantiatedTank, new Translation
                {
                    Value = position
                });
                entityManager.SetComponentData(instantiatedTank, new Rotation
                {
                    Value = quaternion.identity
                });

                var instantiatedSheep = entityManager.Instantiate(sheepECSPrefab);
                entityManager.SetComponentData(instantiatedSheep, new Rotation
                {
                    Value = quaternion.identity
                });
                entityManager.SetComponentData(instantiatedSheep, new Translation
                {
                    Value = position
                });
                entityManager.SetComponentData(instantiatedSheep, new SheepData
                {
                    moveSpeed = UnityEngine.Random.Range(5f, 15f),
                    rotationSpeed = UnityEngine.Random.Range(2f, 10f)
                });
            }
        }
    }
}