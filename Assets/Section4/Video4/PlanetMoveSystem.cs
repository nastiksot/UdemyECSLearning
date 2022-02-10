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
            var speed = 10f;
            var targetPosition = new float3(0f, 0f, 0f);
            var jobHandle = Entities.WithName("PlanetMoveSystem").ForEach(
                    (ref Translation position) =>
                    {
                        var pivot = targetPosition;
                        var distanceSpeed = deltaTime * speed * 1 / math.distance(position.Value, pivot);
                        position.Value = math.mul(quaternion.AxisAngle(math.up(), distanceSpeed),
                            position.Value - pivot) + pivot;
                    })
                .Schedule(inputDeps);
            return jobHandle;
        }
    }
}