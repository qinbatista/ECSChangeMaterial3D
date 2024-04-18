using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using UnityEngine;


[MaterialProperty("_BaseColor")]
public struct MapMaterialHDRColorData : IComponentData
{
    public Color color;
}
public class MapMaterialColorAuthoring : MonoBehaviour
{
    // public float Value;
    public Color Color;
    class Baker : Baker<MapMaterialColorAuthoring>
    {
        public override void Bake(MapMaterialColorAuthoring authoring)
        {
            MapMaterialHDRColorData mapMaterialHDRColorData = new MapMaterialHDRColorData
            {
                color = authoring.Color,
            };
            AddComponent(GetEntity(TransformUsageFlags.Renderable), mapMaterialHDRColorData);
        }
    }
}


// #if URP_10_0_0_OR_NEWER
// using Unity.Entities;
// using Unity.Mathematics;

// namespace Unity.Rendering
// {
//     [MaterialProperty("_BaseColor")]
//     public struct URPMaterialPropertyBaseColor : IComponentData
//     {
//         public float4 Value;
//     }

//     [UnityEngine.DisallowMultipleComponent]
//     public class URPMaterialPropertyBaseColorAuthoring : UnityEngine.MonoBehaviour
//     {
//         [Unity.Entities.RegisterBinding(typeof(URPMaterialPropertyBaseColor), nameof(URPMaterialPropertyBaseColor.Value))]
//         public UnityEngine.Color color;

//         class URPMaterialPropertyBaseColorBaker : Unity.Entities.Baker<URPMaterialPropertyBaseColorAuthoring>
//         {
//             public override void Bake(URPMaterialPropertyBaseColorAuthoring authoring)
//             {
//                 Unity.Rendering.URPMaterialPropertyBaseColor component = default(Unity.Rendering.URPMaterialPropertyBaseColor);
//                 float4 colorValues;
//                 colorValues.x = authoring.color.linear.r;
//                 colorValues.y = authoring.color.linear.g;
//                 colorValues.z = authoring.color.linear.b;
//                 colorValues.w = authoring.color.linear.a;
//                 component.Value = colorValues;
//                 var entity = GetEntity(TransformUsageFlags.Renderable);
//                 AddComponent(entity, component);
//             }
//         }
//     }
// }
// #endif
