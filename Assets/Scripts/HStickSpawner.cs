using UnityEngine;
using System.Collections;

public class HStickSpawner : MonoBehaviour {
		public GameObject stick;
		public float spawnBaseX;
		public float spawnBaseY;
		public float spawnRangeY;
		public float spawnInterval;
		float lastSpawn;

		void Start() {
			lastSpawn = 0;
		}

		// spawn bubbles at random locations every few seconds
		void Update () {
			if (Time.time - lastSpawn >= spawnInterval) {
				float loc = Random.Range (-spawnRangeY, spawnRangeY);
				Instantiate (stick, new Vector3 (spawnBaseX, spawnBaseY + loc, 0), transform.rotation);
				lastSpawn = Time.time;
		}
	}
}
