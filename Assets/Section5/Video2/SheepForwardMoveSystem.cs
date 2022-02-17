using Section5.Video1.ECSObjectData;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Section5.Video2
{
    public class SheepForwardMoveSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var deltaTime = Time.DeltaTime;
            float3 forwardPosition = GameDataManager.instance.palmTransform.position;
            var jobHandle = Entities.WithName("SheepForwardMoveSystem")
                .ForEach((ref Translation position, ref Rotation rotation, ref SheepData sheepData) =>
                {
                    var targetPoint = forwardPosition - position.Value;
                    targetPoint.y = 0;
                    var targetRotation = quaternion.LookRotation(targetPoint, math.up());
                    rotation.Value = math.slerp(rotation.Value, targetRotation, deltaTime*sheepData.rotationSpeed);
                    position.Value += deltaTime * sheepData.moveSpeed * math.forward(rotation.Value);
                })
                .Schedule(inputDeps);
            return jobHandle;
        }
    }
}