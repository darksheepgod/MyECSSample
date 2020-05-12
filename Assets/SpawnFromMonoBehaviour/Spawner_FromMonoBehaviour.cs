using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace MyECSSample.SpawnFromMonoBehaviour
{
    public class Spawner_FromMonoBehaviour : MonoBehaviour
    {
        public GameObject Prefab;
        public int CountX = 10;
        public int CountY = 10;

        void Start()
        {
            /* 创建实体时需要指定配置，这里涉及到World的概念，可以先不管，照抄就是了 */
            var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);

            /* 从我们的prefab中创建一个实体对象 */
            var entityFromPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(Prefab, settings);

            /* 实体管理器 */
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            /* 循环创建多个实体 */
            for (var x = 0; x < CountX; x++)
            {
                for (var y = 0; y < CountY; y++)
                {
                    /* 赋值新的实体 */
                    var instance = entityManager.Instantiate(entityFromPrefab);

                    /* 修改实体的Translation组件 */
                    var position = transform.TransformPoint(new float3(x * 1.3F, noise.cnoise(new float2(x, y) * 0.21F) * 2, y * 1.3F));
                    entityManager.SetComponentData(instance, new Translation { Value = position });
                }
            }
        }
    }
}
