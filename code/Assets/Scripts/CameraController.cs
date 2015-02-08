using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	//Public so we can set the player variable from within unity.
	public GameObject player;
	//This is the camera offset from the ball.
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		//Set offset vector = camera's current position.
		offset = transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//Set the camera position to the balls position + the offset
		transform.position = player.transform.position + offset;
	}
}
