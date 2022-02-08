using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

namespace Section3.Video3
{
    public class LargeCubeMoveSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var jobHandle = Entities.WithName("LargeCubeMoveSystem").ForEach((ref Translation position,
                ref NonUniformScale scale, ref LargeCubeData cubeData) =>
            {
                position.Value += 0.01f * math.down();
                if (position.Value.y < -5)
                {
                    position.Value = new float3(position.Value.x, 0, position.Value.z);
                }
            }).Schedule(inputDeps);
            return jobHandle;
        }
    }
}