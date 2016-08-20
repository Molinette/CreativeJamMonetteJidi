using UnityEngine;
using System.Collections;

public class Hunter : MonoBehaviour {
	public float hunterSpeed = 5;
	public Transform firingPosition;
	public float maxFiringForce = 15;
	public float firingForceIncrement = 15;
	public GameObject projectilePrefab;

	private float firingForce = 0;

	public int acceleration = 2;
	private float speed = 0;
	public float maxSpeed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 firingDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

		if (Input.GetKey (KeyCode.RightArrow)) {
			speed = Mathf.Min (speed + acceleration * Time.deltaTime, maxSpeed);
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			speed = Mathf.Max (speed - acceleration * Time.deltaTime, -maxSpeed);
		} else {
			if (speed > 0) {
				Mathf.Min (speed + acceleration * Time.deltaTime, maxSpeed);
			} else if(speed < 0){
				Mathf.Max (speed - acceleration * Time.deltaTime, -maxSpeed);
			}
		}

		transform.Translate(new Vector2(speed*Time.deltaTime,0));


		if (Input.GetMouseButton (0)) {
			firingForce = Mathf.Min(firingForce + firingForceIncrement * Time.deltaTime, maxFiringForce);
		}
		if(Input.GetMouseButtonUp (0)){
			GameObject projectileInstance = (GameObject)GameObject.Instantiate (projectilePrefab, firingPosition.position, projectilePrefab.transform.rotation);
			projectileInstance.GetComponent<Rigidbody2D> ().AddForce (firingDirection.normalized*firingForce, ForceMode2D.Impulse);
			firingForce = 0;
		}
	}
}
