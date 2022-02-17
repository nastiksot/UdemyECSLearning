using Unity.Entities;

namespace Section5.Video1.ECSObjectData
{
    [GenerateAuthoringComponent]
    public struct SheepData : IComponentData
    {
        public float moveSpeed;
        public float rotationSpeed;
    }
}