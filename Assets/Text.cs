using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Text : MonoBehaviour {
	public float time = 20;
	public string scene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time <= 0) {
			SceneManager.LoadScene (scene);
		}
	}
}
