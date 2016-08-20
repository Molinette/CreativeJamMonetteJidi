﻿using UnityEngine;
using System.Collections;

public class WindStream : MonoBehaviour {
	private Vector2 windDirection;
	public float windForce = 10;
	private float time = 0;
	public Vector2 timeRange = new Vector2(5,15);

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;

		if (time <= 0) {
			windForce = Random.Range (2f, 3f);
			switch (Random.Range (1, 3)) {
			case 1:
				windDirection = new Vector2 (-windForce, 0);
				break;
			case 2:
				windDirection = new Vector2 (windForce, 0);
				break;
			}

			time = Random.Range(timeRange.x,timeRange.y);
		}

		//print ("time left: " + time + "; windDirection: " + windDirection + "; windForce: " + windForce);
	}

	public Vector2 GetWindDirection(){
		return windDirection;
	}

	public float GetWindForce(){
		return windForce;
	}
}
