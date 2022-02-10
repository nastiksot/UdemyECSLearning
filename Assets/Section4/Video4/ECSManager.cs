using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Section4.Video4
{
    public class ECSManager : MonoBehaviour
    {
        [SerializeField] private GameObject planetPrefab;
        [SerializeField] private int planetCount = 500;

        private void Start()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
            var asteroidECSPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(planetPrefab, settings);
            for (var i = 0; i < planetCount; i++)
            {
                var x = math.sin(i) * UnityEngine.Random.Range(15f, 50f);
                var y = UnityEngine.Random.Range(-5f, 5f);
                var z = math.cos(i) * UnityEngine.Random.Range(15, 50f);
                var randPosition = new float3(x, y, z);
                var randRotation = UnityEngine.Random.Range(-360, 360);
                var randScale = new float3(UnityEngine.Random.Range(40f, 100f), UnityEngine.Random.Range(40f, 100f),
                    UnityEngine.Random.Range(40f, 100f));
                var instantiatedAsteroid = entityManager.Instantiate(asteroidECSPrefab);
                entityManager.SetComponentData(instantiatedAsteroid, new Translation()
                {
                    Value = randPosition
                });
                entityManager.SetComponentData(instantiatedAsteroid, new Rotation()
                {
                    Value = quaternion.Euler(randRotation, randRotation, randRotation)
                });
                entityManager.SetComponentData(instantiatedAsteroid, new NonUniformScale()
                {
                    Value = randScale
                });
            }
        }
    }
}