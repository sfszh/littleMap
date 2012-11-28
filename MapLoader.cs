using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MapLoader : MonoBehaviour {
	
	// Use this for initialization
	void Start() {
			MeshFilter meshFilter = (MeshFilter)gameObject.GetComponent(typeof(MeshFilter));
            Mesh mesh = meshFilter.mesh;
            lmMap map = (lmMap)gameObject.GetComponent(typeof(lmMap));
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
