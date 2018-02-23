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
    // Use this for initialization
    void Start () {
        //highScore.te = PlayerPrefs.GetInt("Score", scorePoints);

        if (highScore.text == "HI 00000")
            highScore.gameObject.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(scorePointsF);

        scorePointsF += Time.deltaTime * 6f;

        scorePoints = Mathf.FloorToInt(scorePointsF);

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

        PlayerPrefs.SetInt("Score", scorePoints);
    }
}
