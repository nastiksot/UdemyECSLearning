using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Section5.Video2
{
    public class TankMoveSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var jobHandle = Entities
                .WithName("TankMoveSystem")
                .ForEach((ref Translation position, ref Rotation rotation, ref TankData tankData) =>
                {
                    position.Value += 0.03f * math.forward(rotation.Value);
                })
                .Schedule(inputDeps);

            return jobHandle;
        }
    }
}