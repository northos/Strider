using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {
	public Vector3 gravityDirection;

	// on starting the scene, change the direction of physics gravity as set in the public field
	// default gravity direction is (0, -4, 0)
	void Start () {
		Physics2D.gravity = gravityDirection;
	}
}
