using UnityEngine;
using System.Collections;

public class Seagull : MonoBehaviour {
	private Rigidbody2D rb;
	public int flyUpwardSpeed = 5;
	public int flyHorizontalSpeed = 5;
	public float windFactor = 1f;
	public GameObject fireMarker;
	public GameObject fireBallPrefab;
	private WindStream windStream;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		windStream = GameObject.Find ("Wind").GetComponent<WindStream>();
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

		rb.AddForce (windStream.GetWindDirection ().normalized * windStream.GetWindForce () * windFactor);

		if (Input.GetKeyDown (KeyCode.H)) {
			GameObject fireBallInstance = (GameObject)GameObject.Instantiate (fireBallPrefab, transform.position, fireBallPrefab.transform.rotation);
			fireBallInstance.GetComponent<Rigidbody2D> ().velocity = new Vector2 (fireMarker.transform.position.x - transform.position.x, fireMarker.transform.position.y - transform.position.y).normalized * 3;
		}
	}


	void OnTriggerEnter2D(Collider2D other){


		if (other.gameObject.CompareTag("Arrow")) {

			Destroy (this.gameObject);
			Destroy (other.gameObject);
		}

		if  (other.gameObject.CompareTag("Water")) {
			Destroy (this.gameObject);
		}
			



	}
}
