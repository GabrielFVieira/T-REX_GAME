using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Menu");

        if (Input.GetKeyDown(KeyCode.R))
            restartCurrentScene();
	}
	
	 public void restartCurrentScene()
	 {
		Scene scene = SceneManager.GetActiveScene(); 
		SceneManager.LoadScene(scene.name);
     }
}
