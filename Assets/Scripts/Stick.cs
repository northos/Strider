using UnityEngine;
using System.Collections;

public class Stick : MonoBehaviour {
	public float yFloor;

	// on collision with player, end the game (bug squished)
	void OnTriggerEnter2D (Collider2D c) {
		if (c.gameObject.tag == "Player") {
			c.gameObject.GetComponent<BugMovement> ().endGame (true);
		}
	}

	// destroy once the stick falls too far below the screen
	void Update() {
		if (transform.position.y <= yFloor)
			Destroy (gameObject);
	}
}
