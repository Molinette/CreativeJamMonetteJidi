using UnityEngine;
using System.Collections;

public class hunterArmScript : MonoBehaviour {
	public float startingAngle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 direction = new Vector2(Input.GetAxis("Player2Horizontal2"), Input.GetAxis("Player2Vertical2"));
		float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - startingAngle;
		/*if(Input.GetAxis("Player2Horizontal2") > 0){
			transform.eulerAngles = new Vector3(0, 0, rotationZ);
		}
		else{
			transform.eulerAngles = new Vector3(0, 0, -rotationZ);
		}*/
		transform.eulerAngles = new Vector3(0, 0, rotationZ);
	}
}
