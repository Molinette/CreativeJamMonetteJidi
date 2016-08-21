using UnityEngine;
using System.Collections;

public class Seagull : MonoBehaviour {
	private Rigidbody2D rb;
	public int flyUpwardSpeed = 5;
	public int flyHorizontalSpeed = 5;
	public float windFactor = 1f;
	public GameObject fireMarker;
	public GameObject fireBallPrefab;
	public AudioSource fireBallSound;
	public float fireBallSpeed = 5;
	private WindStream windStream;
	private int nbFireBall = 0;
	private bool canFire = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		windStream = GameObject.Find ("Wind").GetComponent<WindStream>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Player1Vertical") > 0)
			rb.AddForce (new Vector2 (0, flyUpwardSpeed*Input.GetAxis("Player1Vertical")));
		
		if (Input.GetAxis("Player1Horizontal") != 0)
			rb.AddForce (new Vector2 (flyHorizontalSpeed * Input.GetAxis("Player1Horizontal"), 0));

		rb.AddForce (windStream.GetWindDirection ().normalized * windStream.GetWindForce () * windFactor);

		if (Input.GetButtonDown ("Player1RB")) {
			fireMarker.SetActive (true);
		}
		if (Input.GetButtonUp ("Player1RB")) {
			if (canFire == true) {
				GameObject fireBallInstance = (GameObject)GameObject.Instantiate (fireBallPrefab, transform.position, fireBallPrefab.transform.rotation);
				fireBallInstance.GetComponent<Rigidbody2D> ().velocity = new Vector2 (fireMarker.transform.position.x - transform.position.x, fireMarker.transform.position.y - transform.position.y).normalized * fireBallSpeed;
				fireBallSound.Play ();
				nbFireBall++;
			}
			if (nbFireBall >= 2) {
				canFire = false;
			} else if (nbFireBall == 0) {
				canFire = true;
			}
			fireMarker.SetActive (false);
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

	public void RemoveFireBall(){
		nbFireBall--;
	}


}
