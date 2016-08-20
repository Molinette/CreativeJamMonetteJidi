using UnityEngine;
using System.Collections;

public class WindEmitter : MonoBehaviour {
	public GameObject windParticlePrefab;
	public Vector2 range;
	public float delay;
	private WindStream windStream;
	private float nextTime = 0;

	// Use this for initialization
	void Start () {
		windStream = GameObject.Find ("Wind").GetComponent<WindStream>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextTime) {
			float posX;
			if (windStream.GetWindDirection ().x > 0){
				posX = transform.position.x - range.x;
			} else {
				posX = transform.position.x + range.x;
			}
			GameObject windParticle = (GameObject)GameObject.Instantiate(windParticlePrefab, new Vector2(posX, 
				Random.Range(transform.position.y - range.y, transform.position.y + range.y)), windParticlePrefab.transform.rotation);
			windParticle.GetComponent<Rigidbody2D>().velocity = windStream.GetWindDirection();
			nextTime = Time.time + delay;
		}
	}
}
