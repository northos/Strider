using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
	public GameObject player;

	// set up text with initial score (0)
	void Start () {
		gameObject.GetComponent<Text> ().text = "Score: " + player.GetComponent<BugMovement> ().score;
	}
	
	// update text along with player score
	void Update () {
		gameObject.GetComponent<Text> ().text = "Score: " + player.GetComponent<BugMovement> ().score;	
	}
}
