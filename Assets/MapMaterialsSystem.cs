
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
public partial class MapMaterialsSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref MapMaterialHDRColorData colorData) =>
           {
               colorData.color = new Color(math.sin((float)SystemAPI.Time.ElapsedTime), math.cos((float)SystemAPI.Time.ElapsedTime), 0, 1);
           }).Schedule();
    }
}
