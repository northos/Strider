using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Text))]

public class HighScoreText : MonoBehaviour {
	public string scoreTag;

	// on start, update the attached text to match the stored high score, according to the provided tag
	// if no such score exists, the text will remain '0'
	void Start() {
		if (PlayerPrefs.HasKey (scoreTag)) {
			GetComponent<Text> ().text = PlayerPrefs.GetInt (scoreTag).ToString ();
		}
	}
}
