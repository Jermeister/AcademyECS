using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Rendering;

public class Settings : MonoBehaviour {

	public Mesh phoenixMesh;
	public Mesh sphere;
	public Material mat;
	public Vector3[] verts;
	public float radius = 0.8f;
	private MeshInstanceRenderer MSI;

	void Start () {
		verts = phoenixMesh.vertices;

		var GO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere = GO.GetComponent<MeshFilter>().mesh;

		MSI = new MeshInstanceRenderer();
		MSI.material = mat;
		MSI.mesh = sphere;
		Destroy(GO);
	}

	public MeshInstanceRenderer getMSI()
	{
		return MSI;
	}
}
