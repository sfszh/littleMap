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
    //CornerConcave_SW,	//North
	//CornerConcave_NW,	//South
	//CornerConcave_NE,	//West
	//CornerConcave_SE,	//East
    //CornerConvex_SW,
	//CornerConvex_NW,
	//CornerConvex_NE,
	//CornerConvex_SE,
    //Edge_N,
	//Edge_S,
	//Edge_W,
	//Edge_E,
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

// the size and position of map
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

//
public enum BrushType
{
	None, 	//*Not defined
	Empty,	//*
	Flat,	//*	
	LowLand1,
	LowLand2,
	HighLand1,//*	
	HighLand2,
	Slop,
	WaterShallow,
	WaterDeep,
}

struct TileOffsets
{
	public float sw;
	public float nw;
	public float ne;
	public float se;
	public TileOffsets(float sw,float nw,float ne,float se)
	{
		this.sw = sw;
		this.nw = nw;
		this.ne = ne;
		this.se = se;	
	}
	public void Reset()
	{
		sw = 0;
		nw = 0;
		ne = 0;
		se = 0;
	}
	public void Set(float SW,float NW,float NE,float SE)
	{
		sw = SW;
		nw = NW;
		ne = NE;
		se = SE;
	}
}
//
public enum BrushSize
{
	One,
	Two,
	Three,
}

//
public enum BrushShape
{
	Round,
	Square,
}