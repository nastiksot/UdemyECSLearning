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
            for (var i = 0; i < planetCount; i++)
            {
                var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
                var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
                var planetECSprefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(planetPrefab, settings);
                var instantiatedPlanet = entityManager.Instantiate(planetECSprefab);
                var randomPosition = new float3(UnityEngine.Random.Range(-100, 100), 0,
                    UnityEngine.Random.Range(-100, 100));
                entityManager.SetComponentData(instantiatedPlanet, new Translation
                {
                    Value = randomPosition
                });
            }
        }
    }
}