using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;

namespace Section4.Video4
{
    public class PlanetMoveSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var deltaTime = Time.DeltaTime;
            var targetPosition = new float3(0f, 0f, 0f);
            var jobHandle = Entities.WithName("PlanetMoveSystem").ForEach((ref Translation position) =>
                {
                    position.Value += 0.5f * deltaTime * (targetPosition-position.Value);
                })
                .Schedule(inputDeps);
            return jobHandle;
        }
    }
}