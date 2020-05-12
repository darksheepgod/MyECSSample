using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace MyECSSample.ForEach
{
    public class RotationSpeedSystem_ForEach : JobComponentSystem
    {
        // OnUpdate runs on the main thread.
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var deltaTime = Time.DeltaTime;

            // Schedule job to rotate around up vector
            var jobHandle = Entities
                .ForEach((ref Rotation rotation, in RotationSpeed_ForEach rotationSpeed) =>
                {
                    rotation.Value = math.mul(
                        math.normalize(rotation.Value),
                        quaternion.AxisAngle(math.up(), rotationSpeed.RadiansPerSecond * deltaTime));
                })
                .Schedule(inputDeps);

            return jobHandle;
        }
    }
}
