using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {
	public int score;
	public float yFloor;

	// on collision with player, destroy self and give player points
	void OnTriggerEnter2D (Collider2D c) {
		if (c.gameObject.tag == "Player") {
			c.gameObject.GetComponent<BugMovement> ().addScore (score);
			Destroy (gameObject);
		}
	}

	// destroy once the bubble falls too far below the screen
	void Update() {
		if (transform.position.y <= yFloor)
			Destroy (gameObject);
	}
}
