using Section3.Video2;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class MoveSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var jobHandle = Entities.WithName("MoveSystem").ForEach((ref Translation position, ref Rotation rotation,
                ref NonUniformScale scale, ref SheepData sheepData) =>
            {
                position.Value += 0.01f * math.up();

                if (position.Value.y > 5f)
                {
                    position.Value = new float3(position.Value.x, 0, position.Value.z);
                }
            }
        ).Schedule(inputDependencies);
        return jobHandle;
    }
}