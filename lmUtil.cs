using UnityEngine;
using System.Collections;

public class lmUtil : MonoBehaviour {
	public Material mat;
	GameObject primitiveMap ;
	lmMap map; 
	// Use this for initialization
	void Start () {
		primitiveMap = GameObject.Find("map");
		map = (lmMap)primitiveMap.GetComponent(typeof(lmMap));
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnPostRender(){
		//Debug.Log("hahaahhahaha");
		//lmMap map = (lmMap)gameObject.GetComponent(typeof(lmMap));
		map.DrawGrid(0.01f,mat);
	}
}