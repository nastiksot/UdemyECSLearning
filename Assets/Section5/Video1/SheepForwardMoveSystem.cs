using Section4.Video1.ECSObjectData;
using Section5.Video1;
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
            float3 forwardPosition = GameDataManager.instance.palmTransform.position;
            var movementSpeed = 0.9f;
            var jobHandle = Entities.WithName("SheepForwardMoveSystem")
                .ForEach((ref Translation position, ref Rotation rotation, ref SheepData sheepData) =>
                {
                    var targetPoint = forwardPosition - position.Value;
                    targetPoint.y = 0;
                    var targetRotation = quaternion.LookRotation(targetPoint, math.up());
                    rotation.Value = math.slerp(rotation.Value, targetRotation, deltaTime);
                    position.Value += deltaTime * movementSpeed * math.forward(rotation.Value);
                })
                .Schedule(inputDeps);
            return jobHandle;
        }
    }
}