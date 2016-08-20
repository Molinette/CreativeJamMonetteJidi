using UnityEngine;
using System.Collections;

public class WindStream : MonoBehaviour {
	private Vector2 windDirection;
	private float windForce = 10;
	private float time = 0;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;

		if (time <= 0) {
			windForce = Random.Range (2f, 4f);
			switch (Random.Range (1, 3)) {
			case 1:
				windDirection = new Vector2 (-windForce, 0);
				break;
			case 2:
				windDirection = new Vector2 (windForce, 0);
				break;
			/*case 2:
				windDirection = new Vector2 (-windForce, windForce/20);
				break;
			/*case 3:
				windDirection = new Vector2 (0, windForce/20);
				break;
			case 4:
				windDirection = new Vector2 (windForce, windForce/20);
				break;
			case 5:
				windDirection = new Vector2 (windForce, 0);
				break;
			case 6:
				windDirection = new Vector2 (windForce, -windForce/20);
				break;
			case 7:
				windDirection = new Vector2 (0, -windForce/20);
				break;
			case 8:
				windDirection = new Vector2 (-windForce, -windForce/20);
				break;*/
			}

			time = Random.Range(5,15);
		}

		print ("time left: " + time + "; windDirection: " + windDirection + "; windForce: " + windForce);
	}

	public Vector2 GetWindDirection(){
		return windDirection;
	}

	public float GetWindForce(){
		return windForce;
	}
}
