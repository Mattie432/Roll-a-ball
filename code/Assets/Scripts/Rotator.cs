using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		//This is the roational movement we want to add to the PickUp object
		Vector3 vector = new Vector3(15, 30, 45);

		//This applies the rotate. The deltaTime smooths the movement into seconds rather than frames.
		transform.Rotate (vector * Time.deltaTime);
	}
}
