using Unity.Entities;
using UnityEngine;

namespace Section3.Video4
{
    public class ECSInterface : MonoBehaviour
    {
        private World world;

        private void Start()
        {
            world = World.DefaultGameObjectInjectionWorld;

            var entityManager = world.GetExistingSystem<MoveSystem>().EntityManager;

            var sheepEntityQuery = entityManager.CreateEntityQuery(ComponentType.ReadOnly<SheepData>());

            var tankEntityQuery = entityManager.CreateEntityQuery(ComponentType.ReadOnly<TankData>());
            
            Debug.Log($"All entities: {entityManager.GetAllEntities().Length} \n" +
                      $"Sheep entity count: {sheepEntityQuery.CalculateEntityCount()} \n" +
                      $"Tank entity count: {tankEntityQuery.CalculateEntityCount()} \n");
        }
    }
}