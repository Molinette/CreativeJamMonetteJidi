using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
	private ParticleSystem particles;
	public float timer = 5f;

	// Use this for initialization
	void Start () {
		particles = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			particles.Stop ();
			Destroy (gameObject, 2);
		}
	}
}
