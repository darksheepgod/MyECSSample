using Unity.Entities;
using Unity.Scenes;

namespace MyECSSample.SystemGroup
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [UpdateBefore(typeof(SceneSystem))]
    public class SystemGroupTestSystem : ComponentSystem
    {
        protected override void OnUpdate() { }
    }
}
