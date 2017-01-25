using UnityEngine;
using System.Collections;

public class JumpBar : MonoBehaviour {
	public GameObject player;
	public float xOffset;
	public float maxXPos;
	public float maxXScale;
	float maxTimer;

	void Start () {
		maxTimer = player.GetComponent<BugMovement> ().superJumpDelay;
	}
	
	// update the jump charge bar as the player's super jump recharges
	// scale both length and x position of the quad to look like a filling bar
	void Update () {
		float curTimer = player.GetComponent<BugMovement> ().superJumpTimer;
		float curScale = (maxTimer - curTimer) / maxTimer;
		transform.position = new Vector3 (maxXPos * curScale + xOffset, transform.position.y, transform.position.z);
		transform.localScale = new Vector3 (maxXScale * curScale, transform.localScale.y, transform.localScale.z);
	}
}
