using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class MapEdit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Hello");	
		MeshFilter meshFilter = (MeshFilter)gameObject.GetComponent(typeof(MeshFilter));
        Mesh mesh = meshFilter.sharedMesh;
		if(!mesh)
		{
			Debug.LogWarning("mesh is not exist");
		}
        lmMap map = (lmMap)gameObject.GetComponent(typeof(lmMap));
		map.OnEnable();
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
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButtonDown(0))
		{
			//Debug.Log("Hit");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit))
			{
				Debug.Log("Mouse is Mapped to :" + hit.point);
			}
		}
	
	}
}
