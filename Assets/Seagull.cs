using UnityEngine;
using System.Collections;

public class Seagull : MonoBehaviour {
	private Rigidbody2D rb;
	public int flyUpwardSpeed = 5;
	public int flyHorizontalSpeed = 5;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			rb.AddForce (new Vector2 (0, flyUpwardSpeed));
		}
		if (Input.GetKey (KeyCode.D)) {
			rb.AddForce (new Vector2 (flyHorizontalSpeed, 0));
		} else if (Input.GetKey (KeyCode.A)) {
			rb.AddForce (new Vector2 (-flyHorizontalSpeed, 0));
		}

		rb.AddForce (GameObject.Find ("Wind").GetComponent<WindStream> ().GetWindDirection ().normalized * GameObject.Find ("Wind").GetComponent<WindStream> ().GetWindForce ());
	}
}
