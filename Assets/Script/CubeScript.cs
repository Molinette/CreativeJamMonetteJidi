using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {

	Rigidbody2D rb2d;
	public float force;
	public float timer;
	public KeyCode test;
	private float timerPlayerOne;
	private float timerPlayerTwo;

	private bool isTouchablePlayerOne = false;
	private bool isTouchablePlayerTwo = false;


	// Use this for initialization
	void Start () {
	
		rb2d = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		//Player 1
		//Left
		if (timerPlayerOne <= 0) {

			if (Input.GetKeyDown (KeyCode.A)) {
				rb2d.AddForce (new Vector2 (-1 * force, 0));
				timerPlayerOne = timer;
			}
		//Up
			else if (Input.GetKeyDown (KeyCode.W)) {
				rb2d.AddForce (new Vector2 (0, 1 * force));
				timerPlayerOne = timer;
			}
		//Right
			else if (Input.GetKeyDown (KeyCode.D)) {
				rb2d.AddForce (new Vector2 (1 * force, 0));
				timerPlayerOne = timer;
			}
		//Down
			else if (Input.GetKeyDown (KeyCode.S)) {
				rb2d.AddForce (new Vector2 (0, -1 * force));
				timerPlayerOne = timer;
			}

			
		}
		//Player 2
		//Left
		if (Input.GetKeyDown (KeyCode.Keypad4)) {
			rb2d.AddForce (new Vector2 (-1 * force, 0));
			timerPlayerTwo = timer;
		}
		//Up
		else if (Input.GetKeyDown (KeyCode.Keypad8)) {
			rb2d.AddForce (new Vector2 (0, force * 1));
			timerPlayerTwo = timer ;
		}
		//Right
		else if(Input.GetKeyDown(KeyCode.Keypad6)){
			rb2d.AddForce (new Vector2 (force*1, 0));
			timerPlayerTwo = timer ; 
		}
		//Down
		else if(Input.GetKeyDown(KeyCode.Keypad2)){
			rb2d.AddForce (new Vector2 (0, force*-1));
			timerPlayerTwo = timer;
		}

		//Timer
		timerPlayerTwo -= Time.deltaTime;
		timerPlayerOne -= Time.deltaTime;
	}


}
