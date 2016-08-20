using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	private Rigidbody2D rb;
	private WindStream windStream;
	public float windFactor = 1.5f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		windStream = GameObject.Find ("Wind").GetComponent<WindStream>();
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
		
		rb.AddForce (windStream.GetWindDirection ().normalized * windStream.GetWindForce () * windFactor);
	}

	void OnTriggerEnter2D(Collider2D other){
		Destroy (gameObject);
	}
}
