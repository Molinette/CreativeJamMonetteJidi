using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
	private ParticleSystem particles;

	// Use this for initialization
	void Start () {
		particles = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		//particles.velocityOverLifetime = GameObject.Find ("Wind").GetComponent<WindStream> ().GetWindDirection ();
	}
}
