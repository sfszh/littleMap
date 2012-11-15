using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[RequireComponent (typeof (MeshFilter))] 
//[RequireComponent (typeof (MeshRenderer))]

/**
 * the coordinate system
 * +x East
 * +z North
 * +y Up*/

public enum TileType
{
    Flat,
    CornerConcave_SW,	//North
	CornerConcave_NW,	//South
	CornerConcave_NE,	//West
	CornerConcave_SE,	//East
    CornerConvex_SW,
	CornerConvex_NW,
	CornerConvex_NE,
	CornerConvex_SE,
    Edge_N,
	Edge_S,
	Edge_W,
	Edge_E,
    SlopeHigh, // there are 2 debris to consists an entire slope
    SlopeLow
};

// atom part of map
public struct Tile
{
    public float height;
    public TileType tileType;
	public Tile(float h, TileType t)
	{
		height = h;
		tileType = t;
	}
}

// the size of map
public struct Point2
{
    public int x,y;
	public Point2(int ix,int iy)
	{
		x = ix;
		y = iy;
	}
}

// 
public struct Map
{    
    public Tile[,] tile;
    public Point2 Size;
    public Map(Tile[,] data, Point2 size)
    {
        Size = size;
        tile = data;
    }
}


public class MapLoader : MonoBehaviour {
	//prefabs
	public Transform Cliff_Concave_00;
	public Transform Cliff_Convex_00;
	public Transform Cliff_Edge_00;
	public Transform specialTile;	
	const int TILE_SIZE = 1;
	
	// hard-coded 
	public readonly Tile[,] MapDataRaw = new Tile[,]
	{ 
		// |------N(y)
		// |
		// |
		// E(x)
		{new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
		{new Tile(0,TileType.Flat),new Tile(0,TileType.CornerConvex_SW),new Tile(0,TileType.CornerConvex_NW),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
		{new Tile(0,TileType.Flat),new Tile(0,TileType.Edge_S),new Tile(0,TileType.Edge_N),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
		{new Tile(0,TileType.Flat),new Tile(0,TileType.CornerConvex_SE),new Tile(0,TileType.CornerConvex_NE),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
		{new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
		{new Tile(0,TileType.Flat),new Tile(0,TileType.CornerConcave_SW),new Tile(0,TileType.CornerConcave_NW),new Tile((float)0.5,TileType.Flat),new Tile((float)0.7,TileType.Flat),new Tile((float)0.7,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
		{new Tile(0,TileType.Flat),new Tile(0,TileType.CornerConcave_SE),new Tile(0,TileType.CornerConcave_NE),new Tile((float)0.5,TileType.Flat),new Tile((float)0.7,TileType.Flat),new Tile((float)0.7,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
		{new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat),new Tile(0,TileType.Flat)},
	};
	
	//datas put into mesh
	List<Vector3> MapVertices = new List<Vector3> ();
	List<int> MapTriangles = new List<int>();
	List<Vector2> MapUVs = new List<Vector2>();
	//List<Transform> SpecialTiles = new List<Transform>();
	
	public int GetVertices(ref Map map, ref List<Vector3> mapVertices)
	{
	    for(int i = 0; i < map.Size.x; i++)
	    {
	        for( int j = 0; j < map.Size.y; j++)
	        {
	            MapVertices.Add(new Vector3(i * TILE_SIZE, (float)map.tile[i,j].height, j* TILE_SIZE));
	        }
	    }
		Debug.Log("GetVertices done");
	    return 0;
	    
	}
	public Transform GenSpecialTile(TileType type, int i, int j)
	{

		if(type != TileType.Flat)
		{
			switch(type)
			{
			case TileType.CornerConvex_SW:
				Cliff_Convex_00.Rotate(0,0,-180);
				specialTile = Instantiate(Cliff_Convex_00, new Vector3((i+0.5f) * TILE_SIZE, 0, (j+0.5f)* TILE_SIZE),Cliff_Convex_00.rotation) as Transform;
				Cliff_Convex_00.Rotate(0,0,180);
				break;
			case TileType.CornerConvex_NW:
				Cliff_Convex_00.Rotate(0,0,-90);
				specialTile = Instantiate(Cliff_Convex_00, new Vector3((i+0.5f) * TILE_SIZE, 0, (j+0.5f)* TILE_SIZE),Cliff_Convex_00.rotation)as Transform;
				Cliff_Convex_00.Rotate(0,0,90);
				break;
			case TileType.CornerConvex_NE:
				specialTile = Instantiate(Cliff_Convex_00, new Vector3((i+0.5f) * TILE_SIZE, 0, (j+0.5f)* TILE_SIZE),Cliff_Convex_00.rotation)as Transform;
				break;
			case TileType.CornerConvex_SE:
				Cliff_Convex_00.Rotate(0,0,90);
				specialTile = Instantiate(Cliff_Convex_00, new Vector3((i+0.5f) * TILE_SIZE, 0, (j+0.5f)* TILE_SIZE),Cliff_Convex_00.rotation)as Transform;
				Cliff_Convex_00.Rotate(0,0,-90);
				break;
			case TileType.Edge_N:
				specialTile = Instantiate(Cliff_Edge_00, new Vector3((i+0.5f) * TILE_SIZE, 0, (j+0.5f)* TILE_SIZE),Cliff_Edge_00.rotation)as Transform;
				break;
			case TileType.Edge_S:
				Cliff_Edge_00.Rotate(0,0,180);
				specialTile = Instantiate(Cliff_Edge_00, new Vector3((i+0.5f) * TILE_SIZE, 0, (j+0.5f)* TILE_SIZE),Cliff_Edge_00.rotation)as Transform;
				Cliff_Edge_00.Rotate(0,0,-180);
				break;
			case TileType.Edge_W:
				Cliff_Edge_00.Rotate(0,0,90);
				specialTile = Instantiate(Cliff_Edge_00, new Vector3((i+0.5f) * TILE_SIZE, 0, (j+0.5f)* TILE_SIZE),Cliff_Edge_00.rotation)as Transform;// as Transform;
				Cliff_Edge_00.Rotate(0,0,-90);
				break;
			case TileType.Edge_E:
				Cliff_Edge_00.Rotate(0,0,-90);
				specialTile = Instantiate(Cliff_Edge_00, new Vector3((i+0.5f) * TILE_SIZE, 0, (j+0.5f)* TILE_SIZE),Cliff_Edge_00.rotation)as Transform;
				Cliff_Edge_00.Rotate(0,0,90);
				break;
			case TileType.CornerConcave_SW:
				Cliff_Concave_00.Rotate(0,0,-180);
				specialTile = Instantiate(Cliff_Concave_00, new Vector3((i+0.5f) * TILE_SIZE, 0, (j+0.5f)* TILE_SIZE),Cliff_Concave_00.rotation)as Transform;
				Cliff_Concave_00.Rotate(0,0,180);
				break;
			case TileType.CornerConcave_NW:
				Cliff_Concave_00.Rotate(0,0,-90);				
				specialTile = Instantiate(Cliff_Concave_00, new Vector3((i+0.5f) * TILE_SIZE, 0, (j+0.5f)* TILE_SIZE),Cliff_Concave_00.rotation)as Transform;
				Cliff_Concave_00.Rotate(0,0,90);
				break;
			case TileType.CornerConcave_NE:
				specialTile = Instantiate(Cliff_Concave_00, new Vector3((i+0.5f) * TILE_SIZE, 0, (j+0.5f)* TILE_SIZE),Cliff_Concave_00.rotation)as Transform;
				break;
			case TileType.CornerConcave_SE:
				Cliff_Concave_00.Rotate(0,0,90);
				specialTile = Instantiate(Cliff_Concave_00, new Vector3((i+0.5f) * TILE_SIZE, 0, (j+0.5f)* TILE_SIZE),Cliff_Concave_00.rotation)as Transform;
				Cliff_Concave_00.Rotate(0,0,-90);
				break;
			default:
				Debug.Log("Tile has not been implemented yet");
				break;
			}
		}
		return specialTile;
	}
	public int GetTriangles(ref Map map, ref List<int> mapTriangles)
	{
	    for(int i = 0; i < map.Size.x-1; i++)
	    {
	        for( int j = 0; j < map.Size.y -1; j++)
	        {
				if(map.tile[i,j].tileType == TileType.Flat)
				{
					/*1st Triangle*/
	            	mapTriangles.Add(i * map.Size.x + j); 		//south-west
					mapTriangles.Add(i * map.Size.x +j +1); 	// north-west
	            	mapTriangles.Add((i + 1) * map.Size.x + j); // south-east

					/*2nd Triangle*/
					mapTriangles.Add((i+1) * map.Size.x + j ); 		//south-east
					mapTriangles.Add(i * map.Size.x +j +1); 	// north-west
					mapTriangles.Add((i+1) * map.Size.x + j + 1);	//north-east
				}
				//else{
				//	GenSpecialTile(map.tile[i,j].tileType,i,j);
				//}
	        }
	    }
		Debug.Log("GetTriangles done");
	    return 0;
	}
	
	public int GetSpecialTiles(ref Map map)
	{
		
	    for(int i = 0; i < map.Size.x-1; i++)
	    {
	        for( int j = 0; j < map.Size.y -1; j++)
	        {
				if(map.tile[i,j].tileType != TileType.Flat)
				{
					Mesh meshTile = GenSpecialTile(map.tile[i,j].tileType,i,j).GetComponent<MeshFilter>().mesh;
					Vector3[] verts = meshTile.vertices;
					for(int iVert = 0; iVert < verts.Length; iVert++)
					{
						//it local coordinate system so:
						// x means x; y means z; z means y in world coordinate;
						float xTile = verts[iVert].x;
						float yTile = verts[iVert].y;
						Debug.Log ("before: "+verts[iVert]);
						verts[iVert].z += (1 -xTile)*(1-yTile)*map.tile[i,j].height + (1-xTile)*yTile*map.tile[i,j+1].height + xTile*(1-yTile)*map.tile[i+1,j].height +xTile*yTile*map.tile[i+1,j+1].height;
								
						Debug.Log ("after: "+verts[iVert]);
					}
					meshTile.RecalculateBounds (); 
				}
			}
		}
		Debug.Log("GetSpecialTiles done");
		return 0;
	}
	
	public int GetUVs(ref Map map, ref List<Vector2> mapUVs)
	{
	    for(int i = 0; i < map.Size.x; i++)
	    {
	        for( int j = 0; j < map.Size.y; j++)
	        {
	            mapUVs.Add( new Vector2(i * TILE_SIZE, j * TILE_SIZE));
	        }
	    }
		Debug.Log("GetUVs done");
	    return 0;
	}

	
	// Use this for initialization
	void Start () {
            MeshFilter meshFilter = (MeshFilter)GameObject.Find("map").GetComponent(typeof(MeshFilter));
            Mesh mesh = meshFilter.mesh;
            Map map = new Map( MapDataRaw, new Point2(8,8));
            GetVertices(ref map, ref MapVertices);
            GetTriangles(ref map, ref MapTriangles);
			GetSpecialTiles(ref map);
            GetUVs(ref map, ref MapUVs);
            mesh.vertices = MapVertices.ToArray();
            mesh.triangles = MapTriangles.ToArray();
            mesh.uv = MapUVs.ToArray();
		
			//renderer.material = new Material(Shader.Find("Diffuse"));		//This line cause texture failed to load
			mesh.RecalculateNormals(); 
			mesh.RecalculateBounds (); 
			mesh.Optimize();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
