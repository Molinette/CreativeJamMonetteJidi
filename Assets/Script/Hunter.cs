﻿using UnityEngine;
using System.Collections;

public class Hunter : MonoBehaviour {
	public float hunterSpeed = 0.5f;
	public float maxSpeed = 5f;
	public Transform firingPosition;
	public float maxFiringForce = 15;
	public float firingForceIncrement = 15;
	public GameObject projectilePrefab;
	private WindStream windStream;
	public float windFactor = 0.5f;

	private float firingForce = 0;

	//public int acceleration = 2;
	//private float speed = 0;
	//public float maxSpeed = 5;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		windStream = GameObject.Find ("Wind").GetComponent<WindStream>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 firingDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

		if (Input.GetKey (KeyCode.RightArrow)) {
			rb.AddForce(new Vector2(hunterSpeed,0));
			rb.velocity = new Vector2 (Mathf.Min (rb.velocity.x, maxSpeed), 0);
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			rb.AddForce(new Vector2(-hunterSpeed,0));
			rb.velocity = new Vector2 (Mathf.Max (rb.velocity.x, -maxSpeed), 0);
		}

		if (Input.GetMouseButton (0)) {
			firingForce = Mathf.Min(firingForce + firingForceIncrement * Time.deltaTime, maxFiringForce);
		}
		if(Input.GetMouseButtonUp (0)){
			GameObject projectileInstance = (GameObject)GameObject.Instantiate (projectilePrefab, firingPosition.position, projectilePrefab.transform.rotation);
			projectileInstance.GetComponent<Rigidbody2D> ().AddForce (firingDirection.normalized*firingForce, ForceMode2D.Impulse);
			firingForce = 0;
		}

		rb.AddForce (windStream.GetWindDirection ().normalized * windStream.GetWindForce () * windFactor);
	}
}
