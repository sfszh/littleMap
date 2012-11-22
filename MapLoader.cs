using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MapLoader : MonoBehaviour {
	
	public Transform Cliff_Concave;
	public Transform Cliff_Convex;
	public Transform Cliff_Edge;
//	//prefabs
//	static public Transform Cliff_Concave = (Transform)Resources.Load("Resource/Cliff_Concave_01");
//	static public Transform Cliff_Convex = (Transform)Resources.Load("Resource/Cliff_Convex_01");
//	static public Transform Cliff_Edge= (Transform)Resources.Load("Resource/Cliff_Edge_01");
//	//memory holders this just used to hold tempMemory
//	static public Transform specialTile;
//	static public Transform prefabTile;	
//	const int TILE_SIZE = 1;
//	
//	// hard-coded 
//	public readonly Tile[,] MapDataRaw = new Tile[,]
//	{ 
//		// |------N(y)
//		// |
//		// |
//		// E(x)
//		{new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
//		{new Tile(0,TileType.Flat),new Tile(0,TileType.CornerConvex_SW),new Tile(0,TileType.CornerConvex_NW),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
//		{new Tile(0,TileType.Flat),new Tile(0,TileType.Edge_S),new Tile(0,TileType.Edge_N),new Tile(1,TileType.Flat),new Tile(1,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
//		{new Tile(0,TileType.Flat),new Tile(0,TileType.CornerConvex_SE),new Tile(1,TileType.CornerConvex_NE),new Tile(1,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
//		{new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
//		{new Tile(0,TileType.Flat),new Tile(0,TileType.CornerConcave_SW),new Tile(0,TileType.CornerConcave_NW),new Tile((float)0.5,TileType.Flat),new Tile((float)0.7,TileType.Flat),new Tile((float)0.7,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
//		{new Tile(0,TileType.Flat),new Tile(0,TileType.CornerConcave_SE),new Tile(0,TileType.CornerConcave_NE),new Tile((float)0.5,TileType.Flat),new Tile((float)0.7,TileType.Flat),new Tile((float)0.7,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
//		{new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
//		//{new Tile((float)0.0,TileType.Flat),new Tile((float)0.0,TileType.Flat),new Tile((float)0.0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
//		//{new Tile((float)0.0,TileType.Flat),new Tile((float)0.0,TileType.CornerConvex_NE),new Tile((float)0.0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
//		//{new Tile((float)0.0,TileType.Flat),new Tile((float)1.0,TileType.Flat),new Tile((float)0.0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
//		//{new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
//		//{new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
//		//{new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
//		//{new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
//		//{new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
//
//	};
//	
//	//datas put into mesh
//	List<Vector3> MapVertices = new List<Vector3> ();
//	List<int> MapTriangles = new List<int>();
//	List<Vector2> MapUVs = new List<Vector2>();
//	//List<Transform> SpecialTiles = new List<Transform>();
//	
//	static public int GetVertices(ref Map map, ref List<Vector3> mapVertices)
//	{
//	    for(int i = 0; i < map.Size.x; i++)
//	    {
//	        for( int j = 0; j < map.Size.y; j++)
//	        {
//	            mapVertices.Add(new Vector3(i * TILE_SIZE, (float)map.tile[i,j].height, j* TILE_SIZE));
//	        }
//	    }
//		Debug.Log("GetVertices done");
//	    return 0;
//	    
//	}
//	
//	/// <summary>
//	/// generate special Tile 
//	/// </summary>
//	/// <returns>
//	/// The special tile.
//	/// </returns>
//	/// <param name='go'>
//	/// 
//	/// </param> 
//	/// <param name='type'>
//	/// Type of Tile
//	/// </param>
//	/// <param name='vPos'>
//	/// Position of Tile
//	/// </param>
//	/// <param name='pfTile'>
//	/// Prefab of Tile.
//	/// </param>
//	static public Transform GenSpecialTile(GameObject goParent, TileType type,Vector3 vPos,ref Transform pfTile)
//	{
//		if(type != TileType.Flat)
//		{
//			switch(type)
//			{
//			case TileType.CornerConvex_SW:
//				pfTile.Rotate(0,0,-180);
//				specialTile = Instantiate(pfTile, vPos, pfTile.rotation) as Transform;
//				//pfTile.Rotate(0,0,180);
//				break;
//			case TileType.CornerConvex_NW:
//				pfTile.Rotate(0,0,-90);
//				specialTile = Instantiate(pfTile, vPos, pfTile.rotation)as Transform;
//				//pfTile.Rotate(0,0,90);
//				break;
//			case TileType.CornerConvex_NE:
//				specialTile = Instantiate(pfTile, vPos, pfTile.rotation)as Transform;
//				break;
//			case TileType.CornerConvex_SE:
//				pfTile.Rotate(0,0,90);
//				specialTile = Instantiate(pfTile, vPos, pfTile.rotation)as Transform;
//				//pfTile.Rotate(0,0,-90);
//				break;
//			case TileType.Edge_N:
//				specialTile = Instantiate(pfTile, vPos, pfTile.rotation)as Transform;
//				break;
//			case TileType.Edge_S:
//				pfTile.Rotate(0,0,180);
//				specialTile = Instantiate(pfTile, vPos, pfTile.rotation)as Transform;
//				//pfTile.Rotate(0,0,-180);
//				break;
//			case TileType.Edge_W:
//				pfTile.Rotate(0,0,90);
//				specialTile = Instantiate(pfTile, vPos, pfTile.rotation)as Transform;// as Transform;
//				//pfTile.Rotate(0,0,-90); 
//				break;
//			case TileType.Edge_E:
//				pfTile.Rotate(0,0,-90);
//				specialTile = Instantiate(pfTile, vPos, pfTile.rotation)as Transform;
//				//pfTile.Rotate(0,0,90);
//				break;
//			case TileType.CornerConcave_SW:
//				pfTile.Rotate(0,0,-180);
//				specialTile = Instantiate(pfTile, vPos, pfTile.rotation)as Transform;
//				//pfTile.Rotate(0,0,180);
//				break;
//			case TileType.CornerConcave_NW:
//				pfTile.Rotate(0,0,-90);				
//				specialTile = Instantiate(pfTile, vPos, pfTile.rotation)as Transform;
//				//pfTile.Rotate(0,0,90);
//				break;
//			case TileType.CornerConcave_NE:
//				specialTile = Instantiate(pfTile, vPos, pfTile.rotation)as Transform;
//				break;
//			case TileType.CornerConcave_SE:
//				pfTile.Rotate(0,0,90);
//				specialTile = Instantiate(pfTile, vPos, pfTile.rotation)as Transform;
//				//pfTile.Rotate(0,0,-90);
//				break;
//			default:
//				Debug.Log("Tile has not been implemented yet");
//				break;
//			}
//			/**set the parent of specialTile to map*/
//			if(specialTile != null)
//			{
//				specialTile.parent = goParent.transform;
//			}
//		}
//		return specialTile;
//	}
//	static public int GetTriangles(ref Map map, ref List<int> mapTriangles)
//	{
//	    for(int i = 0; i < map.Size.x-1; i++)
//	    {
//	        for( int j = 0; j < map.Size.y -1; j++)
//	        {
//				if(map.tile[i,j].tileType == TileType.Flat)
//				{
//					/*1st Triangle*/
//	            	mapTriangles.Add(i * map.Size.x + j); 		//south-west
//					mapTriangles.Add(i * map.Size.x +j +1); 	// north-west
//	            	mapTriangles.Add((i + 1) * map.Size.x + j); // south-east
//
//					/*2nd Triangle*/
//					mapTriangles.Add((i+1) * map.Size.x + j ); 		//south-east
//					mapTriangles.Add(i * map.Size.x +j +1); 	// north-west
//					mapTriangles.Add((i+1) * map.Size.x + j + 1);	//north-east
//				}
//				//else{
//				//	GenSpecialTile(map.tile[i,j].tileType,i,j);
//				//}
//	        }
//	    }
//		Debug.Log("GetTriangles done");
//	    return 0;
//	}
//	
//	static public int GetSpecialTiles(GameObject root, ref Map map)
//	{
////		Transform specTile = new Transform; // temp memory holder of special Tile
//		Vector3	vPos = new Vector3();
//	    for(int i = 0; i < map.Size.x-1; i++)
//	    {
//	        for( int j = 0; j < map.Size.y -1; j++)
//	        {
//				if(map.tile[i,j].tileType != TileType.Flat)
//				{
//					switch(map.tile[i,j].tileType)
//					{
//					case TileType.CornerConcave_NE:
//					case TileType.CornerConcave_NW:
//					case TileType.CornerConcave_SE:
//					case TileType.CornerConcave_SW:
//						prefabTile = Cliff_Concave;
//						break;
//					case TileType.CornerConvex_NE:
//					case TileType.CornerConvex_NW:
//					case TileType.CornerConvex_SE:
//					case TileType.CornerConvex_SW:
//						prefabTile = Cliff_Convex;
//						break;
//					case TileType.Edge_E:
//					case TileType.Edge_N:
//					case TileType.Edge_S:
//					case TileType.Edge_W:
//						prefabTile = Cliff_Edge;
//						break;
//					default:
//						Debug.Log("Don't know this type");
//						break;
//					}
//					vPos.Set((i+0.5f) * TILE_SIZE, 0, (j+0.5f)* TILE_SIZE);
//					Transform tranTile = GenSpecialTile(root, map.tile[i,j].tileType, vPos, ref prefabTile); // this transform contains mesh of the tile
//					Mesh meshTile =  tranTile.GetComponent<MeshFilter>().mesh;
//					Vector3[] verts = meshTile.vertices;
//					
//					//Debug.Log ("vertices num: "+verts.Length);
//					for(int iVert = 0; iVert < verts.Length; iVert++)
//					{
//						//it local coordinate system so:
//						// x means x; y means z; z means y in world coordinate;
//						Vector3 vGloble = tranTile.TransformPoint(verts[iVert]); // temp variable of each vertice from mesh;
//						// first we get the decimal part of x and y
//						float xTile = tranTile.TransformPoint(verts[iVert]).x - i*TILE_SIZE;//Mathf.Floor(tranTile.TransformPoint(verts[iVert]).x);
//						float yTile = tranTile.TransformPoint(verts[iVert]).z - j*TILE_SIZE;//Mathf.Floor(tranTile.TransformPoint(verts[iVert]).z);
//						//Debug.Log ("globle vector :" + tranTile.TransformPoint(verts[iVert]));
//						//Debug.Log ("x :" + xTile + "z :" + yTile);
//						//bilinearly interpolated
//						vGloble.y += (1 -xTile)*(1-yTile)*map.tile[i,j].height + (1-xTile)*yTile*map.tile[i,j+1].height + xTile*(1-yTile)*map.tile[i+1,j].height + xTile*yTile*map.tile[i+1,j+1].height;
//						verts[iVert] = tranTile.InverseTransformPoint(vGloble);
//					}
//					meshTile.vertices = verts;
//					meshTile.RecalculateBounds(); 
//				}
//			}
//		}
//		Debug.Log("GetSpecialTiles done");
//		return 0;
//	}
//	
//	static public int GetUVs(ref Map map, ref List<Vector2> mapUVs)
//	{
//	    for(int i = 0; i < map.Size.x; i++)
//	    {
//	        for( int j = 0; j < map.Size.y; j++)
//	        {
//	            mapUVs.Add( new Vector2(i * TILE_SIZE, j * TILE_SIZE));
//	        }
//	    }
//		Debug.Log("GetUVs done");
//	    return 0;
//	}
//
//	
//	// Use this for initialization
//	void Start() {
//        //    MeshFilter meshFilter = (MeshFilter)GameObject.Find("map").GetComponent(typeof(MeshFilter));
//			MeshFilter meshFilter = (MeshFilter)gameObject.GetComponent(typeof(MeshFilter));
//			//MeshFilter meshFilter = (MeshFilter)gameObject.AddComponent(typeof(MeshFilter));
//			//MeshCollider meshCollider = (MeshCollider)GameObject.Find("map").GetComponent(typeof(MeshCollider));
//            Mesh mesh = meshFilter.mesh;
//            Map map = new Map( MapDataRaw, new Point2(8,8));
//            GetVertices(ref map, ref MapVertices);
//            GetTriangles(ref map, ref MapTriangles);
//			GetSpecialTiles(gameObject, ref map);
//            GetUVs(ref map, ref MapUVs);
//            mesh.vertices = MapVertices.ToArray();
//            mesh.triangles = MapTriangles.ToArray();
//            mesh.uv = MapUVs.ToArray();
//		
//			//renderer.material = new Material(Shader.Find("Diffuse"));		//This line cause texture failed to load
//			mesh.RecalculateNormals(); 
//			mesh.RecalculateBounds (); 
//			mesh.Optimize();
//			//meshCollider.sharedMesh = mesh;
//			gameObject.AddComponent(typeof(MeshCollider));
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}

	// Use this for initialization
	void Start() {
        //    MeshFilter meshFilter = (MeshFilter)GameObject.Find("map").GetComponent(typeof(MeshFilter));
			MeshFilter meshFilter = (MeshFilter)gameObject.GetComponent(typeof(MeshFilter));
			//MeshFilter meshFilter = (MeshFilter)gameObject.AddComponent(typeof(MeshFilter));
			//MeshCollider meshCollider = (MeshCollider)GameObject.Find("map").GetComponent(typeof(MeshCollider));
            Mesh mesh = meshFilter.mesh;
            lmMap map = new lmMap( lmMap.MapDataRaw, new Point2(8,8));
			map.Cliff_Concave = Cliff_Concave;
			map.Cliff_Convex = Cliff_Convex;
			map.Cliff_Edge = Cliff_Edge;
            map.GetVertices();
            map.GetTriangles();
			map.GetSpecialTiles(gameObject);
            map.GetUVs();
            mesh.vertices = map.mapVertices.ToArray();
            mesh.triangles = map.mapTriangles.ToArray();
            mesh.uv = map.mapUVs.ToArray();
		
			//renderer.material = new Material(Shader.Find("Diffuse"));		//This line cause texture failed to load
			mesh.RecalculateNormals(); 
			mesh.RecalculateBounds (); 
			mesh.Optimize();
			//meshCollider.sharedMesh = mesh;
			gameObject.AddComponent(typeof(MeshCollider));
	}

}
