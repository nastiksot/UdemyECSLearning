using Section3.Video4;
using Unity.Entities;
using UnityEngine;

namespace Section3.Video5
{
    public class ECSInterface : MonoBehaviour
    {
        private World world;
        private EntityManager entityManager;
        private EntityQuery sheepEntityQuery;
        private EntityQuery tankEntityQuery;

        private void Start()
        {
            world = World.DefaultGameObjectInjectionWorld;
            entityManager = world.GetExistingSystem<MoveSystem>().EntityManager;

            sheepEntityQuery = entityManager.CreateEntityQuery(ComponentType.ReadOnly<SheepData>());
            tankEntityQuery = entityManager.CreateEntityQuery(ComponentType.ReadOnly<TankData>());

            Debug.Log($"All entities: {CountAllEntities()} \n" +
                      $"Sheep entity count: {CountSheepEntities()} \n" +
                      $"Tank entity count: {CountTankEntities()} \n");
        }

        public int CountSheepEntities()
        {
            return sheepEntityQuery.CalculateEntityCount();
        }

        public int CountTankEntities()
        {
            return tankEntityQuery.CalculateEntityCount();
        }

        public int CountAllEntities()
        {
            return entityManager.GetAllEntities().Length;
        }
    }
}