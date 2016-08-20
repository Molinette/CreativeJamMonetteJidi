using UnityEngine;
using System.Collections;

public class FireSpawner : MonoBehaviour {
	public float spawnerSpeed = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Player1Horizontal2") != 0)
			transform.Translate (new Vector2(5 * Time.deltaTime * Input.GetAxis("Player1Horizontal2"), 0));
		print (Input.GetAxis ("Player1Horizontal2"));
	}
}
