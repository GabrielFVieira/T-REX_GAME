using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {
    [SerializeField]
    private GameObject[] obstacle;

    [SerializeField]
    private GameObject rocks;

    [SerializeField]
    private GameObject clouds;
	private float timer;
	private float timerRocks;
    private float timerClouds;
    private int maxTimer;
    private float maxTimerRocks;
    private float maxTimerClouds;

    [SerializeField]
    private float[] maxTimers;
	// Use this for initialization
	void Start () {
        maxTimer = 0;

        maxTimerRocks = Mathf.FloorToInt(Random.Range(3, 6));

        maxTimerClouds = Mathf.FloorToInt(Random.Range(3, 8));
    }
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		timerRocks += Time.deltaTime;
        timerClouds += Time.deltaTime;

		if(timer > maxTimers[maxTimer])
		{
			GameObject obstacle1 = Instantiate(obstacle[Mathf.FloorToInt(Random.Range(0, obstacle.Length))]) as GameObject;
            maxTimer = Mathf.FloorToInt(Random.Range(0, maxTimers.Length));
            timer = 0;
		}
		
		if(timerRocks > maxTimerRocks)
		{
			GameObject rocks1 = Instantiate(rocks) as GameObject;
            maxTimerRocks = Mathf.FloorToInt(Random.Range(3, 6));
            timerRocks = 0;
		}

        if (timerClouds > maxTimerClouds)
        {
            GameObject cloud1 = Instantiate(clouds) as GameObject;
            cloud1.transform.position = new Vector3(cloud1.transform.position.x, Random.Range(-1, 3), cloud1.transform.position.z);
            float scale;
            scale = Random.Range(2, 4);
            clouds.transform.localScale = new Vector3(scale, scale, scale);
            maxTimerClouds = Mathf.FloorToInt(Random.Range(3, 8));
            timerClouds = 0;
        }
    }
}
