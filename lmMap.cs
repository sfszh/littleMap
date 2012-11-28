using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class lmMap: MonoBehaviour{
	
	private Map map;
	//datas put into mesh
	public List<Vector3> mapVertices = new List<Vector3> ();
	public List<int> mapTriangles = new List<int>();
	public List<Vector2> mapUVs = new List<Vector2>();
	//prefabs
	//drag and drop them
	public Transform Cliff_Concave;
	public Transform Cliff_Convex;
	public Transform Cliff_Edge;
	//memory holders this just used to hold tempMemory
	private Transform specialTile;
	private Transform prefabTile;
	const int TILE_SIZE = 1;
	//public lmMap(Tile[,] data, Point2 size) 
	//{
	//	map.tile = data;
	//	map.Size = size;
	//}
	
	// hard-coded map
	// |------N(y)
	// |
	// |
	// E(x)
	static public readonly Tile[,] MapDataRaw = new Tile[,]
	{ 
		{
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None)},
			
		{
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.CornerConvex,Orientation.SW),
			new Tile(0,TileType.CornerConvex,Orientation.NW),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None)},
		{
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Edge,Orientation.S),
			new Tile(0,TileType.Edge,Orientation.N),
			new Tile(1,TileType.Flat,Orientation.None),
			new Tile(1,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None)},
		{
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.CornerConvex,Orientation.SE),
			new Tile(1,TileType.CornerConvex,Orientation.NE),
			new Tile(1,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None)},
		{
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None)},
		{
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.CornerConcave,Orientation.SW),
			new Tile(0,TileType.CornerConcave,Orientation.NW),
			new Tile((float)0.5,TileType.Flat,Orientation.None),
			new Tile((float)0.7,TileType.Flat,Orientation.None),
			new Tile((float)0.7,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None)},
		{
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.CornerConcave,Orientation.SE),
			new Tile(0,TileType.CornerConcave,Orientation.NE),
			new Tile((float)0.5,TileType.Flat,Orientation.None),
			new Tile((float)0.7,TileType.Flat,Orientation.None),
			new Tile((float)0.7,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None)},
		{
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None),
			new Tile(0,TileType.Flat,Orientation.None)},
	};
	

	//List<Transform> SpecialTiles = new List<Transform>();
	
	//rend Vertices
	public int GetVertices()
	{
	    for(int i = 0; i < map.Size.x; i++)
	    {
	        for( int j = 0; j < map.Size.y; j++)
	        {
	            mapVertices.Add(new Vector3(i * TILE_SIZE, (float)map.tile[i,j].height, j* TILE_SIZE));
	        }
	    }
		Debug.Log("RendVertices done");
	    return 0;
	    
	}
	
	//public Vector3 ReturnVertices(Point2 Pos)
	//{
	//	return new Vector3(Pos.x * TILE_SIZE, (float)map.tile[i,j].height, Pos.y* TILE_SIZE);
	//}
	
	// Delegate of Instantiate(clone) a special tile from known Transform
	public delegate Transform InstSpecialTileDelegate(Point2 Pos,Orientation ori);
	
	
	// get Cliff Concave tile from prefab
	public Transform GetCliffConcave(Point2 Pos,Orientation ori)
	{
		Vector3 vPos = TilePosToWorldPos(Pos);
		Quaternion rotation;
		switch(ori)
		{
		case Orientation.SW:
			rotation = Quaternion.Euler(Cliff_Concave.eulerAngles.x + 0,Cliff_Concave.eulerAngles.y+0,Cliff_Concave.eulerAngles.z-180);
			return Transform.Instantiate(Cliff_Concave,vPos,rotation) as Transform;
		case Orientation.NW:
			rotation = Quaternion.Euler(Cliff_Concave.eulerAngles.x + 0,Cliff_Concave.eulerAngles.y+0,Cliff_Concave.eulerAngles.z-90);
			return Transform.Instantiate(Cliff_Concave,vPos,rotation) as Transform;
		case Orientation.NE:
			rotation = Quaternion.Euler(Cliff_Concave.eulerAngles);//
			return Transform.Instantiate(Cliff_Concave,vPos,rotation) as Transform;
		case Orientation.SE:
			rotation = Quaternion.Euler(Cliff_Concave.eulerAngles.x+0,Cliff_Concave.eulerAngles.y+0,Cliff_Concave.eulerAngles.z + 90);
			return Transform.Instantiate(Cliff_Concave,vPos,rotation) as Transform;
		default:
			Debug.Log("invalid concave");
			return null;
		}
	}
	
	//get Cliff Convex Tile from prefab
	public Transform GetCliffConvex(Point2 Pos,Orientation ori)
	{
		Vector3 vPos = TilePosToWorldPos(Pos);
		Quaternion rotation;
		switch(ori)
		{
		case Orientation.SW:
			rotation = Quaternion.Euler(Cliff_Convex.eulerAngles.x+0,Cliff_Convex.eulerAngles.y+0,Cliff_Convex.eulerAngles.z-180);//-180);
			return Transform.Instantiate(Cliff_Convex,vPos,rotation)as Transform;
		case Orientation.NW:
			rotation = Quaternion.Euler(Cliff_Convex.eulerAngles.x + 0,Cliff_Convex.eulerAngles.y+0,Cliff_Convex.eulerAngles.z-90);
			return Transform.Instantiate(Cliff_Convex,vPos,rotation)as Transform;
		case Orientation.NE:
			rotation = Quaternion.Euler(Cliff_Convex.eulerAngles);//
			return Transform.Instantiate(Cliff_Convex,vPos,rotation)as Transform;
		case Orientation.SE:
			rotation = Quaternion.Euler(Cliff_Convex.eulerAngles.x+0,Cliff_Convex.eulerAngles.y+0,Cliff_Convex.eulerAngles.z + 90);
			return Transform.Instantiate(Cliff_Convex,vPos,rotation)as Transform;
		default:
			Debug.Log("invalid convex");
			return null;
		}	
	}
	
	public Transform GetCliffEdge(Point2 Pos, Orientation ori)
	{
		Vector3 vPos = TilePosToWorldPos(Pos);
		Quaternion rotation;		
		switch(ori)
		{
		case Orientation.N:
			rotation = Quaternion.Euler(Cliff_Edge.eulerAngles);//
			return Transform.Instantiate(Cliff_Edge,vPos,rotation)as Transform;
		case Orientation.S:
			rotation = Quaternion.Euler(Cliff_Edge.eulerAngles.x+0,Cliff_Edge.eulerAngles.y+0,Cliff_Edge.eulerAngles.z+180);//-180);
			return Transform.Instantiate(Cliff_Edge,vPos,rotation)as Transform;
		case Orientation.W:
			rotation = Quaternion.Euler(Cliff_Edge.eulerAngles.x+0,Cliff_Edge.eulerAngles.y+0,Cliff_Edge.eulerAngles.z + 90);
			return Transform.Instantiate(Cliff_Edge,vPos,rotation)as Transform;
		case Orientation.E:
			rotation = Quaternion.Euler(Cliff_Edge.eulerAngles.x + 0,Cliff_Edge.eulerAngles.y+0,Cliff_Edge.eulerAngles.z-90);
			return Transform.Instantiate(Cliff_Edge,vPos,rotation)as Transform;
		default:
			Debug.Log("invalid convex");
			return null;
		}			
	}

	public int GetTriangles()
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
	
	//TODO
	//change to vPos to pPos
	public int TransformTile(Point2 Pos,ref Transform tranTile)
	{
		Mesh meshTile =  tranTile.GetComponent<MeshFilter>().mesh;
		Vector3[] verts = meshTile.vertices;
		for(int iVert = 0; iVert < verts.Length; iVert++)
		{
			//it local coordinate system so:
			// x means x; y means z; z means y in world coordinate;
			Vector3 vGloble = tranTile.TransformPoint(verts[iVert]); // temp variable of each vertice from mesh;
			// first we get the decimal part of x and y
			float xTile = tranTile.TransformPoint(verts[iVert]).x - Pos.x*TILE_SIZE;//Mathf.Floor(tranTile.TransformPoint(verts[iVert]).x);
			float yTile = tranTile.TransformPoint(verts[iVert]).z - Pos.y*TILE_SIZE;//Mathf.Floor(tranTile.TransformPoint(verts[iVert]).z);
			//Debug.Log ("globle vector :" + tranTile.TransformPoint(verts[iVert]));
			//Debug.Log ("x :" + xTile + "z :" + yTile);
			
			//bilinearly interpolated
			vGloble.y += (1 - xTile)*(1-yTile)*map.tile[Pos.x,Pos.y].height + 
						 (1 - xTile)*yTile*map.tile[Pos.x,Pos.y+1].height + 
						 xTile*(1-yTile)*map.tile[Pos.x+1,Pos.y].height + 
						 xTile*yTile*map.tile[Pos.x+1,Pos.y+1].height;
			
			verts[iVert] = tranTile.InverseTransformPoint(vGloble);
		}
		meshTile.vertices = verts;	
		return 0;
	}
	
	
	//
	public Vector3 TilePosToWorldPos(Point2 Pos)
	{
		Vector3 vPos = new Vector3();
		vPos.Set((Pos.x+0.5f) * TILE_SIZE, 0, (Pos.y+0.5f)* TILE_SIZE);
		return vPos;
	}
	
	
	public int GetSpecialTiles(GameObject parent)
	{
//		Transform specTile = new Transform; // temp memory holder of special Tile
		//Vector3	vPos = new Vector3();
		InstSpecialTileDelegate InstSpecialTile = null; //ʕ •ᴥ•ʔ 
	    for(int i = 0; i < map.Size.x-1; i++)
	    {
	        for( int j = 0; j < map.Size.y -1; j++)
	        {
				if(map.tile[i,j].tileType != TileType.Flat)
				{
					switch(map.tile[i,j].tileType)
					{
					case TileType.CornerConcave:
						InstSpecialTile = new InstSpecialTileDelegate(GetCliffConcave);
						break;
					case TileType.CornerConvex:
						InstSpecialTile = new InstSpecialTileDelegate(GetCliffConvex);
						break;
					case TileType.Edge:
						InstSpecialTile = new InstSpecialTileDelegate(GetCliffEdge);
						break;
					default:
						Debug.Log("Don't know this type");
						break;
					}
					//vPos.Set((i+0.5f) * TILE_SIZE, 0, (j+0.5f)* TILE_SIZE);
					Transform specTile = InstSpecialTile(new Point2(i,j),map.tile[i,j].ori); // this transform contains mesh of the tile
					specTile.parent = parent.transform;
					//Mesh meshTile =  specTile.GetComponent<MeshFilter>().mesh;
					//Vector3[] verts = meshTile.vertices;
					//
					////Debug.Log ("vertices num: "+verts.Length);
					//for(int iVert = 0; iVert < verts.Length; iVert++)
					//{
					//	//it local coordinate system so:
					//	// x means x; y means z; z means y in world coordinate;
					//	Vector3 vGloble = specTile.TransformPoint(verts[iVert]); // temp variable of each vertice from mesh;
					//	// first we get the decimal part of x and y
					//	float xTile = specTile.TransformPoint(verts[iVert]).x - i*TILE_SIZE;//Mathf.Floor(specTile.TransformPoint(verts[iVert]).x);
					//	float yTile = specTile.TransformPoint(verts[iVert]).z - j*TILE_SIZE;//Mathf.Floor(specTile.TransformPoint(verts[iVert]).z);
					//	//Debug.Log ("globle vector :" + specTile.TransformPoint(verts[iVert]));
					//	//Debug.Log ("x :" + xTile + "z :" + yTile);
					//	//bilinearly interpolated
					//	vGloble.y += (1 -xTile)*(1-yTile)*map.tile[i,j].height + (1-xTile)*yTile*map.tile[i,j+1].height + xTile*(1-yTile)*map.tile[i+1,j].height + xTile*yTile*map.tile[i+1,j+1].height;
					//	verts[iVert] = specTile.InverseTransformPoint(vGloble);
					//}
					//meshTile.vertices = verts;
					TransformTile(new Point2(i,j),ref specTile);
					specTile.gameObject.isStatic = true; // set to static
				}
			}
		}
		Debug.Log("GetSpecialTiles done");
		return 0;
	}
	
	public int GetUVs()
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
	
	/**
	 *
	 * Edit Part*/
	
	//set a height of the vertice from specific position
	public int SetTileHeight(Point2 Pos,float Height)
	{
		map.tile[Pos.x,Pos.y].height = Height;
		return 0;
	}
	
	//set the type of Tile
	public int SetTileType(Point2 Pos,BrushType Type, Orientation ori = Orientation.None)
	{
		//map.tile[Pos.x,Pos.y].
		return 0;
	}
	
	public int DrawGrid(float offSet, Material mat)
	{
		//Material mat = new Material(Shader.Find("Diffuse"));
		//mat.SetColor("_Color",Color.white);
		GL.PushMatrix();
		mat.SetPass(0);
		for(int i = 0; i < map.Size.x -1; i++)
		{
			GL.Begin(GL.LINES);
//			GL.Color(Color.black);
			
			for( int j = 0; j < map.Size.y-1; j++)
			{
				GL.Vertex3(i* TILE_SIZE,map.tile[i,j].height + offSet,j* TILE_SIZE);
				GL.Vertex3(i* TILE_SIZE,map.tile[i,j+1].height + offSet,(j+1)* TILE_SIZE);
				GL.Vertex3(i* TILE_SIZE,map.tile[i,j].height + offSet,j* TILE_SIZE);
				GL.Vertex3((i+1)* TILE_SIZE,map.tile[i+1,j].height + offSet,j* TILE_SIZE);				
			}
			GL.End();
		}
		GL.PopMatrix(); 	           	
		return 0;
	}
	// this should be executed before start()
	void OnEnable() {
		map.tile = MapDataRaw;
		map.Size = new Point2(8,8);
	}
	
	//
} //End of Class