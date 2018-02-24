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
    private int index;
    private float maxTimerRocks;
    private float maxTimerClouds;

    [SerializeField]
    public float[] maxTimers;

    public bool Pterodactiles;
	// Use this for initialization
	void Start () {
        index = 0;

        maxTimerRocks = Mathf.FloorToInt(Random.Range(3, 6));

        maxTimerClouds = Mathf.FloorToInt(Random.Range(3, 8));
    }
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		timerRocks += Time.deltaTime;
        timerClouds += Time.deltaTime;
        /*
        if(GetComponent<Score>().stopTimer > 2.5f)
        {
            for(int i = 0; i < maxTimers.Length; i++)
            {
                if (maxTimers[i] > 0.2f)
                    maxTimers[i] -= 0.1f;
            }
        }*/

		if(timer > maxTimers[index])
		{
            if (index == maxTimers.Length - 1 && Pterodactiles)
            {
                GameObject obstacle1 = Instantiate(obstacle[obstacle.Length - 1]) as GameObject;
            }

            else
            {
                GameObject obstacle1 = Instantiate(obstacle[Mathf.FloorToInt(Random.Range(0, obstacle.Length - 1))]) as GameObject;
            }

            if(Pterodactiles == false)
                index = Mathf.FloorToInt(Random.Range(0, maxTimers.Length - 1));

            else
                index = Mathf.FloorToInt(Random.Range(0, maxTimers.Length));

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
