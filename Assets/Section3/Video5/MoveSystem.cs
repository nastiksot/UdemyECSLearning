using Unity.Entities;
using Unity.Jobs;
using Unity.Rendering;
using Unity.Transforms;

namespace Section3.Video4
{
    public class MoveSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var jobHandle = Entities.WithName("MoveSystem").ForEach((ref Translation position) => { })
                .Schedule(inputDeps);
            return jobHandle;
        }
    }
}