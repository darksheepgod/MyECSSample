using Unity.Entities;

namespace MyECSSample.ForEach
{

    [GenerateAuthoringComponent]
    public struct RotationSpeed_ForEach : IComponentData
    {
        public float RadiansPerSecond;
    }

}
