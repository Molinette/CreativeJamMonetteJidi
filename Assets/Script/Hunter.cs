using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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

	private float time = 0;
	public float firingDelay = 1;

	public AudioSource audioBowRelease;
	public AudioSource audioBow;

	//public int acceleration = 2;
	//private float speed = 0;
	//public float maxSpeed = 5;
	private Rigidbody2D rb;

	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		windStream = GameObject.Find ("Wind").GetComponent<WindStream>();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 firingDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
		*/
		time -= Time.deltaTime;

		Vector2 firingDirection = new Vector2 (Input.GetAxis ("Player2Horizontal2"), Input.GetAxis ("Player2Vertical2"));
		if (Input.GetAxis ("Player2Horizontal") != 0) {
			rb.AddForce (new Vector2 (hunterSpeed * Input.GetAxis ("Player2Horizontal"), 0));
			rb.velocity = new Vector2 (Mathf.Min (rb.velocity.x, maxSpeed), 0);
			rb.velocity = new Vector2 (Mathf.Max (rb.velocity.x, -maxSpeed), 0);
		}
		if (Input.GetButton ("Player2RB") && time <= 0) {
			if(firingForce <= 0 && firingForce < maxFiringForce)
				audioBow.Play ();
			firingForce = Mathf.Min(firingForce + firingForceIncrement * Time.deltaTime, maxFiringForce);
		}
		if(Input.GetButtonUp ("Player2RB") && time <= 0){
			GameObject projectileInstance = (GameObject)GameObject.Instantiate (projectilePrefab, firingPosition.position, projectilePrefab.transform.rotation);
			projectileInstance.GetComponent<Rigidbody2D> ().AddForce (firingDirection.normalized*firingForce, ForceMode2D.Impulse);
			firingForce = 0;
			time = firingDelay;

			audioBowRelease.Play();
		}
	
		rb.AddForce (windStream.GetWindDirection ().normalized * windStream.GetWindForce () * windFactor);
	}


	void OnTriggerEnter2D(Collider2D coll){

		if(coll.gameObject.CompareTag("Fire")){

			Destroy(gameObject);
			gameManager.Victory (1);
		}

		if(coll.gameObject.CompareTag("Neant")){
			Destroy(gameObject);
			gameManager.Victory (1);
		}

	

	}
}
