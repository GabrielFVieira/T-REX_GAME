using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {
	public float vel;
	private float startPos;
	
	// Use this for initialization
	void Start () {
		startPos = 22.4f;
		vel = 4.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if(vel < 9)
		{
			vel += Time.deltaTime * 0.4f;
		}
		
		
		transform.Translate (-vel * Time.deltaTime, 0, 0);
			
		if(transform.position.x <= -21.04f)
		{
			transform.position = new Vector3(startPos, transform.position.y, transform.position.z);
		}			
	}
}
