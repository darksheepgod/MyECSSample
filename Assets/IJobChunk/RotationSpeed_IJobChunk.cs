using System;
using Unity.Entities;

namespace MyECSSample.IJobChunk
{
    [Serializable]
    public struct RotationSpeed_IJobChunk : IComponentData
    {
        public float RadiansPerSecond;
    }
}
