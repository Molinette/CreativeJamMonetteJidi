using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
	private ParticleSystem particles;
	public float timer = 5f;
	private Seagull pheonix;
	private bool dead = false;

	// Use this for initialization
	void Start () {
		particles = GetComponent<ParticleSystem> ();
		pheonix = GameObject.FindGameObjectWithTag ("Pheonix").GetComponent<Seagull>();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			particles.Stop ();
			if(dead == false)
				pheonix.RemoveFireBall ();
			dead = true;
			Destroy (gameObject, 2);
		}
	}
}
