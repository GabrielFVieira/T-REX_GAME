using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexMoves : MonoBehaviour {
    private float jumpVel;
    private bool Grounded = true;

    [SerializeField]
    private GameObject button;

    [SerializeField]
    private Sprite dead;


    private bool duck;
    // Use this for initialization
    void Start()
    {
        button.SetActive(false);
        jumpVel = 5.5f;
        Time.timeScale = 1;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Animator>().SetBool("Duck", duck);

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVel;
            Grounded = false;
            duck = false;
        }

        if(Grounded)
            duck = Input.GetKey(KeyCode.LeftShift);

        if(duck)
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.5493124f, 0.2197976f);
            GetComponent<BoxCollider2D>().offset = new Vector2(0, 0.01978004f);
        }

        else
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 0.3986439f);
            GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
        }
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Floor")
        {
            Grounded = true;
        }
		
		if(col.gameObject.tag == "Obstacle")
        {
			button.gameObject.SetActive(true);
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = dead;
            Time.timeScale = 0;
        }
    }
}
