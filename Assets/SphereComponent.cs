using System;
using Unity.Entities;

[Serializable]
public struct SphereComp : IComponentData
{
	public float Value;
}

[UnityEngine.DisallowMultipleComponent]
public class CubeComponent : ComponentDataWrapper<Radius>
{
}
