using Unity.Entities;
using Unity.Jobs;

namespace MyECSSample.EntityCommandBuffer
{
    public class SpawnerSystem_FromEntity : JobComponentSystem
    {
        BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;

        protected override void OnCreate()
        {
            /* 在OnCreate函数里获取或创建BeginInitializationEntityCommandBufferSystem */
            m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            /* 相当于获取了队列 */
            var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent();

            var jobHandle = Entities
                .ForEach((Entity entity, int entityInQueryIndex, in Spawner_FromEntity spawnerFromEntity) =>
                {
                    /* 在Buffer中创建实体 */
                    var instance = commandBuffer.Instantiate(entityInQueryIndex, spawnerFromEntity.Prefab);

                    /* 删除筛选出来的实体对象，这个很重要，后面会解释 */
                    commandBuffer.DestroyEntity(entityInQueryIndex, entity);

                }).Schedule(inputDeps);

            /* 把Job添加到EntityCommandBufferSystem */
            m_EntityCommandBufferSystem.AddJobHandleForProducer(jobHandle);

            return jobHandle;
        }

    }
}