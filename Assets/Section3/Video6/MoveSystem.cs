using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

namespace Section3.Video6
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