using UnityEngine;
using System.Collections;

public class WindParticle : MonoBehaviour {
	private WindStream windStream;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		windStream = GameObject.Find ("Wind").GetComponent<WindStream>();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = windStream.GetWindDirection ();
		if (transform.position.x > 10 || transform.position.x < -10) {
			Destroy (gameObject);
		}
	}
}
