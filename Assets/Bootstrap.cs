using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.SceneManagement;


public sealed class Bootstrap
{
	public static EntityArchetype SphereSpawner;
	public static EntityArchetype Sphere;

	public static Settings settings;
	public static Entity transform;


	public static void Initialize()
	{
		var entityManager = World.Active.GetOrCreateManager<EntityManager>();

		Sphere = entityManager.CreateArchetype(typeof(Position), typeof(SphereComp),
			typeof(MeshInstanceRenderer));

		SphereSpawner = entityManager.CreateArchetype(typeof(Position));

		entityManager.CreateEntity(SphereSpawner);

		//entityManager.SetComponentData(transform, new Position { Value = new float3(0, 0, 0) });

		var spawnSystem = World.Active.GetOrCreateManager<SphereSpawnSystem>();
		spawnSystem.Enabled = true;
	}

	private static void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		settings = GameObject.Find("Settings")?.GetComponent<Settings>();
		if (settings == null)
		{
			return;
		}
		Initialize();
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	public static void InitializeWithScene()
	{
		settings = GameObject.Find("GameController")?.GetComponent<Settings>();
		var spawnSystem = World.Active.GetOrCreateManager<SphereSpawnSystem>();
		spawnSystem.Enabled = false;
		if (settings == null)
		{
			SceneManager.sceneLoaded += OnSceneLoaded;
			return;
		}

		Initialize();
	}
}
