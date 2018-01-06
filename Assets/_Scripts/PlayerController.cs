﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {

	//Public properties 
	public GameController gameController;
	//Borders
	public float LeftBoundary;
	public float RightBoundary;
	public float TopBoundary;
	public float BottomBoundary;

	public GameObject bullet;
    public HealthbarScript bar;
    //public Ga
	//to limit the shots
	public float fireCooldown = 0.5f;
	//timestamp of when the last shot was fired
	private float fireTimer;

	// changed
	public float playerX = -955;
    
	//Public methods


	// Use this for initialization
	void Start () {
        bar = gameObject.AddComponent<HealthbarScript>();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			this.transform.position += new Vector3(0, 5, 0);
		}

		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			this.transform.position += new Vector3(0, -5, 0);
		}

		if (Input.GetKey(KeyCode.Space) || Input.GetButton("Fire1"))
		{
			if (fireTimer < Time.time) {
				Instantiate (bullet, transform.position, Quaternion.identity);
				fireTimer = Time.time + fireCooldown;
			}
		}

		/*
        float mousePosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        Vector3 mousepositionX = new Vector3(mousePosX, 0f, 0f);
        if (mousepositionX.x > this.RightBoundary)
        {
            mousepositionX.x = this.RightBoundary;
        }
        if (mousepositionX.x < this.LeftBoundary)
        {
            mousepositionX.x = this.LeftBoundary;
        }


        float mousePosY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        Vector3 mousepositionY = new Vector3(0f, mousePosY, 0f);
        if (mousepositionY.y > this.TopBoundary)
        {
            mousepositionY.y = this.TopBoundary;
        }
        if (mousepositionY.y < this.BottomBoundary)
        {
            mousepositionY.y = this.BottomBoundary;
        }
        */

		//every frame sets the player's position to the mouse position
		//transform.position = mousepositionX + mousepositionY;

		// changed
		//transform.position = new Vector3(playerX, 0, 0) + mousepositionY;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag =="WhiteBloodCell")
		{
			gameController.SetPoints(gameController.GetPoints() + 25, true);
			Debug.Log("Collided with White Cell");           
		}
		if (collision.gameObject.tag == "Bacteria")
		{
			gameController.SetLifePoints(gameController.GetLifePoints() - 5, true);
            //bar.setHealth(gameController.GetLifePoints() - 5);
			Debug.Log("Collided with Bacteria");
		}
	}
}
