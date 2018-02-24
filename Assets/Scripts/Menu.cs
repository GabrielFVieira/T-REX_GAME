using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    private float timer;
    private GameObject start;
	// Use this for initialization
	void Start () {
        start = GameObject.FindGameObjectWithTag("Title");
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("Main");

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

            timer += Time.deltaTime;
        if(timer > 0.3f)
        {
            start.SetActive(!start.activeSelf);
            timer = 0;
        }
	}
}
