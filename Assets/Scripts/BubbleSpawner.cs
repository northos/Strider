using UnityEngine;
using System.Collections;

public class BubbleSpawner : MonoBehaviour {
	public GameObject bigBubble;
	public GameObject medBubble;
	public GameObject smallBubble;
	public float spawnBaseX;
	public float spawnBaseY;
	public float spawnRangeX;
	public float spawnInterval;
	float lastSpawn;

	void Start() {
		lastSpawn = 0;
	}
	
	// spawn bubbles at random locations every few seconds
	void Update () {
		if (Time.time - lastSpawn >= spawnInterval) {
			int sizeSelector = Random.Range (0, 3);
			GameObject bubble = sizeSelector == 0 ? bigBubble : (sizeSelector == 1 ? medBubble : smallBubble);
			float loc = Random.Range (-spawnRangeX, spawnRangeX);
			Instantiate (bubble, new Vector3 (spawnBaseX + loc, spawnBaseY, 0), transform.rotation);
			lastSpawn = Time.time;
		}
	}
}
