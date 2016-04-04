using UnityEngine;
using System.Collections;

public class waterMoving : MonoBehaviour {
	
	float speed;

	// Use this for initialization
	void Start () {

		speed = 0.02f;

	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * speed);
	}
}
