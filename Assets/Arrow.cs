using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Atan(rb.velocity.y/rb.velocity.x)*Mathf.Rad2Deg);
	}
	
	// Update is called once per frame
	void Update () {
		float angle = Mathf.Atan (rb.velocity.y / rb.velocity.x) * Mathf.Rad2Deg;
		if (rb.velocity.x > 0) {
			angle += 180;
		}
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);
		if (!GetComponent<Renderer> ().isVisible) {
			Destroy (gameObject);
		}
		
		rb.AddForce (GameObject.Find ("Wind").GetComponent<WindStream> ().GetWindDirection ().normalized * GameObject.Find ("Wind").GetComponent<WindStream> ().GetWindForce () * 1.5f);
	}

	void OnTriggerEnter2D(Collider2D other){
		Destroy (gameObject);
	}
}
