using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody2D))]

public class BugMovement : MonoBehaviour {
	public Sprite jumpSprite;
	public Sprite stillSprite;
	public Sprite splatSprite;
	public GameObject diedText;
	public GameObject sticksText;
	public GameObject menuButton;
	public float jumpForce;
	public float jumpDelay;
	public float superJumpForce;
	public float superJumpDelay;
	float jumpTimer;
	public float superJumpTimer;
	public int score;
	public float deathHeight;

	// initialize score and jump cooldowns
	void Start () {
		jumpTimer = 0f;
		superJumpTimer = superJumpDelay;
		score = 0;
	}

	// update jump cooldown with passage of time
	// check for jump input and jump if pressed
	void Update () {
		// if the bug has fallen too far below the bottom of the screen, end the game
		if (transform.position.y < deathHeight) {
			endGame (false);
		}

		Vector3 mouseLocation = (Camera.main.ScreenToWorldPoint (Input.mousePosition));

		// point sprite towards mouse location for more reasonable jumping
		transform.rotation = Quaternion.LookRotation(transform.forward, mouseLocation - transform.position);

		// decrement the jump cooldowns timer until 0
		jumpTimer = Mathf.Max (jumpTimer - Time.deltaTime, 0f);
		superJumpTimer = Mathf.Max (superJumpTimer - Time.deltaTime, 0f);

		// update return sprite to default when player can almost jump again
		if (jumpTimer <= .1f)
			GetComponent<SpriteRenderer> ().sprite = stillSprite;

		// jump when mouse is clicked, as long as cooldown isn't active
		// change sprite to jumping sprite and start cooldown timer
		if (CrossPlatformInputManager.GetAxis ("Fire1") == 1f && jumpTimer == 0f) {
			Vector2 jumpVector = (Vector2)(mouseLocation - transform.position);
			jumpVector = jumpVector.normalized * jumpForce;
			GetComponent<Rigidbody2D>().AddForce(jumpVector);
			GetComponent<SpriteRenderer> ().sprite = jumpSprite;
			jumpTimer = jumpDelay;
		}
			
		// perform super jump when right mouse is clicked
		// cannot super jump while normal jump cooldown is active
		// must also wait for a longer super jump cooldown, but can jump normally during this
		if (CrossPlatformInputManager.GetAxis ("Fire2") == 1f && jumpTimer == 0f && superJumpTimer == 0f) {
			Vector2 jumpVector = (Vector2)(mouseLocation - transform.position);
			jumpVector = jumpVector.normalized * superJumpForce;
			GetComponent<Rigidbody2D>().AddForce(jumpVector);
			GetComponent<SpriteRenderer> ().sprite = jumpSprite;
			jumpTimer = jumpDelay;
			superJumpTimer = superJumpDelay;
		}
	}

	// public function to update score that other objects can call
	public void addScore(int points) {
		score += points;
	}

	// public function to end game upon hitting a stick (indicated by the bool argument) or falling off the screen
	public void endGame(bool stickHit) {
		Time.timeScale = 0;
		diedText.SetActive (true);
		sticksText.SetActive (stickHit);
		menuButton.SetActive (true);
		GetComponent<SpriteRenderer> ().sprite = splatSprite;
	}
}
