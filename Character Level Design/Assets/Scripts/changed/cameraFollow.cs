using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {


	float DistanceAway = 5;

	void Start () {
	
	}

	void Update () {

		Vector3 player = GameObject.Find("Player").transform.transform.position;
		transform.position = new Vector3(player.x, 0, player.z - DistanceAway);
	
	}
}
