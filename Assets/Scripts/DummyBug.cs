using UnityEngine;
using System.Collections;

public class DummyBug : MonoBehaviour {
	public float jumpForce;
	public float jumpDelayMin;
	public float jumpDelayMax;
	public float maxRotate;
	public float minRotate;
	float jumpDelay;
	float jumpTimer;
	float jumpThreshold;
	float rotation;
	bool rotateClockwise;
	Animator animator;
	float JUMP_END = .2f;

	// initialize
	void Start () {
		pickParameters ();
		animator = GetComponent<Animator> ();
		jumpThreshold = (jumpDelayMax + jumpDelayMin) / 2 - JUMP_END;
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
		// return to normal sprite when enough time has passed (when average timer would have .2s left, or current timer has .2s left)
		if (jumpDelay - jumpTimer >= jumpThreshold || jumpTimer <= JUMP_END)
			animator.SetBool ("Jumping", false);;
		// rotate as chosen
		transform.Rotate(new Vector3 (0f, 0f, rotation));
		// jump once the time runs out
		if (jumpTimer == 0f) {
			Vector2 jumpVector = (Vector2)transform.up;
			jumpVector = jumpVector.normalized * jumpForce;
			GetComponent<Rigidbody2D>().AddForce(jumpVector);
			animator.SetBool ("Jumping", true);
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
