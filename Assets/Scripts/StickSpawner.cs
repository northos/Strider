using UnityEngine;
using System.Collections;

public class StickSpawner : MonoBehaviour {
		public GameObject stick;
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
				float loc = Random.Range (-spawnRangeX, spawnRangeX);
				Instantiate (stick, new Vector3 (spawnBaseX + loc, spawnBaseY, 0), transform.rotation);
				lastSpawn = Time.time;
		}
	}
}
