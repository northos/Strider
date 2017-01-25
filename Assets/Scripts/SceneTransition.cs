using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour {
	public string sceneName;

	// change to the named scene
	public void changeScene() {
		Time.timeScale = 1;
		SceneManager.LoadScene (sceneName);
	}
}
