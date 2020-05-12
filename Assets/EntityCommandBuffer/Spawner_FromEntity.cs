namespace MyECSSample.EntityCommandBuffer
{
    using Unity.Entities;

    public struct Spawner_FromEntity : IComponentData
    {
        public Entity Prefab;
    }
}
