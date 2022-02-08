using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class FloatSystem : JobComponentSystem
{  
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var jobHandle = Entities.WithName("FloatSystem").ForEach((ref Translation position, ref Rotation rotation) =>
        {
            position.Value.y += 0.1f * math.up().y;
            if (position.Value.y > 50)
            {
                position.Value.y = 0;
            }
        }).Schedule(inputDeps);
        return jobHandle;
    }
}
