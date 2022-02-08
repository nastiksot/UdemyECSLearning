using Section3.Video6.ECSData;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Section3.Video6
{
    public class ECSInterface : MonoBehaviour
    {
        [SerializeField] private GameObject sheepPrefab;
        [SerializeField] private GameObject tankPrefab;
        [SerializeField] private GameObject palmTreePrefab;

        private World world;
        private EntityManager entityManager;
        private EntityQuery sheepEntityQuery;
        private EntityQuery tankEntityQuery;
        private EntityQuery palmTreeEntityQuery;
        private Entity sheepESCPrefab;
        private Entity tankESCPrefab;
        private Entity palmTreeESCPrefab;

        private void Start()
        {
            world = World.DefaultGameObjectInjectionWorld;
            entityManager = world.EntityManager;
            var settings = GameObjectConversionSettings.FromWorld(world, null);

            sheepESCPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(sheepPrefab, settings);
            tankESCPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(tankPrefab, settings);
            palmTreeESCPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(palmTreePrefab, settings);

            sheepEntityQuery = entityManager.CreateEntityQuery(ComponentType.ReadOnly<SheepData>());
            tankEntityQuery = entityManager.CreateEntityQuery(ComponentType.ReadOnly<TankData>());
            palmTreeEntityQuery = entityManager.CreateEntityQuery(ComponentType.ReadOnly<PalmTreeData>());

            ShowLogs();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                SpawnECSPrefab(sheepESCPrefab);
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                SpawnECSPrefab(tankESCPrefab);
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                SpawnECSPrefab(palmTreeESCPrefab);
            }
        }

        private void SpawnECSPrefab(Entity prefabToSpawn)
        {
            var instantiatedObject = entityManager.Instantiate(prefabToSpawn);
            var position = transform.TransformPoint(new float3(
                UnityEngine.Random.Range(-15, 5), 0, UnityEngine.Random.Range(-15, 5)));
            entityManager.SetComponentData(instantiatedObject, new Translation()
            {
                Value = position
            });
            entityManager.SetComponentData(instantiatedObject, new Rotation()
            {
                Value = quaternion.identity
            });
        }

        public int CountSheepEntities()
        {
            return sheepEntityQuery.CalculateEntityCount();
        }

        public int CountTankEntities()
        {
            return tankEntityQuery.CalculateEntityCount();
        }

        
        public int CountPalmTreeEntities()
        {
            return palmTreeEntityQuery.CalculateEntityCount();
        }
        
        private int CountAllEntities()
        {
            return entityManager.GetAllEntities().Length;
        }

        private void ShowLogs()
        {
            Debug.Log($"All entities: {CountAllEntities()} \n" +
                      $"Sheep entity count: {CountSheepEntities()} \n" +
                      $"Tank entity count: {CountTankEntities()} \n" +
                      $"Palm entity count: {CountPalmTreeEntities()} \n" );
        }
    }
}