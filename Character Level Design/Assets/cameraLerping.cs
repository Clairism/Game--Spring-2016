using UnityEngine;
using System.Collections;

public class cameraLerping : MonoBehaviour {

	GameObject player;

	public Transform startPoint;
	public Transform endPoint;

	//private float rotateSpeed = 3f;

	float speed;

	void Start () {

		speed = 10f;
		player = GameObject.FindGameObjectWithTag("Player");

	}

	// Update is called once per frame
	void Update () {

		transform.LookAt (player.transform.position);

		startPoint = transform;

		endPoint = GameObject.Find ("Player").transform;

		transform.position = Vector3.Lerp (startPoint.position, endPoint.position, speed*Time.deltaTime);
	}
}
