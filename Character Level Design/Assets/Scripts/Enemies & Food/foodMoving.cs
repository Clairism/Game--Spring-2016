using UnityEngine;
using System.Collections;

public class foodMoving : MonoBehaviour {

	float xSpeed;
	float ySpeed;
	float amplitude;

	private Vector3 tempPosition;

	void Start () 
	{
		tempPosition = transform.position;

		xSpeed = Random.Range(0.02f, 0.08f);
		ySpeed = Random.Range(0.5f, 2f);
		amplitude = Random.Range(2, 5);
	}

	void FixedUpdate () 
	{
		tempPosition.x -= xSpeed;
		tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * ySpeed)* amplitude;
		transform.position = tempPosition;
	}
}
