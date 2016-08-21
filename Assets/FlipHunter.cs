using UnityEngine;
using System.Collections;

public class FlipHunter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Player2Horizontal2") >= 0){
			transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x),transform.localScale.y);
		}
		else{
			transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x)*-1,transform.localScale.y);
		}
	}
}
