using System.Collections;
using System.Collections.Generic;
using Section3.Video3;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Jobs;

public class CreateCapsuleSystem : JobComponentSystem
{
    protected override void OnCreate()
    {
        base.OnCreate();

        var instance = EntityManager.CreateEntity(
            ComponentType.ReadOnly<LocalToWorld>(),
            ComponentType.ReadOnly<RenderBounds>(),
            ComponentType.ReadOnly<RenderMesh>()
        );

        EntityManager.SetComponentData(instance,
            new RenderBounds
            {
                Value = new AABB()
            });

        EntityManager.SetComponentData(instance,
            new LocalToWorld
            {
                Value = new float4x4(quaternion.identity, new float3(0, 0, 0))
            });

        var resourceHolder = Resources.Load<GameObject>("ResourceHolder").GetComponent<ResourceHolder>();

        EntityManager.SetSharedComponentData(instance,
            new RenderMesh
            {
                mesh = resourceHolder.Mesh,
                material = resourceHolder.Material
            });
    }


    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        return inputDeps;
    }
}