using UnityEngine;
using System.Collections;

public class FireSpawner : MonoBehaviour {
	public float spawnerSpeed = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.J)) {
			transform.Translate (new Vector2(5 * Time.deltaTime, 0));
		} else if (Input.GetKey (KeyCode.G)) {
			transform.Translate (new Vector2(-5 * Time.deltaTime, 0));
		}
	}
}
