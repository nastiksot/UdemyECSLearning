using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

namespace Section3.Video3
{
    public class CreateSheepSystem : JobComponentSystem
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            for (var i = 0; i < 1000; i++)
            {
                var instance = EntityManager.CreateEntity(
                    ComponentType.ReadWrite<LocalToWorld>(),
                    ComponentType.ReadWrite<Rotation>(),
                    ComponentType.ReadWrite<Translation>(),
                    ComponentType.ReadWrite<NonUniformScale>(),
                    ComponentType.ReadOnly<RenderBounds>(),
                    ComponentType.ReadOnly<RenderMesh>()
                );
                var position = new float3(UnityEngine.Random.Range(-105, 105), 0, UnityEngine.Random.Range(-105, 105));
                var randScale = UnityEngine.Random.Range(20, 300);

                EntityManager.SetComponentData(instance, new Translation()
                {
                    Value = position
                });

                EntityManager.SetComponentData(instance, new Rotation()
                {
                    Value = quaternion.identity
                });

                EntityManager.SetComponentData(instance, new RenderBounds()
                {
                    Value = new AABB()
                });
                EntityManager.SetComponentData(instance, new LocalToWorld()
                {
                    Value = new float4x4(quaternion.identity, position)
                });

                EntityManager.SetComponentData(instance, new NonUniformScale()
                {
                    Value = new float3(randScale, randScale, randScale)
                });


                var resources = Resources.Load<GameObject>("SheepHolder").GetComponent<SheepHolder>();
                EntityManager.SetSharedComponentData(instance, new RenderMesh()
                {
                    mesh = resources.Mesh,
                    material = resources.Material
                });
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return inputDeps;
        }
    }
}