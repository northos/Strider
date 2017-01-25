using UnityEngine;
using System.Collections;

public class DummyBug : MonoBehaviour {
	public Sprite jumpSprite;
	public Sprite stillSprite;
	public float jumpForce;
	public float jumpDelayMin;
	public float jumpDelayMax;
	public float maxRotate;
	public float minRotate;
	float jumpDelay;
	float jumpTimer;
	float rotation;
	bool rotateClockwise;

	// initialize
	void Start () {
		pickParameters ();
	}

	// this bug will continually do the following:
	//  randomly pick a direction to turn
	//	randomly pick a speed at which to rotate (from within a given range
	//	randomly pick how long to wait before jumping
	// 	continue rotating until the chosen wait time is reached
	//	jump forward
	// 	repeat
	void Update () {
		// update timer
		jumpTimer = Mathf.Max (0f, jumpTimer - Time.deltaTime);
		// return to normal sprite when timer is almost up
		if (jumpTimer <= .2f)
			GetComponent<SpriteRenderer> ().sprite = stillSprite;
		// rotate as chosen
		transform.Rotate(new Vector3 (0f, 0f, rotation));
		// jump once the time runs out
		if (jumpTimer == 0f) {
			Vector2 jumpVector = (Vector2)transform.up;
			jumpVector = jumpVector.normalized * jumpForce;
			GetComponent<Rigidbody2D>().AddForce(jumpVector);
			GetComponent<SpriteRenderer> ().sprite = jumpSprite;
			pickParameters ();
		}
	}

	// randomly pick parameters for the next jump
	void pickParameters () {
		jumpDelay = Random.Range (jumpDelayMin, jumpDelayMax);
		jumpTimer = jumpDelay;
		rotateClockwise = (Random.Range (0, 2) == 1) ? true : false;
		rotation = Random.Range (minRotate, maxRotate);
		rotation = rotateClockwise ? rotation : -rotation;
	}

	// on collision with a bubble, destroy it (as though collected by the player)
	void OnTriggerEnter2D (Collider2D c) {
		if (c.gameObject.tag == "Bubble") {
			Destroy (c.gameObject);
		}
	}
}
