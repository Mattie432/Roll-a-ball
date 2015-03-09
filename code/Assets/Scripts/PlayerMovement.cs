using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;

	// Use this for initialization, this runs when the script is loaded
	void Start () {
		count = 0;
		winText.text = "";
		SetCountText();
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

	//This method is used to detect collisions beteen our player and objects.
	void OnTriggerEnter(Collider other) {

		//Here we check if the object we are coliding with has the "PickUp" tag
		if (other.gameObject.tag == "PickUp") {

			//If it is a "PickUp" object, disable it.
			other.gameObject.SetActive(false);

			//Increment the count value for pickup objects collected.
			count = count + 1;

			//update the count text
			SetCountText();

			if(count >= 12){
				winText.text = "You Win!!";
			}
		}
	}

	void SetCountText(){
		//Update the value of the count text
		countText.text = "Count: " + count.ToString();
	}
}
