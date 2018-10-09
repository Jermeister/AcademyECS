using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

// public class  : JobComponentSystem {
public class SphereSpawnSystem : ComponentSystem
{
	public EntityArchetype Sphere;

	protected override void OnUpdate()
	{
		Sphere = Bootstrap.Sphere;

		var count = Bootstrap.settings.verts.Length;
		float radius = 0;
		var mir = Bootstrap.settings.getMSI();

		for (var i = 0; i < count; i++)
		{
			var sphereEntity = EntityManager.CreateEntity(Sphere);
			EntityManager.SetSharedComponentData(sphereEntity, mir);
			EntityManager.SetComponentData(sphereEntity, new Position
			{
				Value = Bootstrap.settings.verts[i]

			});
		}

		Enabled = false;
	}

}
