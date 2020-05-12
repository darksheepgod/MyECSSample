using Unity.Entities;
using Unity.Scenes;

namespace MyECSSample.SystemGroup
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [UpdateAfter(typeof(SystemGroupTestSystem))]
    public class SystemGroupTestSystem2 : ComponentSystem
    {
        protected override void OnUpdate() { }
    }
}
