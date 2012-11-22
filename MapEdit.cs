using UnityEngine;
using System.Collections;

public class MapEdit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
