using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Map loader.
/// Add components to GameObject and load entire terrain
/// </summary>

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))] //automated added MeshFilter and MeshRenderer fixme meshcollider?
public class MapLoader : MonoBehaviour {
	
	// Use this for initialization
	void Start() {
		MeshFilter meshFilter = (MeshFilter)gameObject.GetComponent(typeof(MeshFilter));
		MeshRenderer meshRenderer = (MeshRenderer)gameObject.GetComponent(typeof(MeshRenderer));
		Material mat = Resources.Load("Cliff/Materials/a2",typeof(Material))as Material;
		if(mat != null)
		{
			meshRenderer.material = mat;
		}
		else
		{
			Debug.Log("MapLoader: fail to load mat");
		}	
		//MeshFilter meshFilter = (MeshFilter)gameObject.GetComponent(typeof(MeshFilter));
        Mesh mesh = meshFilter.mesh;
        lmMap map = (lmMap)gameObject.GetComponent(typeof(lmMap));
		//fixme vertices triangles uv return immediate
        map.GetVertices();
        map.GetTriangles();
		map.GetSpecialTiles(gameObject);
        map.GetUVs();
        mesh.vertices = map.mapVertices.ToArray();
        mesh.triangles = map.mapTriangles.ToArray();
        mesh.uv = map.mapUVs.ToArray();
		mesh.RecalculateNormals(); 
		mesh.RecalculateBounds (); 
		mesh.Optimize();
		gameObject.AddComponent(typeof(MeshCollider));
	}

	
	void Update(){
		//lmMap map = (lmMap)gameObject.GetComponent(typeof(lmMap));
		//map.DrawGrid();
	}
	

}
