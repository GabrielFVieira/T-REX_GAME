using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    [SerializeField]
    private Text highScore;

    [SerializeField]
    private Text score;

    private int scorePoints;
    private float scorePointsF;

    private bool flashText;
    private float timer;
    private float stopTimer;

    [SerializeField]
    private Scrolling[] bgObj;

    // Use this for initialization
    void Start () {
        int hsTest = PlayerPrefs.GetInt("Score");

        if (hsTest < 10)
            highScore.text = "HI 0000" + hsTest;

        else if(hsTest < 100)
            highScore.text = "HI 000" + hsTest;

        else if(hsTest < 1000)
            highScore.text = "HI 00" + hsTest;

        else if(hsTest < 10000)
            highScore.text = "HI 0" + hsTest;

        else
            highScore.text = "HI " + hsTest;

        if (highScore.text == "HI 00000")
            highScore.gameObject.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
        scorePointsF += Time.deltaTime * 8f;

        scorePoints = Mathf.FloorToInt(scorePointsF);

        if (flashText == false)
        {
            if (scorePoints < 10)
                score.text = "0000" + scorePoints;

            else if (scorePoints < 100)
                score.text = "000" + scorePoints;

            else if (scorePoints < 1000)
                score.text = "00" + scorePoints;

            else if (scorePoints < 10000)
                score.text = "0" + scorePoints;

            else
                score.text = scorePoints.ToString();
        }

        if(scorePoints > PlayerPrefs.GetInt("Score"))
            PlayerPrefs.SetInt("Score", scorePoints);


        if(scorePoints % 100 == 0 && flashText == false && scorePoints != 0)
        {
            flashText = true;
        }


        if(flashText == true)
        {
            timer += Time.deltaTime;
            stopTimer += Time.deltaTime;

            if (timer > 0.3f)
            {
                score.enabled = !score.isActiveAndEnabled;
                timer = 0;
            }

            if (stopTimer > 2.5f)
            {
                if (bgObj[0].vel < 13)
                {
                    foreach (Scrolling go in bgObj)
                        go.vel *= 1.15f;
                }

                if (GetComponent<SpawnObjects>().maxTimers[0] > 0.36f)
                {
                    for (int i = 0; i < GetComponent<SpawnObjects>().maxTimers.Length; i++)
                    {
                        if (GetComponent<SpawnObjects>().maxTimers[i] > 0.35f)
                            GetComponent<SpawnObjects>().maxTimers[i] -= 0.15f;

                        if (GetComponent<SpawnObjects>().maxTimers[i] < 0.35f)
                            GetComponent<SpawnObjects>().maxTimers[i] = 0.35f;
                    }

                    GameObject.FindGameObjectWithTag("Player").GetComponent<BetterJump>().fallVel += 0.9f;
                }

                score.enabled = true;
                flashText = false;
                timer = 0;
                stopTimer = 0;
            }
        }

        if (scorePoints > 350)
            GameObject.Find("GameController").GetComponent<SpawnObjects>().Pterodactiles = true;

    }
}
