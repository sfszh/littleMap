using UnityEngine;
using System.Collections;
/**
 * the coordinate system
 * +x East
 * +z North
 * +y Up*/

public enum TileType
{
	None,			//Uninitialized
	Empty,			//Empty for special structure
    Flat,
	//deprecate
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
	//deprecate
	CornerConcave,
	CornerConvex,
	Edge,
    SlopeHigh, // there are 2 debris to consists an entire slope
    SlopeLow
};

// orientation for special tile
public enum Orientation
{
	None,	//uninitialized or flat
	SW,
	NW,
	NE,
	SE,
	N,
	S,
	W,
	E,
}
// atom part of map
public struct Tile
{
    public float height;
    public TileType tileType;
	public Orientation ori;
	public Tile(float h, TileType t, Orientation o)
	{
		height = h;
		tileType = t;
		ori = o;
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

