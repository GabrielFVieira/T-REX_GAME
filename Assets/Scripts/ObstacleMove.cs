using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour {
	private Scrolling scroll;
	// Use this for initialization
	void Start () {
		scroll = GameObject.Find("Ground1").GetComponent<Scrolling>();
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.y >= -1)
            transform.Translate(-scroll.vel * 0.3f *Time.deltaTime, 0, 0);

        else
            transform.Translate(-scroll.vel * Time.deltaTime, 0, 0);

        if (transform.position.x < -20)
            Destroy(gameObject);
    }
}
