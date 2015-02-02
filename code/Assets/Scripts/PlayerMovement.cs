using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speed;

	// Use this for initialization, this runs when the script is loaded
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//Called before performing any physics calculations. This is the one we will be using.
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}
}
