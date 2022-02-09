using Section4.Video1.ECSObjectData;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Section4.Video1
{
    public class SheepForwardMoveSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var deltaTime = Time.DeltaTime;
            var forwardPosition = new float3(5f, 5f, 5f);
            var jobHandle = Entities.WithName("SheepForwardMoveSystem")
                .ForEach((ref Translation position, ref Rotation rotation, ref SheepData palmTreeData) =>
                {
                    var targetRotation = forwardPosition - position.Value;
                    targetRotation.y = 0;
                    rotation.Value = quaternion.LookRotation(targetRotation, math.up());
                    position.Value += deltaTime * 0.7f * math.forward(rotation.Value);
                })
                .Schedule(inputDeps);
            return jobHandle;
        }
    }
}