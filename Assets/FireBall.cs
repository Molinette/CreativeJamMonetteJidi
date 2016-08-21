using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {
	public GameObject firePrefab;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Water")) {
			GameObject fireInstance = (GameObject)GameObject.Instantiate (firePrefab, transform.position, firePrefab.transform.rotation);
			Destroy (gameObject);
		}
	}
}
